namespace GitSuggest.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBrief = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.eRepositoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paSuggestions = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkBrief);
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnSelectFolder);
            this.panel1.Controls.Add(this.eRepositoryPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 85);
            this.panel1.TabIndex = 0;
            // 
            // chkBrief
            // 
            this.chkBrief.AutoSize = true;
            this.chkBrief.Location = new System.Drawing.Point(225, 56);
            this.chkBrief.Name = "chkBrief";
            this.chkBrief.Size = new System.Drawing.Size(109, 17);
            this.chkBrief.TabIndex = 5;
            this.chkBrief.Text = "Brief explanations";
            this.chkBrief.UseVisualStyleBackColor = true;
            this.chkBrief.CheckedChanged += new System.EventHandler(this.chkBrief_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(94, 56);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(125, 17);
            this.chkAll.TabIndex = 4;
            this.chkAll.Text = "Show all suggestions";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(13, 52);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Location = new System.Drawing.Point(677, 25);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(25, 21);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // eRepositoryPath
            // 
            this.eRepositoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eRepositoryPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.eRepositoryPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.eRepositoryPath.Location = new System.Drawing.Point(12, 25);
            this.eRepositoryPath.Name = "eRepositoryPath";
            this.eRepositoryPath.Size = new System.Drawing.Size(659, 20);
            this.eRepositoryPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path to repository / work folder";
            // 
            // paSuggestions
            // 
            this.paSuggestions.AutoScroll = true;
            this.paSuggestions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paSuggestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paSuggestions.Location = new System.Drawing.Point(0, 85);
            this.paSuggestions.Name = "paSuggestions";
            this.paSuggestions.Size = new System.Drawing.Size(714, 287);
            this.paSuggestions.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 372);
            this.Controls.Add(this.paSuggestions);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "GitSuggest v{0}";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox eRepositoryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel paSuggestions;
        private System.Windows.Forms.CheckBox chkBrief;
        private System.Windows.Forms.CheckBox chkAll;
    }
}

