using System.Windows.Forms;

namespace BOG.FolderManifest
{
    public partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private ToolStripMenuItem createWindowsExplorerShellExtensionToolStripMenuItem;
        private ToolStripMenuItem removeWindowsExplorerShellExtensionToolStripMenuItem;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            mainToolStripMenuItem = new ToolStripMenuItem();
            selectFolderToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            createWindowsExplorerShellExtensionToolStripMenuItem = new ToolStripMenuItem();
            removeWindowsExplorerShellExtensionToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            dlgFolder = new FolderBrowserDialog();
            tmrRebuildManifest = new System.Windows.Forms.Timer(components);
            btnAbout = new Button();
            btnChange = new Button();
            btnRefresh = new Button();
            txtManifest = new TextBox();
            chkShowFolders = new CheckBox();
            chkSeparateByTab = new CheckBox();
            chkIncludeTimeAndSize = new CheckBox();
            rbFileNameOnly = new RadioButton();
            chkShowAssemblyVersion = new CheckBox();
            txtStartingFolder = new TextBox();
            chkSubfolders = new CheckBox();
            rbPathAsHeader = new RadioButton();
            rbFullPath = new RadioButton();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mainToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(578, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            mainToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { selectFolderToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            mainToolStripMenuItem.Size = new Size(46, 20);
            mainToolStripMenuItem.Text = "&Main";
            // 
            // selectFolderToolStripMenuItem
            // 
            selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
            selectFolderToolStripMenuItem.Size = new Size(141, 22);
            selectFolderToolStripMenuItem.Text = "&Select Folder";
            selectFolderToolStripMenuItem.Click += selectFolderToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(138, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(141, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { createWindowsExplorerShellExtensionToolStripMenuItem, removeWindowsExplorerShellExtensionToolStripMenuItem, toolStripMenuItem2, helpToolStripMenuItem, aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(44, 20);
            aboutToolStripMenuItem.Text = "&Help";
            // 
            // createWindowsExplorerShellExtensionToolStripMenuItem
            // 
            createWindowsExplorerShellExtensionToolStripMenuItem.Name = "createWindowsExplorerShellExtensionToolStripMenuItem";
            createWindowsExplorerShellExtensionToolStripMenuItem.Size = new Size(107, 22);
            // 
            // removeWindowsExplorerShellExtensionToolStripMenuItem
            // 
            removeWindowsExplorerShellExtensionToolStripMenuItem.Name = "removeWindowsExplorerShellExtensionToolStripMenuItem";
            removeWindowsExplorerShellExtensionToolStripMenuItem.Size = new Size(107, 22);
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(104, 6);
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(107, 22);
            helpToolStripMenuItem.Text = "&Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(107, 22);
            aboutToolStripMenuItem1.Text = "&About";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // tmrRebuildManifest
            // 
            tmrRebuildManifest.Tick += tmrRebuildManifest_Tick;
            // 
            // btnAbout
            // 
            btnAbout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAbout.Location = new Point(518, 113);
            btnAbout.Margin = new Padding(4, 3, 4, 3);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(129, 23);
            btnAbout.TabIndex = 27;
            btnAbout.Text = "&About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnChange
            // 
            btnChange.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChange.Location = new Point(518, 9);
            btnChange.Margin = new Padding(4, 3, 4, 3);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(129, 46);
            btnChange.TabIndex = 25;
            btnChange.Text = "&Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += btnChange_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(518, 61);
            btnRefresh.Margin = new Padding(4, 3, 4, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(129, 46);
            btnRefresh.TabIndex = 26;
            btnRefresh.Text = "&Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // txtManifest
            // 
            txtManifest.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtManifest.Enabled = false;
            txtManifest.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtManifest.Location = new Point(13, 141);
            txtManifest.Margin = new Padding(4, 3, 4, 3);
            txtManifest.Multiline = true;
            txtManifest.Name = "txtManifest";
            txtManifest.ScrollBars = ScrollBars.Both;
            txtManifest.Size = new Size(634, 183);
            txtManifest.TabIndex = 28;
            txtManifest.WordWrap = false;
            txtManifest.KeyPress += txtManifest_KeyPress;
            // 
            // chkShowFolders
            // 
            chkShowFolders.AutoSize = true;
            chkShowFolders.Location = new Point(32, 63);
            chkShowFolders.Margin = new Padding(4, 3, 4, 3);
            chkShowFolders.Name = "chkShowFolders";
            chkShowFolders.Size = new Size(149, 19);
            chkShowFolders.TabIndex = 31;
            chkShowFolders.Text = "Show Subfolder Names";
            chkShowFolders.UseVisualStyleBackColor = true;
            chkShowFolders.CheckedChanged += chkShowFolders_CheckedChanged;
            // 
            // chkSeparateByTab
            // 
            chkSeparateByTab.AutoSize = true;
            chkSeparateByTab.Location = new Point(330, 117);
            chkSeparateByTab.Margin = new Padding(4, 3, 4, 3);
            chkSeparateByTab.Name = "chkSeparateByTab";
            chkSeparateByTab.Size = new Size(107, 19);
            chkSeparateByTab.TabIndex = 37;
            chkSeparateByTab.Text = "Separate by tab";
            chkSeparateByTab.UseVisualStyleBackColor = true;
            chkSeparateByTab.CheckedChanged += chkSeparateByTab_CheckedChanged;
            // 
            // chkIncludeTimeAndSize
            // 
            chkIncludeTimeAndSize.AutoSize = true;
            chkIncludeTimeAndSize.Location = new Point(32, 116);
            chkIncludeTimeAndSize.Margin = new Padding(4, 3, 4, 3);
            chkIncludeTimeAndSize.Name = "chkIncludeTimeAndSize";
            chkIncludeTimeAndSize.Size = new Size(140, 19);
            chkIncludeTimeAndSize.TabIndex = 33;
            chkIncludeTimeAndSize.Text = "Include Time and Size";
            chkIncludeTimeAndSize.UseVisualStyleBackColor = true;
            chkIncludeTimeAndSize.CheckedChanged += chkIncludeTimeAndSize_CheckedChanged;
            // 
            // rbFileNameOnly
            // 
            rbFileNameOnly.AutoSize = true;
            rbFileNameOnly.Enabled = false;
            rbFileNameOnly.Location = new Point(330, 90);
            rbFileNameOnly.Margin = new Padding(4, 3, 4, 3);
            rbFileNameOnly.Name = "rbFileNameOnly";
            rbFileNameOnly.Size = new Size(102, 19);
            rbFileNameOnly.TabIndex = 36;
            rbFileNameOnly.Text = "File name only";
            rbFileNameOnly.UseVisualStyleBackColor = true;
            // 
            // chkShowAssemblyVersion
            // 
            chkShowAssemblyVersion.AutoSize = true;
            chkShowAssemblyVersion.Location = new Point(32, 90);
            chkShowAssemblyVersion.Margin = new Padding(4, 3, 4, 3);
            chkShowAssemblyVersion.Name = "chkShowAssemblyVersion";
            chkShowAssemblyVersion.Size = new Size(176, 19);
            chkShowAssemblyVersion.TabIndex = 32;
            chkShowAssemblyVersion.Text = "Show Version for Assemblies";
            chkShowAssemblyVersion.UseVisualStyleBackColor = true;
            chkShowAssemblyVersion.CheckedChanged += chkShowAssemblyVersion_CheckedChanged;
            // 
            // txtStartingFolder
            // 
            txtStartingFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStartingFolder.Location = new Point(13, 12);
            txtStartingFolder.Margin = new Padding(4, 3, 4, 3);
            txtStartingFolder.Name = "txtStartingFolder";
            txtStartingFolder.Size = new Size(497, 23);
            txtStartingFolder.TabIndex = 29;
            // 
            // chkSubfolders
            // 
            chkSubfolders.AutoSize = true;
            chkSubfolders.Location = new Point(32, 39);
            chkSubfolders.Margin = new Padding(4, 3, 4, 3);
            chkSubfolders.Name = "chkSubfolders";
            chkSubfolders.Size = new Size(128, 19);
            chkSubfolders.TabIndex = 30;
            chkSubfolders.Text = "Recurse SubFolders";
            chkSubfolders.UseVisualStyleBackColor = true;
            chkSubfolders.CheckedChanged += chkSubfolders_CheckedChanged;
            // 
            // rbPathAsHeader
            // 
            rbPathAsHeader.AutoSize = true;
            rbPathAsHeader.Enabled = false;
            rbPathAsHeader.Location = new Point(330, 63);
            rbPathAsHeader.Margin = new Padding(4, 3, 4, 3);
            rbPathAsHeader.Name = "rbPathAsHeader";
            rbPathAsHeader.Size = new Size(133, 19);
            rbPathAsHeader.TabIndex = 35;
            rbPathAsHeader.Text = "Path as a header line";
            rbPathAsHeader.UseVisualStyleBackColor = true;
            rbPathAsHeader.CheckedChanged += rbPathAsHeader_CheckedChanged;
            // 
            // rbFullPath
            // 
            rbFullPath.AutoSize = true;
            rbFullPath.Checked = true;
            rbFullPath.Enabled = false;
            rbFullPath.Location = new Point(330, 38);
            rbFullPath.Margin = new Padding(4, 3, 4, 3);
            rbFullPath.Name = "rbFullPath";
            rbFullPath.Size = new Size(109, 19);
            rbFullPath.TabIndex = 34;
            rbFullPath.TabStop = true;
            rbFullPath.Text = "Full Path Listing";
            rbFullPath.UseVisualStyleBackColor = true;
            rbFullPath.CheckedChanged += rbFullPath_CheckedChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 334);
            Controls.Add(chkShowFolders);
            Controls.Add(chkSeparateByTab);
            Controls.Add(chkIncludeTimeAndSize);
            Controls.Add(rbFileNameOnly);
            Controls.Add(chkShowAssemblyVersion);
            Controls.Add(txtStartingFolder);
            Controls.Add(chkSubfolders);
            Controls.Add(rbPathAsHeader);
            Controls.Add(rbFullPath);
            Controls.Add(txtManifest);
            Controls.Add(btnAbout);
            Controls.Add(btnChange);
            Controls.Add(btnRefresh);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(676, 373);
            Name = "MainForm";
            Text = "Folder Manifest";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.Timer tmrRebuildManifest;
        private Button btnAbout;
        private Button btnChange;
        private Button btnRefresh;
        private TextBox txtManifest;
        private CheckBox chkShowFolders;
        private CheckBox chkSeparateByTab;
        private CheckBox chkIncludeTimeAndSize;
        private RadioButton rbFileNameOnly;
        private CheckBox chkShowAssemblyVersion;
        private TextBox txtStartingFolder;
        private CheckBox chkSubfolders;
        private RadioButton rbPathAsHeader;
        private RadioButton rbFullPath;
    }
}
