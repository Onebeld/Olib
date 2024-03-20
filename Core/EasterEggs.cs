using System;
using System.Windows;
using System.Windows.Controls;

namespace Olib.Core
{
    internal static class EasterEggs
    {
        private static readonly string data = DateTime.Now.ToString("dd.MM");
        public static string Author => new Random().Next(0, 10) < 1 ? "Автор: Дмитрий Мирзоян" : "Автор: Дмитрий Жутков";
        public static Visibility Image => "02.09" == data ? Visibility.Visible : Visibility.Hidden;
        public static void DisplayEgg(Label l)
        {
            switch (data)
            {
                case "19.02":
                    l.Content = "У автора сегодня день рождения!";
                    break;
                case "15.04":
                    l.Content = "Потерян такой великий собор...";
                    break;
                case "26.03":
                    l.Content = "В этот день появилась программа";
                    break;
                case "01.09":
                    l.Content = "Всех с днём знании!";
                    break;
                case "01.01":
                    l.Content = "Всех с новым годом!";
                    break;
                case "20.07":
                    l.Content = "Именно в этот день программа вышла в релиз";
                    break;
            }
            if (new Random().Next(10000) < 1)
                l.Content = "Ого! Удача на вашей стороне!";
        }
    }
}
