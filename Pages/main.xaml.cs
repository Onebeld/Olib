using Olib.Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent();
            TopSecret.Visibility = EasterEggs.Image;
            EasterEggs.DisplayEgg(SecretText);
            Animations.AnimationText(Warning);
            if (DateTime.Now.ToString("dd.MM") == "31.10")
            {
                if (Properties.Settings.Default.TopSecret)
                {
                    Halloween.Visibility = Visibility.Visible;
                }
            }
        }
        private void dataParser(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
        private void Roulette(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
        private void Button_Click(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
        private void Autoclicker(object sender, RoutedEventArgs e) => new Windows.autoclicker().Show();
        private void DarkChat(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/darkChat.xaml", UriKind.Relative));

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.TopSecret = false;
            new Windows.screamer().Show();
        }
    }
}
