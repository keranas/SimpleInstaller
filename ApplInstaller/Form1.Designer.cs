namespace ApplInstaller
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Install = new System.Windows.Forms.Button();
            this.UnInstall = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.Program1 = new System.Windows.Forms.TextBox();
            this.Version1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Install
            // 
            this.Install.BackColor = System.Drawing.SystemColors.Highlight;
            this.Install.Location = new System.Drawing.Point(560, 236);
            this.Install.Name = "Install";
            this.Install.Size = new System.Drawing.Size(191, 48);
            this.Install.TabIndex = 0;
            this.Install.Text = "Install";
            this.Install.UseVisualStyleBackColor = false;
            this.Install.Click += new System.EventHandler(this.Install_Click);
            // 
            // UnInstall
            // 
            this.UnInstall.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UnInstall.Location = new System.Drawing.Point(560, 308);
            this.UnInstall.Name = "UnInstall";
            this.UnInstall.Size = new System.Drawing.Size(191, 47);
            this.UnInstall.TabIndex = 1;
            this.UnInstall.Text = "UnInstall";
            this.UnInstall.UseVisualStyleBackColor = false;
            this.UnInstall.Click += new System.EventHandler(this.UnInstall_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(23, 64);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(655, 22);
            this.textBox.TabIndex = 2;
            this.textBox.Text = "c:\\Program Files\\akeramid\\MultiSpecNMR";
            // 
            // Program1
            // 
            this.Program1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Program1.Location = new System.Drawing.Point(28, 28);
            this.Program1.Name = "Program1";
            this.Program1.ReadOnly = true;
            this.Program1.Size = new System.Drawing.Size(361, 22);
            this.Program1.TabIndex = 3;
            // 
            // Version1
            // 
            this.Version1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Version1.Location = new System.Drawing.Point(424, 29);
            this.Version1.Name = "Version1";
            this.Version1.ReadOnly = true;
            this.Version1.Size = new System.Drawing.Size(152, 22);
            this.Version1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(830, 477);
            this.Controls.Add(this.Version1);
            this.Controls.Add(this.Program1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.UnInstall);
            this.Controls.Add(this.Install);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Installer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Install;
        private System.Windows.Forms.Button UnInstall;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox Program1;
        private System.Windows.Forms.TextBox Version1;
    }
}

