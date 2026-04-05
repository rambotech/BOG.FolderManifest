namespace BOG.FolderManifest
{
    partial class AboutBox : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            linkHomePage = new LinkLabel();
            pgInfo = new PropertyGrid();
            okButton = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(-4, 0);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(linkHomePage);
            splitContainer1.Panel2.Controls.Add(pgInfo);
            splitContainer1.Panel2.Controls.Add(okButton);
            splitContainer1.Size = new Size(872, 278);
            splitContainer1.SplitterDistance = 238;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 33;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(4, 3);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(232, 271);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // linkHomePage
            // 
            linkHomePage.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linkHomePage.AutoSize = true;
            linkHomePage.Location = new Point(58, 255);
            linkHomePage.Margin = new Padding(4, 0, 4, 0);
            linkHomePage.Name = "linkHomePage";
            linkHomePage.Size = new Size(169, 15);
            linkHomePage.TabIndex = 45;
            linkHomePage.TabStop = true;
            linkHomePage.Tag = "https://www.bitsofgenius.com";
            linkHomePage.Text = "https://www.bitsofgenius.com";
            linkHomePage.LinkClicked += linkHomePage_LinkClicked;
            // 
            // pgInfo
            // 
            pgInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pgInfo.Location = new Point(4, 3);
            pgInfo.Margin = new Padding(4, 3, 4, 3);
            pgInfo.Name = "pgInfo";
            pgInfo.Size = new Size(622, 239);
            pgInfo.TabIndex = 44;
            pgInfo.ToolbarVisible = false;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.Cancel;
            okButton.Location = new Point(538, 249);
            okButton.Margin = new Padding(4, 3, 4, 3);
            okButton.Name = "okButton";
            okButton.Size = new Size(88, 25);
            okButton.TabIndex = 43;
            okButton.Text = "&OK";
            okButton.Click += okButton_Click_1;
            // 
            // AboutBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(868, 285);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(931, 686);
            MinimizeBox = false;
            MinimumSize = new Size(673, 311);
            Name = "AboutBox";
            Padding = new Padding(10, 10, 10, 10);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutBox";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.LinkLabel linkHomePage;
        private System.Windows.Forms.PropertyGrid pgInfo;
    }
}