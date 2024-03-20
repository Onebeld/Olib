using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using OlibWCF;
using System.Net;

namespace OlibHost
{
    class Program
    {
        private static bool IsOpen = false;
        static void Main(string[] args)
        {
            Console.Title = "Olib Host v1.0";
        Case:
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ваш порт (1-4 символа): ");
            string port = Console.ReadLine();
            string IP = GetIP();
            using (ServiceHost host = new ServiceHost(typeof(ServiceChat), new Uri($"net.tcp://{IP}:{port}")))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                host.Opened += (o, e) => Console.WriteLine($"Хост запущен! Используйте для подключении: {IP}:{port}\nДля просмотр комманд, напишите help");
                try
                {
                    host.Open();
                    IsOpen = true;
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Не удалось запустить хост, попробовать снова?[да;нет] - ");
                    var b = Console.ReadLine();
                    if (b == "да" || b == "Да")
                    {
                        goto Case;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n\\");
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "help":
                            Console.WriteLine(GetHelp());
                            break;
                        case "getusers":
                            ServiceChat chat = new ServiceChat();
                            chat.GetUsers();
                            break;
                        case "quit":
                            if (IsOpen)
                            {
                                Console.Write("Хост открыт, вы уверены, что хотите продолжить?[y;n] - ");
                                var f = Console.ReadLine();
                                if (f == "y" || f == "Y")
                                {
                                    host.Close();
                                    Environment.Exit(0);
                                }
                            }
                            break;
                        case "getmessagers":
                            foreach (var item in ServiceChat.messagers)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Нет такой команды!");
                            break;
                    }
                }
            };
        }
        private static string GetHelp()
        {
            return "--------Список команд:--------\n" +
                "help - список команд\n" +
                "getusers - список пользователей, подключенные на данный момент\n" +
                "getmessagers - список отправленных сообщени\n" +
                "quit - завершить хост";
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
            throw new Exception("Нет сетевых адаптеров с IPv4-адресом в системе!");
        }
    }
}
