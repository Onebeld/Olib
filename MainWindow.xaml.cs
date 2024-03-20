using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olib
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool OpenSideBar = false;
        private bool mRestoreForDragMove;
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (ResizeMode != ResizeMode.CanResize &&
                    ResizeMode != ResizeMode.CanResizeWithGrip)
                {
                    return;
                }

                WindowState = WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                mRestoreForDragMove = WindowState == WindowState.Maximized;
                DragMove();
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (mRestoreForDragMove)
            {
                mRestoreForDragMove = false;

                var point = PointToScreen(e.MouseDevice.GetPosition(this));

                Left = point.X * 0.5;
                Top = point.Y - 15;

                WindowState = WindowState.Normal;
                try
                {
                    DragMove();
                }
                catch { };
            }
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mRestoreForDragMove = false;
        }


        private void Full(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                FullMenu.Header = "Развернуть";
                WindowState = WindowState.Normal;
            }
            else
            {
                FullMenu.Header = "Восстановить";
                WindowState = WindowState.Maximized;
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
                frame.NavigationService.GoBack();
        }

        private void Navigated(object sender, NavigationEventArgs e)
        {
            textHeader.Content = ((Page)e.Content).Title;
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.5),
                DecelerationRatio = 1,
                From = 0,
                To = 1,
                
            };
            frame.BeginAnimation(OpacityProperty, anim);
        }

        private void Close(object sender, EventArgs e) => Application.Current.Shutdown();
        private void Hide(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void SideBar(object sender, RoutedEventArgs e) => HidenSideBar();

        private async void HidenSideBar()
        {
            GlobalButton.IsEnabled = false;
            var anim = new DoubleAnimation();
            var anim1 = new DoubleAnimation();
            anim.Duration = TimeSpan.FromSeconds(0.5);
            anim1.Duration = TimeSpan.FromSeconds(0.5);
            anim.DecelerationRatio = 1;
            anim1.DecelerationRatio = 1;
            if (!OpenSideBar)
            {
                anim.To = 260;
                anim1.To = 0.5;
                borderHide.Visibility = Visibility.Visible;
                borderHide.IsEnabled = true;
                Author.Text = Core.EasterEggs.Author;
            }
            else
            {
                anim.To = 0;
                anim1.To = 0;
                anim1.Completed += (s, e) => borderHide.Visibility = Visibility.Hidden;
                borderHide.IsEnabled = false;
            }
            sideBar.BeginAnimation(WidthProperty, anim);
            borderHide.BeginAnimation(OpacityProperty, anim1);
            OpenSideBar = !OpenSideBar;
            await Task.Delay(500);
            GlobalButton.IsEnabled = true;
        }
        private void ClickHideBorder(object sender, MouseButtonEventArgs e) => HidenSideBar();

        private void Autoclicker(object sender, RoutedEventArgs e)
        {
            new Windows.autoclicker().Show();
            HidenSideBar();
        }

        private void MainPage(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/main.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void DataParser(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/dataParser.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void Roulette(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/converter.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private async void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            cbThemes.SelectedValuePath = "Key";
            cbThemes.DisplayMemberPath = "Value";
            KeyValuePair<string, string>[] valuePair = new[]
            {
                new KeyValuePair<string, string>("Light","Светлая"),
                new KeyValuePair<string, string>("Dark","Темная"),
                new KeyValuePair<string, string>("SeaFoam","Морская пена"),
                new KeyValuePair<string, string>("Bloody", "Кровавый"),
                new KeyValuePair<string, string>("Aurora", "Аврорный")
            };
            foreach (var i in valuePair)
            {
                cbThemes.Items.Add(i);
            }
            cbThemes.SelectedIndex = valuePair.ToList().FindIndex(i => i.Key == Properties.Settings.Default.NameTheme);
            Version.Text = "Версия: " + Assembly.GetEntryAssembly().GetName().Version;
            await Core.Update.CheckUpdate(ButtUpdate);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                From = 1,
                To = 0
            };
            anim.Completed += Close;
            BeginAnimation(OpacityProperty, anim);
        }

        private void DarkChat(object sender, RoutedEventArgs e)
        {
            _ = frame.NavigationService.Navigate(new Uri("Pages/darkChat.xaml", UriKind.Relative));
            HidenSideBar();
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textHeader.Content.ToString() == "Dark Chat")
            {
                _ = frame.NavigationService.Navigate(new Uri("Pages/main.xaml", UriKind.Relative));
            }
        }

        private void LinkVK(object sender, RoutedEventArgs e) => Process.Start("https://vk.com/olib_app");
        private void LinkGitHub(object sender, RoutedEventArgs e) => Process.Start("https://github.com/BigBoss500/Olib");

        private void theme_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.IsDarkTheme = !Properties.Settings.Default.IsDarkTheme;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.IsDarkTheme)
            {
                var appTheme = Core.Themes.WindowsTheme.Dark.ToString();
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"/Themes/{appTheme}.xaml", UriKind.Relative);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"/Themes/Light.xaml", UriKind.Relative);
            }
        }

        private void cbThemes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.NameTheme = cbThemes.SelectedValue.ToString();
            Properties.Settings.Default.Save();
            Application.Current.Resources.MergedDictionaries[0].Source = new Uri($"/Themes/{Properties.Settings.Default.NameTheme}.xaml", UriKind.Relative);
        }
    }
}
