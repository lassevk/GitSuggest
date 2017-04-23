namespace GitSuggest.Windows.Controls
{
    partial class SuggestionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.paSpacing1 = new System.Windows.Forms.Panel();
            this.paActions = new System.Windows.Forms.Panel();
            this.paSeparator2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(4);
            this.lblTitle.Size = new System.Drawing.Size(115, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "<suggestion title>";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(0, 21);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(24, 4, 4, 4);
            this.lblDescription.Size = new System.Drawing.Size(152, 21);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "<suggestion description>";
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSeparator.Location = new System.Drawing.Point(0, 252);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(641, 2);
            this.lblSeparator.TabIndex = 3;
            // 
            // paSpacing1
            // 
            this.paSpacing1.Dock = System.Windows.Forms.DockStyle.Top;
            this.paSpacing1.Location = new System.Drawing.Point(0, 42);
            this.paSpacing1.Name = "paSpacing1";
            this.paSpacing1.Size = new System.Drawing.Size(641, 8);
            this.paSpacing1.TabIndex = 4;
            // 
            // paActions
            // 
            this.paActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.paActions.Location = new System.Drawing.Point(0, 50);
            this.paActions.Name = "paActions";
            this.paActions.Size = new System.Drawing.Size(641, 71);
            this.paActions.TabIndex = 5;
            // 
            // paSeparator2
            // 
            this.paSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.paSeparator2.Location = new System.Drawing.Point(0, 121);
            this.paSeparator2.Name = "paSeparator2";
            this.paSeparator2.Size = new System.Drawing.Size(641, 8);
            this.paSeparator2.TabIndex = 6;
            // 
            // SuggestionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paSeparator2);
            this.Controls.Add(this.paActions);
            this.Controls.Add(this.paSpacing1);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "SuggestionControl";
            this.Size = new System.Drawing.Size(641, 254);
            this.Resize += new System.EventHandler(this.SuggestionControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Panel paSpacing1;
        private System.Windows.Forms.Panel paActions;
        private System.Windows.Forms.Panel paSeparator2;
    }
}
