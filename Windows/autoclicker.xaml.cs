using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Olib.Windows
{
    /// <summary>
    /// Логика взаимодействия для autoclicker.xaml
    /// </summary>
    public partial class autoclicker : Window, IComponentConnector
    {
        public autoclicker()
        {
            InitializeComponent();
            Core.Animations.AnimationText(Warning);
        }
        private HwndSource source;
        private bool click;
        private static int time;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            source = HwndSource.FromHwnd(handle);
            source.AddHook(new HwndSourceHook(HwndHook));
            NativeMethods.RegisterHotKey(handle, 9000, 0U, 113U);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == 786 && wParam.ToInt32() == 9000)
            {
                if ((((int)lParam >> 16) & ushort.MaxValue) == 113)
                    ClickLeftMouseButtonMouseEvent();
                handled = true;
            }
            return IntPtr.Zero;
        }
        private void ClickLeftMouseButtonMouseEvent()
        {
            time = int.Parse(TextTime.Text);
            click = !click;
            new Thread(new ThreadStart(Clicker), 26214400).Start();
        }

        private void Clicker()
        {
            Dispatcher.Invoke(() => Title = "Autoclicker*");
            while (click)
            {
                Dispatcher.Invoke(() =>
                {
                    NativeMethods.mouse_event(2, 0, 0, 0, new WindowInteropHelper(this).Handle);
                    NativeMethods.mouse_event(4, 0, 0, 0, new WindowInteropHelper(this).Handle);
                });
                Thread.Sleep(time);
            }
            Dispatcher.Invoke(() => Title = "Autoclicker");
        }

        private void Changed(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(TextTime.Text, "[^0-9]"))
            {
                TextTime.Text = TextTime.Text.Remove(TextTime.Text.Length - 1);
                TextTime.SelectionStart = TextTime.Text.Length;
            }
        }

        private void Hide(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Drag(object sender, MouseButtonEventArgs e) => DragMove();
        private void Close(object sender, EventArgs e)
        {
            if (click)
            {
                click = !click;
            }
            Close();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                From = 1,
                To = 0
            };
            anim.Completed += Close;
            BeginAnimation(OpacityProperty, anim);
        }
    }

    class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, IntPtr dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
