namespace Mafia
{
    partial class Play
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Play));
            this.Cansel = new System.Windows.Forms.Button();
            this.Enter = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cansel
            // 
            this.Cansel.BackColor = System.Drawing.Color.White;
            this.Cansel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cansel.Location = new System.Drawing.Point(3, 442);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(75, 23);
            this.Cansel.TabIndex = 0;
            this.Cansel.Text = "Cansel";
            this.Cansel.UseVisualStyleBackColor = false;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // Enter
            // 
            this.Enter.BackColor = System.Drawing.Color.White;
            this.Enter.Cursor = System.Windows.Forms.Cursors.No;
            this.Enter.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Enter.Location = new System.Drawing.Point(55, 60);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(159, 24);
            this.Enter.TabIndex = 1;
            this.Enter.Text = "Enter your name";
            this.Enter.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(12, 161);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(87, 23);
            this.Confirm.TabIndex = 3;
            this.Confirm.Text = "Confirm";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Mafia.Properties.Resources.GyMNem8KHsI;
            this.ClientSize = new System.Drawing.Size(278, 477);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Enter);
            this.Controls.Add(this.Cansel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Play";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mafia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cansel;
        private System.Windows.Forms.Label Enter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Confirm;
    }
}