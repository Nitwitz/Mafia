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
            this.EnterName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Confirm = new System.Windows.Forms.Button();
            this.EnterAdress = new System.Windows.Forms.Label();
            this.EnterPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.tb_adress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cansel
            // 
            this.Cansel.BackColor = System.Drawing.Color.White;
            this.Cansel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cansel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cansel.Location = new System.Drawing.Point(12, 442);
            this.Cansel.Name = "Cansel";
            this.Cansel.Size = new System.Drawing.Size(87, 23);
            this.Cansel.TabIndex = 7;
            this.Cansel.Text = "Назад";
            this.Cansel.UseVisualStyleBackColor = false;
            this.Cansel.Click += new System.EventHandler(this.Cansel_Click);
            // 
            // EnterName
            // 
            this.EnterName.BackColor = System.Drawing.Color.White;
            this.EnterName.Cursor = System.Windows.Forms.Cursors.No;
            this.EnterName.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterName.Location = new System.Drawing.Point(55, 9);
            this.EnterName.Name = "EnterName";
            this.EnterName.Size = new System.Drawing.Size(159, 24);
            this.EnterName.TabIndex = 0;
            this.EnterName.Text = "Введите Имя:";
            this.EnterName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(60, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Confirm
            // 
            this.Confirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Confirm.Location = new System.Drawing.Point(12, 175);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(87, 23);
            this.Confirm.TabIndex = 6;
            this.Confirm.Text = "Подтвердить";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Click += new System.EventHandler(this.Confirm_Click);
            // 
            // EnterAdress
            // 
            this.EnterAdress.BackColor = System.Drawing.Color.White;
            this.EnterAdress.Cursor = System.Windows.Forms.Cursors.No;
            this.EnterAdress.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterAdress.Location = new System.Drawing.Point(55, 59);
            this.EnterAdress.Name = "EnterAdress";
            this.EnterAdress.Size = new System.Drawing.Size(159, 24);
            this.EnterAdress.TabIndex = 2;
            this.EnterAdress.Text = "Введите Адресс:";
            this.EnterAdress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EnterPort
            // 
            this.EnterPort.BackColor = System.Drawing.Color.White;
            this.EnterPort.Cursor = System.Windows.Forms.Cursors.No;
            this.EnterPort.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterPort.Location = new System.Drawing.Point(55, 109);
            this.EnterPort.Name = "EnterPort";
            this.EnterPort.Size = new System.Drawing.Size(159, 24);
            this.EnterPort.TabIndex = 4;
            this.EnterPort.Text = "Введите Порт:";
            this.EnterPort.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(60, 136);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(143, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "1100";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_adress
            // 
            this.tb_adress.Location = new System.Drawing.Point(60, 86);
            this.tb_adress.Name = "tb_adress";
            this.tb_adress.Size = new System.Drawing.Size(143, 20);
            this.tb_adress.TabIndex = 8;
            this.tb_adress.Text = "127.0.0.1";
            // 
            // Play
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Mafia.Properties.Resources.GyMNem8KHsI;
            this.ClientSize = new System.Drawing.Size(278, 477);
            this.Controls.Add(this.tb_adress);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.EnterPort);
            this.Controls.Add(this.EnterAdress);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.EnterName);
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
        private System.Windows.Forms.Label EnterName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label EnterAdress;
        private System.Windows.Forms.Label EnterPort;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox tb_adress;
    }
}