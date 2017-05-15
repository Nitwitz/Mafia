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
           Close();

        }

      

        /// <summary>
        /// Открытие окна, с основной игрой
        /// </summary>
        private void start_lead()
        {
            Lead lead = new Lead();
            lead.ShowDialog();
        }
        /// <summary>
        /// Подтверждение о начале игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Confirm_Click(object sender, EventArgs e)
        {
            start_lead();
        }

      
    }
}
