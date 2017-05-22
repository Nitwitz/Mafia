using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mafia
{
    /// <summary>
    /// Ввод имени и подтверждение вход в игру
    /// </summary>
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Возвращение в Меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();

        }

        public string UserName
        {
            get { return textBox1.Text; }
        }

        /// <summary>
        /// Подтверждение о начале игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Confirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }


    }
}
