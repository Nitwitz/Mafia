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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            buttoexit.BackColor = Color.Transparent;
            buttonabout.BackColor = Color.Transparent;
            buttonstart.BackColor = Color.Transparent;
            

        }

        private void buttoexit_Click(object sender, EventArgs e)
        {
            buttoexit.BackColor = Color.FromArgb(0, SystemColors.Control);
            this.Close();
        }

      
        
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
        private void start_play()
        {
            Play play = new Play();
            play.ShowDialog();
        }

        private void buttonstart_Click(object sender, EventArgs e)
        {
            //Sound.Play_fail();
            start_play();
                }

        private void buttonabout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Как играть?");
                

        }

       
    }
}
