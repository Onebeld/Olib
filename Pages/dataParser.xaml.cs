using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Xml;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для dataParser.xaml
    /// </summary>
    public partial class dataParser : Page
    {
        public dataParser()
        {
            InitializeComponent();
            Combo.SelectedIndex = 0;
            Core.Animations.AnimationText(Warning);
        }

        private async void Parsing(object sender, RoutedEventArgs e)
        {
            Bar.IsIndeterminate = true;
            Completed.Content = null;
            if (ValueText.Text == "")
            {
                ParseX.Text = Local.Local.ParseXMLNoParse;
                Bar.IsIndeterminate = false;
                return;
            }

            Parser.ID_and_IP = ValueText.Text;

            switch (Combo.SelectedIndex)
            {
                case 0:
                    ParseX.Text = await Parser.VKData();
                    break;
                case 1:
                    ParseX.Text = await Parser.IPParsing();
                    break;
                case 2:
                    ParseX.Text = await Parser.PhoneNumber();
                    break;
            }
            Bar.IsIndeterminate = false;
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Combo.SelectedIndex)
            {
                case 0:
                    LText.Content = "ID Вконтакте:";
                    break;
                case 1:
                    LText.Content = "IP адрес:";
                    break;
                case 2:
                    LText.Content = "Номер телефона:";
                    break;
            }
        }

        private void Clear(object sender, RoutedEventArgs e) => ParseX.Clear();

        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (ParseX.Text == "")
            {
                ParseX.Text = Local.Local.ParseXMLNoList;
                return;
            }
            SaveFileDialog save = new SaveFileDialog { Filter = "TXT-files (*.txt)|*.txt" };
            if ((bool)save.ShowDialog())
            {
                using (StreamWriter stream = new StreamWriter(save.FileName, false))
                {
                    stream.WriteLine(ParseX.Text);
                }
            }
            Completed.Content = Local.Local.ParseXMLListSave;
        }

        private void TextCh(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(ValueText.Text, "[^0-9-.]"))
            {
                ValueText.Text = ValueText.Text.Remove(ValueText.Text.Length - 1);
                ValueText.SelectionStart = ValueText.Text.Length;
            }
        }
    }
    public static class Parser
    {
        public static string ID_and_IP { get; set; }
        private static string s;

        public static async Task<string> VKData()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                await Task.Run(() => doc.Load("https://vk.com/foaf.php?id=" + ID_and_IP));
            }
            catch
            {
                return "Проверьте подключение к интернету, чтобы использовать эту функцию";
            }
            XmlNamespaceManager objNSMan = new XmlNamespaceManager(doc.NameTable);
            objNSMan.AddNamespace("foaf", "http://xmlns.com/foaf/0.1/");
            objNSMan.AddNamespace("ya", "http://blogs.yandex.ru/schema/foaf/");
            objNSMan.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            objNSMan.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
            string NameText, created, modifed, weblock, bdata, Out, sub, fr, gen, land, city, inter, site, bio, title, nick, stat;
            string line = Environment.NewLine, notext = Local.LocalParser.StringNo;
            try//пользователь
            {
                XmlNode NameP = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:name", objNSMan);
                NameText = Local.LocalParser.StringPerson + NameP.InnerText + line;
            }
            catch
            {
                return Local.LocalParser.StringNoPerson + line;
            }
            try//дата создания страницы
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:created/@dc:date", objNSMan);
                created = Local.LocalParser.StringPage + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                created = Local.LocalParser.StringPage + notext + line;
            }
            try//дата изменения
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:modified/@dc:date", objNSMan);
                modifed = Local.LocalParser.StringPageChanged + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                modifed = Local.LocalParser.StringPageChanged + notext + line;
            }
            try//последний вход
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:lastLoggedIn/@dc:date", objNSMan);
                Out = Local.LocalParser.StringLastOnline + pars.InnerText.Replace("T", " | ").Replace("-", ".").Replace("+03:00", "") + line;
            }
            catch
            {
                Out = Local.LocalParser.StringLastOnline + notext + line;
            }
            try//ссылка на страницу
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@rdf:resource", objNSMan);
                weblock = Local.LocalParser.StringLink + pars.InnerText + line;
            }
            catch
            {
                weblock = Local.LocalParser.StringLink + notext + line;
            }
            try//день рождение
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:dateOfBirth", objNSMan);
                bdata = Local.LocalParser.StringDateOfBirth + pars.InnerText.Replace("-", ".") + line;
            }
            catch
            {
                bdata = Local.LocalParser.StringDateOfBirth + notext + line;
            }
            try//кол-во подписчиков
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:subscribersCount", objNSMan);
                sub = Local.LocalParser.StringNumberSubs + pars.InnerText + line;
            }
            catch
            {
                sub = Local.LocalParser.StringNumberSubs + notext + line;
            }
            try//кол-во друзей
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:friendsCount", objNSMan);
                fr = Local.LocalParser.StringFriends + pars.InnerText + line;
            }
            catch
            {
                fr = Local.LocalParser.StringFriends + notext + line;
            }
            try//пол
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:gender", objNSMan);
                gen = Local.LocalParser.StringFloor + pars.InnerText + line;
            }
            catch
            {
                gen = Local.LocalParser.StringFloor + notext + line;
            }
            try//страна
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:country", objNSMan);
                land = Local.LocalParser.StringCountry + pars.InnerText + line;
            }
            catch
            {
                land = Local.LocalParser.StringCountry + notext + line;
            }
            try//город
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:location/@ya:city", objNSMan);
                city = Local.LocalParser.StringCity + pars.InnerText + line;
            }
            catch
            {
                city = Local.LocalParser.StringCity + notext + line;
            }
            try//характеристики
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:interest", objNSMan);
                inter = pars.InnerText + line;
            }
            catch
            {
                inter = Local.LocalParser.StringSpecification + notext + line;
            }
            try//сайт
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:homepage", objNSMan);
                site = Local.LocalParser.StringSite + pars.InnerText + line;
            }
            catch
            {
                site = Local.LocalParser.StringSite + notext + line;
            }
            try//о себе
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:bio", objNSMan);
                bio = Local.LocalParser.StringAbout + pars.InnerText + line;
            }
            catch
            {
                bio = Local.LocalParser.StringAbout + notext + line;
            }
            try//статус
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:weblog/@dc:title", objNSMan);
                title = $"{Local.LocalParser.StringStatus}{pars.InnerText}" + line;
            }
            catch
            {
                title = Local.LocalParser.StringStatus + notext + line;
            }
            try//ник
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/foaf:nick", objNSMan);
                nick = $"{Local.LocalParser.StringNick}{pars.InnerText}" + line;
            }
            catch
            {
                nick = Local.LocalParser.StringNick + notext + line;
            }
            try//статус профиля
            {
                XmlNode pars = doc.DocumentElement.SelectSingleNode("foaf:Person/ya:profileState", objNSMan);
                stat = $"{Local.LocalParser.StringProfileStatus}{pars.InnerText}" + line;
            }
            catch
            {
                stat = Local.LocalParser.StringProfileStatus + notext + line;
            }
            return NameText + nick + stat + weblock + created + modifed + Out + gen + bdata + sub + fr + land + city + site + title + inter + bio;
        }
        public static async Task<string> IPParsing()
        {
            try
            {
                string country, sity, region, continent, latitude, longitude, timezone, org, isp, currency;
                string line = Environment.NewLine;

                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://free.ipwhois.io/xml/{ID_and_IP}?lang={Local.LocalParser.LinkIPAdress}"));
                }
                country = Local.LocalParser.StringCountry + Regex.Match(s, "<country>(.*?)</country>").Groups[1].Value + line;
                sity = Local.LocalParser.StringCity + Regex.Match(s, "<city>(.*?)</city>").Groups[1].Value + line;
                region = Local.LocalParser.Region + Regex.Match(s, "<region>(.*?)</region>").Groups[1].Value + line;
                continent = Local.LocalParser.Continent + Regex.Match(s, "<continent>(.*?)</continent>").Groups[1].Value + line;
                latitude = Local.LocalParser.Width + Regex.Match(s, "<latitude>(.*?)</latitude>").Groups[1].Value + line;
                longitude = Local.LocalParser.Longitude + Regex.Match(s, "<longitude>(.*?)</longitude>").Groups[1].Value + line;
                timezone = Local.LocalParser.Timezone + Regex.Match(s, "<timezone_gmt>(.*?)</timezone_gmt>").Groups[1].Value + line;
                org = Local.LocalParser.Organization + Regex.Match(s, "<org>(.*?)</org>").Groups[1].Value + line;
                isp = Local.LocalParser.InternetServiceProvider + Regex.Match(s, "<isp>(.*?)</isp>").Groups[1].Value + line;
                currency = Local.LocalParser.Currency + Regex.Match(s, "<currency>(.*?)</currency>").Groups[1].Value + line;
                return continent + country + sity + region + latitude + longitude + timezone + org + isp + currency;
            }
            catch (Exception ex)
            {
                return $"{Local.Local.StringException}{ex.Message}";
            }
        }
        public static async Task<string> PhoneNumber()
        {
            try
            {
                string obl, oper, id_obl, id_oper, line = Environment.NewLine;
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    await Task.Run(() => s = wc.DownloadString($"http://www.megafon.ru/api/mfn/info?msisdn={ID_and_IP}"));
                }
                obl = Local.LocalParser.Operator + Regex.Match(s, "\"region\":\"(.*?)\"").Groups[1].Value + line;
                oper = Local.LocalParser.Region + Regex.Match(s, "\"operator\":\"(.*?)\"").Groups[1].Value + line;
                id_obl = Local.LocalParser.RegionID + Regex.Match(s, "\"region_id\":(.*?)}").Groups[1].Value + line;
                id_oper = Local.LocalParser.OperatorID + Regex.Match(s, "\"operator_id\":(.*?),").Groups[1].Value + line;
                return obl + oper + id_obl + id_oper;
            }
            catch (Exception ex)
            {
                return $"{Local.Local.StringException}{ex.Message}";
            }
        }
    }
}
