namespace Mafia
{
    partial class Lead
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
            this.Info = new System.Windows.Forms.Button();
            this.List = new System.Windows.Forms.ListBox();
            this.buttonyes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(228, 12);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(38, 37);
            this.Info.TabIndex = 0;
            this.Info.Text = "Info";
            this.Info.UseVisualStyleBackColor = true;
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // List
            // 
            this.List.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List.BackColor = System.Drawing.Color.White;
            this.List.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.List.Font = new System.Drawing.Font("Monotype Corsiva", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.List.FormattingEnabled = true;
            this.List.ItemHeight = 28;
            this.List.Location = new System.Drawing.Point(46, 77);
            this.List.Name = "List";
            this.List.Size = new System.Drawing.Size(181, 282);
            this.List.TabIndex = 1;
            // 
            // buttonyes
            // 
            this.buttonyes.Location = new System.Drawing.Point(170, 442);
            this.buttonyes.Name = "buttonyes";
            this.buttonyes.Size = new System.Drawing.Size(96, 23);
            this.buttonyes.TabIndex = 2;
            this.buttonyes.Text = "Yes";
            this.buttonyes.UseVisualStyleBackColor = true;
            // 
            // Lead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(278, 477);
            this.Controls.Add(this.buttonyes);
            this.Controls.Add(this.List);
            this.Controls.Add(this.Info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lead";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lead";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Info;
        private System.Windows.Forms.ListBox List;
        private System.Windows.Forms.Button buttonyes;
    }
}