using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OlibWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceChat" в коде и файле конфигурации.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        static List<ServerUser> users = new List<ServerUser>();
        public static List<string> messagers = new List<string>();
        private int nextID = 1;

        public int Connect(string name, string ip)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextID,
                Name = name,
                IP = ip,
                operationContext = OperationContext.Current
            };
            nextID++;
            SendMessage($": {user.Name} подключился к чату!", 0);
            users.Add(user);
            return user.ID;
        }

        public void Disconnect(int id)
        {
            var user = users.FirstOrDefault(i => i.ID == id);
            if (user != null)
            {
                users.Remove(user);
                SendMessage($": {user.Name} покинул чат!", 0);
            }
        }

        public void GetUsers()
        {
            foreach (var item in users)
            {
                Console.WriteLine($"ID: {item.ID}; Ник: {item.Name}; IP адрес: {item.IP}");
            }
        }

        public void SendMessage(string msg, int id)
        {
            string mess = "Нет";
            foreach (var u in users)
            {
                string answer = DateTime.Now.ToLongTimeString();
                var user = users.FirstOrDefault(i => i.ID == id);
                if (user != null)
                {
                    answer += $" {user.Name}: ";
                }
                answer += msg;

                mess = answer;
                u.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
            if (users.Count == 0)
            {
                mess = DateTime.Now.ToLongTimeString() + msg;
            }
            messagers.Add(mess);
        }
    }
}
