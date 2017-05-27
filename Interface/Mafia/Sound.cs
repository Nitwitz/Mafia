using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Mafia
{
 /// <summary>
 /// Проигрование звука
 /// </summary>
     static class Sound
    {
        /// <summary>
        /// Экземпляр класса поигрования звука 
        /// </summary>
        static SoundPlayer _soundfail = new SoundPlayer(Properties.Resources.rag_n_bone_man_human_mp3_cc_);
        static bool sound_enabled = true;
        /// <summary>
        /// Включение звука
        /// </summary>
        public static void sound_on()
        {
            sound_enabled = true;
        }
        /// <summary>
        /// Выключение звука 
        /// </summary>
        public static void sound_off()
        {
            sound_enabled = false;
        }
        /// <summary>
        /// Воспроизведение звука
        /// </summary>
        public static void Play_fail()
        {
            if(sound_enabled)
            _soundfail.Play();
        }
    }
}
