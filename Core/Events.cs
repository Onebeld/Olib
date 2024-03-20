using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Olib.Core
{
    public partial class Events
    {
        private void Sound(object sender, RoutedEventArgs e)
        {
            using (var sound = new SoundPlayer(Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }
    }
    public partial class Events1
    {
        private void Sound(object sender, RoutedEventArgs e)
        {
            using (var sound = new SoundPlayer(Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }
    }
    public partial class Events2
    {
        private void Sound(object sender, RoutedEventArgs e)
        {
            using (var sound = new SoundPlayer(Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }
    }
    public partial class Events3
    {
        private void Sound(object sender, RoutedEventArgs e)
        {
            using (var sound = new SoundPlayer(Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }
    }
    public partial class Events4
    {
        private void Sound(object sender, RoutedEventArgs e)
        {
            using (var sound = new SoundPlayer(Properties.Resources.sound_click))
            {
                sound.Play();
            }
        }
    }
}
