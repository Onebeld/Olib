using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для rouletteFM.xaml
    /// </summary>
    public partial class rouletteFM : Page
    {
        public rouletteFM()
        {
            InitializeComponent();
            try
            {
                foreach (string i in Properties.Settings.Default.ListItem)
                {
                    List.Items.Add(i);
                }
            }
            catch { }
            Core.Animations.AnimationText(Warning, Completed);
        }
        private int index, time = 1;
        private readonly string l = Environment.NewLine;
        private const long dot = 80000;
        private float b = 0;

        private void Button_Click(object sender, RoutedEventArgs e) => new Windows.rouletteFM_Settings().Show();
        #region Random
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            var rmd = new Random();
            Complete.Content = null;
            RdmGlobal.Text = Local.Local.RandomButtonTwistExpectation;
            Error.Content = null;
            await Task.Delay(time * 1000 + 1);
            string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
            b = 0;
            try
            {
                for (int i = 0; i < Properties.Settings.Default.NumberItems; i++)
                {
                Random:
                    list.Add(string_array[rmd.Next(0, string_array.Length)] + Environment.NewLine);
                    if (Properties.Settings.Default.CheckBox3)
                    {
                        if (list.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).Any())
                        {
                            string duplicate = list.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).First();
                            if (list.Contains(duplicate))
                            {
                                if (b < dot)
                                {
                                    list.Remove(duplicate);
                                    b++;
                                    goto Random;
                                }
                                else
                                {
                                    list.RemoveAt(list.Count - 1);
                                }
                            }
                        }
                        b = 0;
                    }
                }
                if (Properties.Settings.Default.NumberItems > List.Items.Count)
                {
                    if (list.Count > List.Items.Count)
                    {
                        int Y = Properties.Settings.Default.NumberItems - List.Items.Count;
                        list.RemoveRange(List.Items.Count, Y);
                    }
                }
                RdmGlobal.Text = Local.Local.RandomButtonTwistOut + l + l;
                foreach (var i in list)
                {
                    RdmGlobal.Text += i;
                }
            }
            catch (Exception ex)
            {
                Error.Content = $"{ex.Message}";
                RdmGlobal.Text = Local.Local.RouletteFXTwist;
            }

        }
        #endregion
        private void ListBoxItem_ContextMenuOpening(object sender, ContextMenuEventArgs e) => index = List.SelectedIndex;
        private void NameR(object sender, RoutedEventArgs e) => AddItems();
        private void ButtClick(object sender, RoutedEventArgs e) => AllClear();
        private void OpenRename(object sender, RoutedEventArgs e)
        {
            ItemsS.Sourc = List.Items[index].ToString();
            var win = new Windows.rouletteFM_Rename();
            win.Show();
            win.Closed += (s, b) => List.Items[index] = ItemsS.Sourc;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) => RdmGlobal.Text = Local.Local.RouletteFXTwist;
        private void MenuRe_Click(object sender, RoutedEventArgs e)
        { 
            if (List.SelectedItem != null)
            {
                List.Items.Remove(List.SelectedItem);
            }
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            foreach (var i in p)
            {
                Properties.Settings.Default.ListItem.Add(i);
            }
            Properties.Settings.Default.Save();
        }

        private void MenuCopy(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            Clipboard.SetText(List.Items[index].ToString());
        }
        private void AllClear()
        {
            ListName.Content = Local.Local.RouletteFXListName;
            List.Items.Clear();
            Properties.Settings.Default.ListItem.Clear();
            Properties.Settings.Default.FileName = Local.Local.RouletteFXListName;
            Properties.Settings.Default.Save();
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AddItems();
        }
        private void NormalMode(object sender, RoutedEventArgs e) => _ = NavigationService.Navigate(new Uri("Pages/roulette.xaml", UriKind.Relative));

        private void AddItems()
        {
            if (name.Text.Length == 0)
            {
                Error.Content = Local.Local.RouletteFXNullItemAdd;
                return;
            }
            List.Items.Add(name.Text);
            if (Properties.Settings.Default.CheckBox1)
                name.Text = null;
            Error.Content = null;
            Complete.Content = null;
            Properties.Settings.Default.ListItem.Clear();
            string[] p = (from object item in List.Items select item.ToString()).ToArray();
            foreach (var i in p)
            {
                Properties.Settings.Default.ListItem.Add(i);
            }
            Properties.Settings.Default.Save();
        }

        private void SaveXML(object sender, RoutedEventArgs e)
        {
            Complete.Content = null;
            Error.Content = null;
            string[] string_array = (from object item in List.Items select item.ToString()).ToArray();
            SaveFileDialog d = new SaveFileDialog { Filter = "XML-files (*.xml)|*.xml|TXT-files (*.txt)|*.txt" };
            if ((bool)d.ShowDialog())
            {
                switch (System.IO.Path.GetExtension(d.FileName))
                {
                    case ".txt":
                            try
                            {
                                List<string> list = new List<string>();
                                foreach (var i in string_array)
                                {
                                    list.Add(i);
                                }
                                File.AppendAllLines(d.FileName, list.ToArray());
                                Complete.Content = $"{Local.Local.RouletteFXFileSave}{d.FileName}";
                            }
                            catch (Exception ex)
                            {
                                Error.Content = $"{ex.Message}";
                            }
                            break;
                    case ".xml":
                            try
                            {
                                XDocument doc = new XDocument(
                                new XElement("Elements",
                                    from n in string_array select new XElement("Element", n)
                                ));
                                doc.Save(d.FileName);
                                Complete.Content = $"{Local.Local.RouletteFXFileSave}{d.FileName}";
                            }
                            catch (Exception ex)
                            {
                                Error.Content = $"{ex.Message}";
                            }
                            break;
                }
            }

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog { Filter = "TXT-files (*.txt)|*.txt" };
            if ((bool)d.ShowDialog())
            {
                try
                {
                    using (StreamWriter stream = new StreamWriter(d.FileName, true))
                    {
                        stream.WriteLine($"########\nТекст: {TextName.Text}\n\n{RdmGlobal.Text}");
                    }
                    Complete.Content = "Сохранено!";
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }

        private void List_KeyDown(object sender, KeyEventArgs e)
        {
            if (List.SelectedItem != null)
            {
                if(e.Key == Key.Delete)
                {
                    List.Items.Remove(List.SelectedItem);
                    Properties.Settings.Default.ListItem.Clear();
                    string[] p = (from object item in List.Items select item.ToString()).ToArray();
                    foreach (var i in p)
                    {
                        Properties.Settings.Default.ListItem.Add(i);
                    }
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void OpenXML(object sender, RoutedEventArgs e)
        {
            Complete.Content = null;
            Error.Content = null;
            OpenFileDialog d = new OpenFileDialog { Filter = "XML-files (*.xml)|*.xml|TXT-files (*.txt)|*.txt" };
            if ((bool)d.ShowDialog())
            {
                switch (System.IO.Path.GetExtension(d.FileName))
                {
                    case ".txt":
                        try
                        {
                            if (Properties.Settings.Default.CheckBox2) AllClear();
                            foreach (var i in File.ReadAllLines(d.FileName))
                            {
                                List.Items.Add(i);
                            }
                            Properties.Settings.Default.FileName = ListName.Content.ToString();
                            Properties.Settings.Default.ListItem.Clear();
                            string[] p = (from object item in List.Items select item.ToString()).ToArray();
                            foreach (var i in p)
                            {
                                Properties.Settings.Default.ListItem.Add(i);
                            }
                            Complete.Content = Local.Local.RouletteFXFileLoad;
                            if (Properties.Settings.Default.CheckBox2) ListName.Content = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{ex.Message}";
                        }
                        break;

                    case ".xml":
                        try
                        {
                            string[] list = XDocument.Load(d.FileName).Root.Elements("Element").Select(elem => elem.Value).ToArray();
                            if (Properties.Settings.Default.CheckBox2) AllClear();
                            foreach (var i in list)
                            {
                                List.Items.Add(i);
                            }
                            Properties.Settings.Default.FileName = ListName.Content.ToString();
                            Properties.Settings.Default.ListItem.Clear();
                            string[] p = (from object item in List.Items select item.ToString()).ToArray();
                            foreach (var i in p)
                            {
                                Properties.Settings.Default.ListItem.Add(i);
                            }
                            Complete.Content = Local.Local.RouletteFXFileLoad;
                            if (Properties.Settings.Default.CheckBox2) ListName.Content = System.IO.Path.GetFileNameWithoutExtension(d.FileName);
                        }
                        catch (Exception ex)
                        {
                            Error.Content = $"{ex.Message}";
                        }
                        break;
                }
                Properties.Settings.Default.Save();
            }
        }
    }
    static class ItemsS
    {
        public static string Sourc { get; set; }
    }
}
