using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using BOG.SwissArmyKnife;

// Copyright (c) 2009-, John J Schultz, all rights reserved.
// May 2025: Upgrade to .NET 8

namespace BOG.FolderManifest
{
    public partial class AboutBox : Form
    {
        readonly WinAppInfo x = new WinAppInfo();

        public AboutBox()
        {
            InitializeComponent();
            var av = new AssemblyVersion(SwissArmyKnife.AssemblyVersion.AssemblySource.Entry);
            x.AssemblyVersion = av.Version;
            x.Copyright = AssemblyCopyright;
            x.Description = AssemblyDescription;
            x.Name = av.Name;
            x.ProductName = AssemblyProduct;
            x.Title = AssemblyTitle;
            x.Version = av.Version;

            this.pgInfo.SelectedObject = x;
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                var title = string.Empty;
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        title = titleAttribute.Title;
                    }
                }
                else title = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().GetName().Name);
                return title;
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "version ???";
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkHomePage.LinkVisited = true;
            System.Diagnostics.Process.Start(this.linkHomePage.Tag?.ToString() ?? string.Empty);
        }

        private void okButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    [DefaultPropertyAttribute("Description")]
    class WinAppInfo
    {
        private string _Title;
        private string _ProductName;
        private string _AssemblyVersion;
        private string _Copyright;
        private string _Description;

        private string _BuildDate;
        private string _FullPath;
        private string _Name;
        private string _Version;

        [CategoryAttribute("Admin"), DisplayNameAttribute("Title"), DescriptionAttribute("The title assigned to the project"), ReadOnly(true)]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        [CategoryAttribute("Admin"), DisplayNameAttribute("Product Name"), DescriptionAttribute("The name assigned to the project"), ReadOnly(true)]
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        [CategoryAttribute("Admin"), DisplayNameAttribute("Assembly Version"), DescriptionAttribute("The specific build number."), ReadOnly(true)]
        public string AssemblyVersion
        {
            get { return _AssemblyVersion; }
            set { _AssemblyVersion = value; }
        }

        [CategoryAttribute("Admin"), DisplayNameAttribute("Copyright"), DescriptionAttribute(""), ReadOnly(true)]
        public string Copyright
        {
            get { return _Copyright; }
            set { _Copyright = value; }
        }

        [CategoryAttribute("Admin"), DisplayNameAttribute("Description"), DescriptionAttribute(""), ReadOnly(true)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        [CategoryAttribute("Technical"), DisplayNameAttribute("Build Date"), DescriptionAttribute("Date this version was constructed."), ReadOnly(true)]
        public string BuildDate
        {
            get { return _BuildDate; }
            set { _BuildDate = value; }
        }

        [CategoryAttribute("Technical"), DisplayNameAttribute("Application Location"), DescriptionAttribute("The location of the specific executable running."), ReadOnly(true)]
        public string FullPath
        {
            get { return _FullPath; }
            set { _FullPath = value; }
        }

        [CategoryAttribute("Technical"), DisplayNameAttribute("Application Location"), DescriptionAttribute("The name stored within the executable itself."), ReadOnly(true)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        [CategoryAttribute("Technical"), DisplayNameAttribute("Version"), DescriptionAttribute("The file version of the executable."), ReadOnly(true)]
        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
    }
}
