namespace Mafia
{
    partial class FormMenu
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.buttoexit = new System.Windows.Forms.Button();
            this.boxsound = new System.Windows.Forms.CheckBox();
            this.buttonstart = new System.Windows.Forms.Button();
            this.buttonabout = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.pnlGame = new System.Windows.Forms.Panel();
            this.LbRole = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.ListOfPlayers = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttoexit
            // 
            this.buttoexit.BackColor = System.Drawing.Color.Transparent;
            this.buttoexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttoexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoexit.ForeColor = System.Drawing.Color.Transparent;
            this.buttoexit.Location = new System.Drawing.Point(89, 387);
            this.buttoexit.Name = "buttoexit";
            this.buttoexit.Size = new System.Drawing.Size(87, 25);
            this.buttoexit.TabIndex = 1;
            this.buttoexit.UseVisualStyleBackColor = false;
            this.buttoexit.Click += new System.EventHandler(this.buttoexit_Click);
            // 
            // boxsound
            // 
            this.boxsound.AutoSize = true;
            this.boxsound.Checked = true;
            this.boxsound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.boxsound.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.boxsound.Location = new System.Drawing.Point(12, 407);
            this.boxsound.Name = "boxsound";
            this.boxsound.Size = new System.Drawing.Size(59, 20);
            this.boxsound.TabIndex = 2;
            this.boxsound.Text = "Звук";
            this.boxsound.UseVisualStyleBackColor = true;
            this.boxsound.CheckedChanged += new System.EventHandler(this.boxsound_CheckedChanged);
            // 
            // buttonstart
            // 
            this.buttonstart.BackColor = System.Drawing.Color.Transparent;
            this.buttonstart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonstart.ForeColor = System.Drawing.Color.Transparent;
            this.buttonstart.Location = new System.Drawing.Point(89, 278);
            this.buttonstart.Name = "buttonstart";
            this.buttonstart.Size = new System.Drawing.Size(87, 23);
            this.buttonstart.TabIndex = 3;
            this.buttonstart.UseVisualStyleBackColor = false;
            this.buttonstart.Click += new System.EventHandler(this.buttonstart_Click);
            // 
            // buttonabout
            // 
            this.buttonabout.BackColor = System.Drawing.Color.Transparent;
            this.buttonabout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonabout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonabout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonabout.ForeColor = System.Drawing.Color.Transparent;
            this.buttonabout.Location = new System.Drawing.Point(89, 331);
            this.buttonabout.Name = "buttonabout";
            this.buttonabout.Size = new System.Drawing.Size(87, 23);
            this.buttonabout.TabIndex = 4;
            this.buttonabout.UseVisualStyleBackColor = false;
            this.buttonabout.Click += new System.EventHandler(this.buttonabout_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.Transparent;
            this.btnStart.Location = new System.Drawing.Point(89, 220);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(87, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.Red;
            this.pnlGame.BackgroundImage = global::Mafia.Properties.Resources.GyMNem8KHsI;
            this.pnlGame.Controls.Add(this.LbRole);
            this.pnlGame.Controls.Add(this.btnInfo);
            this.pnlGame.Controls.Add(this.ListOfPlayers);
            this.pnlGame.Controls.Add(this.btnOk);
            this.pnlGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlGame.Location = new System.Drawing.Point(-4, -5);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(270, 448);
            this.pnlGame.TabIndex = 7;
            // 
            // LbRole
            // 
            this.LbRole.BackColor = System.Drawing.Color.Transparent;
            this.LbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbRole.ForeColor = System.Drawing.Color.Black;
            this.LbRole.Location = new System.Drawing.Point(16, 17);
            this.LbRole.Name = "LbRole";
            this.LbRole.Size = new System.Drawing.Size(102, 34);
            this.LbRole.TabIndex = 3;
            this.LbRole.Text = "Ваша Роль";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.White;
            this.btnInfo.BackgroundImage = global::Mafia.Properties.Resources.question1;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInfo.Location = new System.Drawing.Point(225, 16);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(36, 34);
            this.btnInfo.TabIndex = 2;
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // ListOfPlayers
            // 
            this.ListOfPlayers.FormattingEnabled = true;
            this.ListOfPlayers.Location = new System.Drawing.Point(41, 80);
            this.ListOfPlayers.Name = "ListOfPlayers";
            this.ListOfPlayers.Size = new System.Drawing.Size(191, 290);
            this.ListOfPlayers.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(186, 393);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Выбрать";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Mafia.Properties.Resources.tb_ObQ2v3ww;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(262, 439);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.buttonabout);
            this.Controls.Add(this.buttonstart);
            this.Controls.Add(this.boxsound);
            this.Controls.Add(this.buttoexit);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mafia";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.pnlGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttoexit;
        private System.Windows.Forms.CheckBox boxsound;
        private System.Windows.Forms.Button buttonstart;
        private System.Windows.Forms.Button buttonabout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListBox ListOfPlayers;
        private System.Windows.Forms.Label LbRole;
        private System.Windows.Forms.Button btnInfo;
    }
}

