using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Olib.Windows
{
    /// <summary>
    /// Логика взаимодействия для screamer.xaml
    /// </summary>
    public partial class screamer : Window
    {
        public screamer()
        {
            InitializeComponent();
            CloseProgram();
        }
        private async void CloseProgram()
        {
            await Task.Delay(5000);
            Application.Current.Shutdown();
        }
    }
}
