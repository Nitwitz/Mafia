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
    /// Меню, окрывается при запуске
    /// </summary>
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            buttoexit.BackColor = Color.Transparent;
            buttonabout.BackColor = Color.Transparent;
            buttonstart.BackColor = Color.Transparent;


        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttoexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Включение и выключение звука
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxsound_CheckedChanged(object sender, EventArgs e)
        {
            if (boxsound.Checked)
            {
                Sound.sound_on();
                boxsound.Text = "Звук";

            }
            else
            {
                Sound.sound_off();
                boxsound.Text = "Без звука";
            }
        }

        /// <summary>
        /// Открытие формы Play
        /// </summary>
        private void start_play()
        {
            Play play = new Play();
            if (play.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                //play.UserName
            }




        }
        /// <summary>
        /// Кнопка запуска игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonstart_Click(object sender, EventArgs e)
        {

            //Sound.Play_fail();
            start_play();
        }
        /// <summary>
        /// Кнопка информации об игре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonabout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Данное приложение созданно для замены ведущего в игре мафия  ", "Информация о игре", MessageBoxButtons.OK);



        }


    }
}
