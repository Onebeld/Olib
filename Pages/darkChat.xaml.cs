using Olib.ServiceReference1;
using System;
using System.Diagnostics;
using System.Net;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для darkChat.xaml
    /// </summary>
    public partial class darkChat : Page, IServiceChatCallback
    {
        private bool IsConnected = false;
        ServiceChatClient client;
        private int ID;

        public darkChat()
        {
            InitializeComponent();
            Core.Animations.AnimationText(Warning);
        }
        private void ConnectUser()
        {
            if (!IsConnected)
            {
                NetTcpBinding portsharingBinding = new NetTcpBinding(SecurityMode.None);
                portsharingBinding.PortSharingEnabled = true;
                client = new ServiceChatClient(new InstanceContext(this), portsharingBinding, new EndpointAddress($"net.tcp://{tbIPAdress.Text}:{tbHost.Text}"));
                ID = client.Connect(tbNick.Text, GetIP());
                tbNick.IsEnabled = false;
                tbIPAdress.IsEnabled = false;
                tbHost.IsEnabled = false;
                bConnected.Content = "Отключиться";
                IsConnected = true;
            }
        }
        private void DisconnectUser()
        {
            try
            {
                if (IsConnected)
                {
                    client.Disconnect(ID);
                }
            }
            catch (Exception)
            {
                Error.Content = "Хост больше не отвечает!";
            }
            client = null;
            tbNick.IsEnabled = true;
            tbIPAdress.IsEnabled = true;
            tbHost.IsEnabled = true;
            bConnected.Content = "Подключиться";
            IsConnected = false;
        }

        private void Connecting(object sender, RoutedEventArgs e)
        {
            Error.Content = string.Empty;
            if (IsConnected)
            {
                DisconnectUser();
            }
            else
            {
                ConnectUser();
            }
        }
        private void Message()
        {
            try
            {
                client.SendMessage(tbMessage.Text, ID);
            }
            catch
            {
                client = null;
                tbNick.IsEnabled = true;
                tbIPAdress.IsEnabled = true;
                tbHost.IsEnabled = true;
                bConnected.Content = "Подключиться";
                IsConnected = false;
                Error.Content = "Не удалось отправить сообщение, возмножно, хост был отключен";
            }
        }
        private static string GetIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Нет";
        }
        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    Message();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (client != null)
            {
                Message();
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);
            tbMessage.Text = string.Empty;
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }

        private void OpenHost(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("OlibHost.exe");
            }
            catch
            {
                Error.Content = "Не удалось открыть хост";
            }
        }
        private void Dis()
        {
            Error.Content = string.Empty;
            if (IsConnected)
            {
                DisconnectUser();
            }
        }
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Error.Content = string.Empty;
            if (IsConnected)
            {
                DisconnectUser();
            }
        }
    }
}
