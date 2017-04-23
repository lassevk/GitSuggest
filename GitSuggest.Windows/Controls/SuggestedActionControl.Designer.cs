namespace GitSuggest.Windows.Controls
{
    partial class SuggestedActionControl
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.paCommands = new System.Windows.Forms.Panel();
            this.lblCommands = new System.Windows.Forms.Label();
            this.paCommands.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(23, 3);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(104, 8);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(102, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "<action description>";
            // 
            // paCommands
            // 
            this.paCommands.BackColor = System.Drawing.Color.Black;
            this.paCommands.Controls.Add(this.lblCommands);
            this.paCommands.Location = new System.Drawing.Point(107, 29);
            this.paCommands.Name = "paCommands";
            this.paCommands.Size = new System.Drawing.Size(350, 47);
            this.paCommands.TabIndex = 3;
            // 
            // lblCommands
            // 
            this.lblCommands.AutoSize = true;
            this.lblCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommands.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommands.ForeColor = System.Drawing.Color.White;
            this.lblCommands.Location = new System.Drawing.Point(0, 0);
            this.lblCommands.Name = "lblCommands";
            this.lblCommands.Size = new System.Drawing.Size(189, 38);
            this.lblCommands.TabIndex = 0;
            this.lblCommands.Text = "git status\r\ngit commit -m \"Test\"";
            // 
            // SuggestedActionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paCommands);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnExecute);
            this.Name = "SuggestedActionControl";
            this.Size = new System.Drawing.Size(457, 86);
            this.SizeChanged += new System.EventHandler(this.SuggestedActionControl_SizeChanged);
            this.paCommands.ResumeLayout(false);
            this.paCommands.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel paCommands;
        private System.Windows.Forms.Label lblCommands;
    }
}
