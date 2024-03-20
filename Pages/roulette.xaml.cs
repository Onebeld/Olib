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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для roulette.xaml
    /// </summary>
    public partial class roulette : Page
    {
        public roulette()
        {
            InitializeComponent();
            Var.Content = Local.Local.RandomStringOptions + a.Length;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/rouletteFM.xaml", UriKind.Relative));

        private readonly string[] a =
            {
                "Повiсточка на бан",
                "Photoshop",
                "Тёрка за $6999",
                "Калыван",
                "Шанс на повтор рулетки",
                "Решётка",
                "Шанс найти в жизни девушку/парня",
                "Подарок ВК",
                "50 рублей",
                "Самый крутой смартфон",
                "Защита от DDoS-аттаки на телефон",
                "Удача в жизни",
                "Счастье в жизни",
                "DDoS телефона",
                "10 000 подписчиков на YouTube",
                "100 000 подписчиков на YouTube",
                "Алаеро",
                "Баги в программах и играх",
                "1 000 000 подписчиков на YouTube",
                "Критическая ошибка",
                "Инструкция \"Как поднять бабла\"",
                "Не учиться",
                "Орёл",
                "Ничего",
                "Очередная функция в программе Olib",
                "По ОГЭ/ЕГЭ на отлично",
                "Пинок",
                "Лицензия на Minecraft",
                "Котёнок",
                "Много денег",
                "Python, потому что почему-бы и нет",
                "С#, очень прикольный язык, кстати",
                "Повiстка в армию",
                "Face",
                "Windows 10",
                "Премиум аккаунт",
                "Мажорные предметы в играх",
                "Музыка",
                "PHP, теперь вы — домохозяйка",
                "Посмотреть сериал",
                "Canyon",
                "Gnome",
                "Посмотри сериал/фильм, шо ты сидишь на компе",
                "Мощный компьютер",
                "Lamborgini",
                "BMW",
                "Какая-нибудь игра",
                "Google",
                "Лицензия на какую-нибудь игру",
                "Красивые картинки в интернете",
                "Samsung Galaxy",
                "Пинболл",
                "Отряд",
                "Диспетчер задач",
                "Audi",
                "Будущее"
            };
        private void RdmClear(object sender, RoutedEventArgs e) => RdmGlobal.Text = Local.Local.RandomTextBoxRdmGlobal;
        private void Rename(object sender, RoutedEventArgs e) => NameR();

        private void NameR() => NameL.Content = Local.Local.RandomStringName2 + name.Text;

        private async void RandomObject(object sender, RoutedEventArgs e)
        {
            RdmGlobal.Text = Local.Local.RandomButtonTwistExpectation;
            await Task.Delay(1000).ConfigureAwait(true);
            RdmGlobal.Text = Local.Local.RandomButtonTwistOut + Environment.NewLine + a[new Random().Next(0, a.Length)];
        }

        private void Name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                NameR();
        }
    }
}
