
namespace pengkar_laura
{
    partial class Fdash
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
            this.tuser = new System.Windows.Forms.Button();
            this.trole = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlkonten = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.tuser);
            this.panel1.Controls.Add(this.trole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 350);
            this.panel1.TabIndex = 3;
            // 
            // tuser
            // 
            this.tuser.Location = new System.Drawing.Point(29, 83);
            this.tuser.Name = "tuser";
            this.tuser.Size = new System.Drawing.Size(135, 40);
            this.tuser.TabIndex = 1;
            this.tuser.Text = "User";
            this.tuser.UseVisualStyleBackColor = true;
            // 
            // trole
            // 
            this.trole.Location = new System.Drawing.Point(29, 36);
            this.trole.Name = "trole";
            this.trole.Size = new System.Drawing.Size(135, 41);
            this.trole.TabIndex = 0;
            this.trole.Text = "Role";
            this.trole.UseVisualStyleBackColor = true;
            this.trole.Click += new System.EventHandler(this.trole_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 100);
            this.panel2.TabIndex = 4;
            // 
            // pnlkonten
            // 
            this.pnlkonten.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlkonten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlkonten.Location = new System.Drawing.Point(0, 0);
            this.pnlkonten.Name = "pnlkonten";
            this.pnlkonten.Size = new System.Drawing.Size(800, 450);
            this.pnlkonten.TabIndex = 5;
            // 
            // Fdash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlkonten);
            this.Name = "Fdash";
            this.Text = "Fdash";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button tuser;
        private System.Windows.Forms.Button trole;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlkonten;
    }
}