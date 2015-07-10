namespace Launcher
{
    partial class frmMain
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
            this.btnCheckFolder = new System.Windows.Forms.Button();
            this.btnCheckOnline = new System.Windows.Forms.Button();
            this.lblLocalVer = new System.Windows.Forms.Label();
            this.lblOnlineVer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCheckFolder
            // 
            this.btnCheckFolder.Location = new System.Drawing.Point(33, 22);
            this.btnCheckFolder.Name = "btnCheckFolder";
            this.btnCheckFolder.Size = new System.Drawing.Size(119, 23);
            this.btnCheckFolder.TabIndex = 0;
            this.btnCheckFolder.Text = "check folder";
            this.btnCheckFolder.UseVisualStyleBackColor = true;
            this.btnCheckFolder.Click += new System.EventHandler(this.btnCheckFolder_Click);
            // 
            // btnCheckOnline
            // 
            this.btnCheckOnline.Location = new System.Drawing.Point(33, 92);
            this.btnCheckOnline.Name = "btnCheckOnline";
            this.btnCheckOnline.Size = new System.Drawing.Size(119, 23);
            this.btnCheckOnline.TabIndex = 1;
            this.btnCheckOnline.Text = "check online";
            this.btnCheckOnline.UseVisualStyleBackColor = true;
            this.btnCheckOnline.Click += new System.EventHandler(this.btnCheckOnline_Click);
            // 
            // lblLocalVer
            // 
            this.lblLocalVer.AutoSize = true;
            this.lblLocalVer.Location = new System.Drawing.Point(243, 31);
            this.lblLocalVer.Name = "lblLocalVer";
            this.lblLocalVer.Size = new System.Drawing.Size(129, 13);
            this.lblLocalVer.TabIndex = 2;
            this.lblLocalVer.Text = "Checking for local version";
            // 
            // lblOnlineVer
            // 
            this.lblOnlineVer.AutoSize = true;
            this.lblOnlineVer.Location = new System.Drawing.Point(246, 101);
            this.lblOnlineVer.Name = "lblOnlineVer";
            this.lblOnlineVer.Size = new System.Drawing.Size(120, 13);
            this.lblOnlineVer.TabIndex = 3;
            this.lblOnlineVer.Text = "Checking online version";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 158);
            this.Controls.Add(this.lblOnlineVer);
            this.Controls.Add(this.lblLocalVer);
            this.Controls.Add(this.btnCheckOnline);
            this.Controls.Add(this.btnCheckFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckFolder;
        private System.Windows.Forms.Button btnCheckOnline;
        private System.Windows.Forms.Label lblLocalVer;
        private System.Windows.Forms.Label lblOnlineVer;
    }
}

