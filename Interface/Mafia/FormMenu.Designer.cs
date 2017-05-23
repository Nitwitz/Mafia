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
            this.SuspendLayout();
            // 
            // buttoexit
            // 
            this.buttoexit.BackColor = System.Drawing.Color.Transparent;
            this.buttoexit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttoexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttoexit.Font = new System.Drawing.Font("French Script MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttoexit.ForeColor = System.Drawing.Color.Transparent;
            this.buttoexit.Location = new System.Drawing.Point(89, 328);
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
            this.buttonstart.Font = new System.Drawing.Font("French Script MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonstart.ForeColor = System.Drawing.Color.Transparent;
            this.buttonstart.Location = new System.Drawing.Point(89, 215);
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
            this.buttonabout.Font = new System.Drawing.Font("French Script MT", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonabout.ForeColor = System.Drawing.Color.Transparent;
            this.buttonabout.Location = new System.Drawing.Point(89, 272);
            this.buttonabout.Name = "buttonabout";
            this.buttonabout.Size = new System.Drawing.Size(87, 23);
            this.buttonabout.TabIndex = 4;
            this.buttonabout.UseVisualStyleBackColor = false;
            this.buttonabout.Click += new System.EventHandler(this.buttonabout_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(78, 186);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(98, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Mafia.Properties.Resources.gJVkm2hr1r8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(262, 439);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttoexit;
        private System.Windows.Forms.CheckBox boxsound;
        private System.Windows.Forms.Button buttonstart;
        private System.Windows.Forms.Button buttonabout;
        private System.Windows.Forms.Button btnStart;
    }
}

