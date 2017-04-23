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
            this.paToolbar = new System.Windows.Forms.Panel();
            this.chkWait = new System.Windows.Forms.CheckBox();
            this.chkBrief = new System.Windows.Forms.CheckBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnFetch = new System.Windows.Forms.Button();
            this.btnStatus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.eRepositoryPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.paSuggestions = new System.Windows.Forms.Panel();
            this.paRefreshing = new System.Windows.Forms.Panel();
            this.btnPrompt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.paToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.paToolbar);
            this.panel1.Controls.Add(this.btnSelectFolder);
            this.panel1.Controls.Add(this.eRepositoryPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 87);
            this.panel1.TabIndex = 0;
            // 
            // paToolbar
            // 
            this.paToolbar.Controls.Add(this.chkWait);
            this.paToolbar.Controls.Add(this.chkBrief);
            this.paToolbar.Controls.Add(this.chkAll);
            this.paToolbar.Controls.Add(this.btnPrompt);
            this.paToolbar.Controls.Add(this.btnFetch);
            this.paToolbar.Controls.Add(this.btnStatus);
            this.paToolbar.Controls.Add(this.btnRefresh);
            this.paToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paToolbar.Location = new System.Drawing.Point(0, 64);
            this.paToolbar.Name = "paToolbar";
            this.paToolbar.Size = new System.Drawing.Size(714, 23);
            this.paToolbar.TabIndex = 7;
            // 
            // chkWait
            // 
            this.chkWait.AutoSize = true;
            this.chkWait.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkWait.Location = new System.Drawing.Point(542, 0);
            this.chkWait.Name = "chkWait";
            this.chkWait.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.chkWait.Size = new System.Drawing.Size(183, 23);
            this.chkWait.TabIndex = 12;
            this.chkWait.Text = "Wait after successful commands";
            this.chkWait.UseVisualStyleBackColor = true;
            this.chkWait.CheckedChanged += new System.EventHandler(this.chkWait_CheckedChanged);
            // 
            // chkBrief
            // 
            this.chkBrief.AutoSize = true;
            this.chkBrief.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkBrief.Location = new System.Drawing.Point(429, 0);
            this.chkBrief.Name = "chkBrief";
            this.chkBrief.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.chkBrief.Size = new System.Drawing.Size(113, 23);
            this.chkBrief.TabIndex = 10;
            this.chkBrief.Text = "Brief explanations";
            this.chkBrief.UseVisualStyleBackColor = true;
            this.chkBrief.Click += new System.EventHandler(this.chkBrief_CheckedChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkAll.Location = new System.Drawing.Point(300, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.chkAll.Size = new System.Drawing.Size(129, 23);
            this.chkAll.TabIndex = 9;
            this.chkAll.Text = "Show all suggestions";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.Click += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnFetch
            // 
            this.btnFetch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFetch.Location = new System.Drawing.Point(150, 0);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(75, 23);
            this.btnFetch.TabIndex = 11;
            this.btnFetch.Text = "Fetch";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // btnStatus
            // 
            this.btnStatus.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStatus.Location = new System.Drawing.Point(75, 0);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(75, 23);
            this.btnStatus.TabIndex = 7;
            this.btnStatus.Text = "Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
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
            this.paSuggestions.Location = new System.Drawing.Point(0, 87);
            this.paSuggestions.Name = "paSuggestions";
            this.paSuggestions.Size = new System.Drawing.Size(714, 285);
            this.paSuggestions.TabIndex = 1;
            this.paSuggestions.LocationChanged += new System.EventHandler(this.paSuggestions_LocationChanged);
            this.paSuggestions.SizeChanged += new System.EventHandler(this.paSuggestions_SizeChanged);
            // 
            // paRefreshing
            // 
            this.paRefreshing.Location = new System.Drawing.Point(473, 260);
            this.paRefreshing.Name = "paRefreshing";
            this.paRefreshing.Size = new System.Drawing.Size(200, 100);
            this.paRefreshing.TabIndex = 0;
            this.paRefreshing.Visible = false;
            // 
            // btnPrompt
            // 
            this.btnPrompt.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPrompt.Location = new System.Drawing.Point(225, 0);
            this.btnPrompt.Name = "btnPrompt";
            this.btnPrompt.Size = new System.Drawing.Size(75, 23);
            this.btnPrompt.TabIndex = 13;
            this.btnPrompt.Text = "Prompt";
            this.btnPrompt.UseVisualStyleBackColor = true;
            this.btnPrompt.Click += new System.EventHandler(this.btnPrompt_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 372);
            this.Controls.Add(this.paRefreshing);
            this.Controls.Add(this.paSuggestions);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "GitSuggest v{0}";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.paToolbar.ResumeLayout(false);
            this.paToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox eRepositoryPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel paSuggestions;
        private System.Windows.Forms.Panel paToolbar;
        private System.Windows.Forms.CheckBox chkBrief;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.CheckBox chkWait;
        private System.Windows.Forms.Panel paRefreshing;
        private System.Windows.Forms.Button btnPrompt;
    }
}

