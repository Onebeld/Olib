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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Olib.Windows
{
    /// <summary>
    /// Логика взаимодействия для rouletteFM_Rename.xaml
    /// </summary>
    public partial class rouletteFM_Rename : Window
    {
        public rouletteFM_Rename()
        {
            InitializeComponent();
            SelectItem.Text = Pages.ItemsS.Sourc;
            SelectItem.Focus();
            SelectItem.SelectionStart = SelectItem.Text.Length;
        }

        private void RenameVoid()
        {
            Pages.ItemsS.Sourc = SelectItem.Text;
            Close();
        }
        private void CloseWindow(object sender, EventArgs e) => RenameVoid();

        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private void DoubleAnimation_Completed(object sender, EventArgs e) => RenameVoid();

        private void SelectItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) RenameVoid();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                From = 1,
                To = 0
            };
            anim.Completed += CloseWindow;
            BeginAnimation(OpacityProperty, anim);
        }
    }
}
