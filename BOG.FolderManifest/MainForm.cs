using System.Collections;
using System.Diagnostics;
using System.Text;
using BOG.SwissArmyKnife;
using BOG.SwissArmyKnife.Extensions;
using Microsoft.Win32;
using BOG.FolderManifest.Entity;

namespace BOG.FolderManifest
{
    public partial class MainForm : Form
    {
        private const string AnsiDateFormatter = "yyyy.MM.dd HH:mm:ss";
        Dictionary<string, List<FileInfoFull>> FileSet = new Dictionary<string, List<FileInfoFull>>();
        Dictionary<string, long> FileSetMaxLength = new Dictionary<string, long>();

        private SettingsDictionary AppSettings = new SettingsDictionary();
        bool LaunchedWithParameter = false;

        bool Rebuild = true;
        string StartFolder = string.Empty;

        public MainForm(string[] args)
        {
            InitializeComponent();
            {
                var a = new AssemblyVersion();
                this.Text += $" ver. {a.Version}, build: {a.BuildDate:F}";
            }
            // CreateFolderAssociation();
            this.txtStartingFolder.Text = Directory.GetCurrentDirectory();
            if (args.Length > 0 && Directory.Exists(args[0]))
            {
                this.txtStartingFolder.Text = args[0];
            }
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void CreateFolderAssociation()
        {
            const string SubKeyPath = @"Directory\shell\BOG.FolderManifest";
            RegistryKey regKey = Registry.ClassesRoot;

            regKey = regKey.OpenSubKey(SubKeyPath);
            if (regKey == null)
            {
                try
                {
                    AssemblyVersion a = new AssemblyVersion(AssemblyVersion.AssemblySource.Entry);
                    regKey = Registry.ClassesRoot;
                    regKey = regKey.CreateSubKey(SubKeyPath);
                    regKey.SetValue("", "BOG.FolderManifest");
                    regKey = regKey.CreateSubKey("command");
                    regKey.SetValue("", string.Format("\"{0}\" \"%1\"", a.Filename));
                }
                catch (Exception err)
                {
                    MessageBox.Show(
                        DetailedException.WithUserContent(ref err) + "\r\n" +
                        "If this error persists,  run this application one time only as administrator",
                        "Can't create Windows Explorer extension for folders",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (regKey != null)
                    {
                        regKey.DeleteSubKey(SubKeyPath, false);
                    }
                }
            }
        }

        /// <summary>
        /// Called when the starting folder is changed by the operator.
        /// </summary>
        private void BuildManifest()
        {
            FileSet.Clear();
            FileSetMaxLength.Clear();

            string ThisFolder = this.txtStartingFolder.Text;
            string PreviousFolder = string.Empty;
            string SubPath = string.Empty;

            ThisFolder = ThisFolder.Length > 0 && ThisFolder[ThisFolder.Length - 1] == '\\' ? ThisFolder + "." : ThisFolder + "\\.";
            ThisFolder = Path.GetDirectoryName(ThisFolder);
            StartFolder = ThisFolder;

            List<string> FileList = new List<string>();
            foreach (string onefile in Directory.GetFiles(ThisFolder, "*.*", this.chkSubfolders.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
            {
                FileList.Add(onefile);
            }
            if (this.chkShowFolders.Checked)
            {
                foreach (string onefile in Directory.GetDirectories(ThisFolder, "*.*", SearchOption.TopDirectoryOnly))
                {
                    FileList.Add(onefile + @"\");
                }
            }
            FileList.Sort(delegate (string f1, string f2) { return f1.CompareTo(f2); });
            foreach (string thisfile in FileList)
            {
                FileInfo f = new FileInfo(thisfile);
                ThisFolder = f.DirectoryName;
                SubPath = ThisFolder.Length == StartFolder.Length ? string.Empty : ThisFolder.Substring(StartFolder.Length + 1);
                FileInfoFull detail = new FileInfoFull();
                if (thisfile[thisfile.Length - 1] == '\\')
                {
                    detail.Name = f.Name;
                    detail.LastModDate = Directory.GetLastWriteTime(f.FullName);
                    detail.Size = 0;
                }
                else
                {
                    detail.Name = f.Name;
                    detail.LastModDate = File.GetLastWriteTime(thisfile);
                    detail.Size = f.Length;
                    if (Path.GetExtension(thisfile).ToLower() == ".dll" || Path.GetExtension(thisfile).ToLower() == ".exe")
                    {
                        try
                        {
                            // AssemblyVersion a = new AssemblyVersion(thisfile);
                            AssemblyVersion a = new AssemblyVersion(typeof(BOG.FolderManifest.Program));
                            detail.AssemblyVersionInfo = string.Format("(Version: {0}, Built: {1})", a.Version, a.BuildDate);
                        }
                        catch
                        {
                        }
                    }
                }

                if (ThisFolder != PreviousFolder)
                {
                    if (FileSet.ContainsKey(SubPath) == false)
                    {
                        FileSet.Add(SubPath, new List<FileInfoFull>());
                        FileSetMaxLength.Add(SubPath, 0);
                    }
                    PreviousFolder = ThisFolder;
                }
                FileSet[SubPath].Add(detail);
                if (FileSetMaxLength[SubPath] < f.Name.Length)
                {
                    FileSetMaxLength[SubPath] = f.Name.Length;
                }
            }
        }

        /// <summary>
        /// Called when a display parameter is changed by the operator.
        /// </summary>
        private void AdjustManifest()
        {
            StringBuilder ManifestResult = new StringBuilder();

            if (this.rbPathAsHeader.Checked)
            {
                ManifestResult.AppendLine("------ " + StartFolder);
            }

            foreach (string subPathKey in FileSet.Keys)
            {
                if (string.IsNullOrEmpty(subPathKey) == false)
                {
                    if (this.rbPathAsHeader.Checked)
                    {
                        ManifestResult.AppendLine();
                        ManifestResult.AppendLine(string.Format(".\\{0}", subPathKey));
                    }
                }
                long MaxFileSize = FileSetMaxLength[subPathKey];
                foreach (FileInfoFull item in FileSet[subPathKey])
                {
                    if (this.rbPathAsHeader.Checked && this.chkSeparateByTab.Checked == false)
                    {
                        ManifestResult.Append("       ");
                    }
                    if (this.chkIncludeTimeAndSize.Checked)
                    {
                        string FormattedAs = "{0}{1}{2,-XX}{3}{4}{5}{6,15}{7}{8}".Replace("XX", MaxFileSize.ToString());
                        ManifestResult.AppendLine(string.Format(FormattedAs,
                             this.rbFileNameOnly.Checked || this.rbPathAsHeader.Checked ? string.Empty : Path.Combine(StartFolder, subPathKey),
                             this.rbFileNameOnly.Checked || this.rbPathAsHeader.Checked ? string.Empty : "\\",
                             item.Name,
                             this.chkSeparateByTab.Checked ? "\t" : " ",
                             item.LastModDate.ToString(AnsiDateFormatter),
                             this.chkSeparateByTab.Checked ? "\t" : " ",
                             item.Size.ToString("0,#"),
                             this.chkSeparateByTab.Checked ? "\t" : " ",
                             this.chkShowAssemblyVersion.Checked ? item.AssemblyVersionInfo : string.Empty
                             ));
                    }
                    else
                    {
                        string FormattedAs = "{0}{1}{2,-XX}{3}{4}".Replace("XX", MaxFileSize.ToString());
                        ManifestResult.AppendLine(string.Format(FormattedAs,
                             this.rbFileNameOnly.Checked || this.rbPathAsHeader.Checked ? string.Empty : Path.Combine(StartFolder, subPathKey),
                             this.rbFileNameOnly.Checked || this.rbPathAsHeader.Checked ? string.Empty : "\\",
                             item.Name,
                             this.chkSeparateByTab.Checked ? "\t" : " ",
                             this.chkShowAssemblyVersion.Checked ? item.AssemblyVersionInfo : string.Empty
                             ));
                    }
                }
            }
            ManifestResult.AppendLine();
            this.txtManifest.Enabled = true;
            this.txtManifest.Text = ManifestResult.ToString();
            this.txtManifest.SelectionStart = 0;
            this.txtManifest.SelectionLength = this.txtManifest.Text.Length;

            this.rbFullPath.Enabled = true;
            this.rbPathAsHeader.Enabled = true;
            this.rbFileNameOnly.Enabled = true;
        }

        private void chkSubfolders_CheckedChanged(object sender, EventArgs e)
        {
            Rebuild = true;
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void chkShowFolders_CheckedChanged(object sender, EventArgs e)
        {
            Rebuild = true;
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void chkShowAssemblyVersion_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void chkIncludeTimeAndSize_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void chkSeparateByTab_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void rbFullPath_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void rbPathAsHeader_CheckedChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.txtStartingFolder.Text))
            {
                MessageBox.Show(this.txtStartingFolder.Text, "Directory not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Enabled = false;
            Rebuild = true;
            tmrRebuildManifest.Interval = 100;
            tmrRebuildManifest.Enabled = true;
            tmrRebuildManifest.Start();
        }

        private void tmrRebuildManifest_Tick(object sender, EventArgs e)
        {
            tmrRebuildManifest.Stop();
            tmrRebuildManifest.Enabled = false;
            if (Rebuild)
            {
                BuildManifest();
                Rebuild = false;
            }
            AdjustManifest();
            this.Enabled = true;
        }

        private void txtManifest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x01)  // CTRL+A
            {
                this.txtManifest.SelectionStart = 0;
                this.txtManifest.SelectionLength = this.txtManifest.Text.Length;
            }
            else if (e.KeyChar == 0x03)  // CTRL+C
            {
                Clipboard.SetText(this.txtManifest.SelectedText);
            }
            else if (e.KeyChar == 0x18)  // CTRL+X
            {
                Clipboard.SetText(this.txtManifest.SelectedText);
                int Caret = this.txtManifest.SelectionStart;
                if (this.txtManifest.Text.Length == this.txtManifest.SelectionLength + this.txtManifest.SelectionStart)
                {
                    this.txtManifest.Text =
                         this.txtManifest.Text.Substring(0, this.txtManifest.SelectionStart);
                }
                else
                {
                    this.txtManifest.Text =
                         this.txtManifest.Text.Substring(0, this.txtManifest.SelectionStart) +
                         this.txtManifest.Text.Substring(this.txtManifest.SelectionStart + this.txtManifest.SelectionLength, this.txtManifest.Text.Length - (this.txtManifest.SelectionStart + this.txtManifest.SelectionLength));
                }
                this.txtManifest.SelectionStart = Caret;
                this.txtManifest.ScrollToCaret();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            dlgFolder.Description = "Locate the starting folder for a manifest";
            dlgFolder.SelectedPath = Directory.Exists(this.txtStartingFolder.Text) ? this.txtStartingFolder.Text : @"C:\";
            if (dlgFolder.ShowDialog() == DialogResult.OK)
            {
                this.txtStartingFolder.Text = dlgFolder.SelectedPath.ToString();
                this.Enabled = false;
                Rebuild = true;
                tmrRebuildManifest.Interval = 100;
                tmrRebuildManifest.Enabled = true;
                tmrRebuildManifest.Start();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox a = new AboutBox();
            a.ShowDialog();
        }

        // Menu and tool strips

        private void selectFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new AssemblyVersion(typeof(BOG.FolderManifest.MainForm));
            var helpfile = Path.Combine(Path.GetDirectoryName(a.Filename), "docs", "BOG.FolderManifest.pdf");
            var p = new Process();
            p.StartInfo.FileName = helpfile;
            p.Start();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}
