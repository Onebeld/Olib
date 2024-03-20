using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Xml.Linq;

namespace Olib.Pages
{
    /// <summary>
    /// Логика взаимодействия для converter.xaml
    /// </summary>
    public partial class converter : Page
    {
        public converter()
        {
            InitializeComponent();
            Currenty();
            Core.Animations.AnimationText(Warning);
        }
        private XDocument doc;
        #region Temperature
        private void CelcionC(object sender, TextChangedEventArgs e)
        {
            if (Celcion.IsSelectionActive)
            {
                try
                {
                    float c = float.Parse(Celcion.Text);
                    Farengate.Text = ((c * 9 / 5) + 32).ToString();
                    Kelvin.Text = (c + 273.15F).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void FarengateC(object sender, TextChangedEventArgs e)
        {
            if (Farengate.IsSelectionActive)
            {
                try
                {
                    float f = float.Parse(Farengate.Text);
                    Celcion.Text = ((f - 32) * 5 / 9).ToString();
                    Kelvin.Text = ((f - 32) * 5 / 9 + 273.15F).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void KelvinC(object sender, TextChangedEventArgs e)
        {
            if (Kelvin.IsSelectionActive)
            {
                try
                {
                    float k = float.Parse(Kelvin.Text);
                    Celcion.Text = (k - 273.15F).ToString();
                    Farengate.Text = ((k - 273.15F) * 9 / 5 + 32).ToString();
                    Error.Content = null;
                }
                catch (FormatException ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion
        #region Mass
        private void MiligrammC(object sender, TextChangedEventArgs e)
        {
            if (Miligramm.IsSelectionActive)
            {
                try
                {
                    float m = float.Parse(Miligramm.Text);
                    Gramm.Text = (m / 1000).ToString();
                    Kilogramm.Text = (m / 1000000).ToString();
                    Tonn.Text = (m / 1000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void GrammC(object sender, TextChangedEventArgs e)
        {
            if (Gramm.IsSelectionActive)
            {
                try
                {
                    float g = float.Parse(Gramm.Text);
                    Miligramm.Text = (g * 1000).ToString();
                    Kilogramm.Text = (g / 1000).ToString();
                    Tonn.Text = (g / 1000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void KilogrammC(object sender, TextChangedEventArgs e)
        {
            if (Kilogramm.IsSelectionActive)
            {
                try
                {
                    float k = float.Parse(Kilogramm.Text);
                    Miligramm.Text = (k * 1000000).ToString();
                    Gramm.Text = (k * 1000).ToString();
                    Tonn.Text = (k / 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void TonnC(object sender, TextChangedEventArgs e)
        {
            if (Tonn.IsSelectionActive)
            {
                try
                {
                    float t = float.Parse(Tonn.Text);
                    Miligramm.Text = (t * 1000000000).ToString();
                    Gramm.Text = (t * 1000000).ToString();
                    Kilogramm.Text = (t * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion
        #region Length
        private void MillimetrC(object sender, TextChangedEventArgs e)
        {
            if (Millimetr.IsSelectionActive)
            {
                try
                {
                    float mil = float.Parse(Millimetr.Text);
                    Santimetr.Text = (mil / 10).ToString();
                    Metr.Text = (mil / 1000).ToString();
                    Kilometr.Text = (mil / 1E+6F).ToString();
                    Step.Text = (mil / 800).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void SantimetrC(object sender, TextChangedEventArgs e)
        {
            if (Santimetr.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(Santimetr.Text);
                    Millimetr.Text = (s * 10).ToString();
                    Metr.Text = (s / 100).ToString();
                    Kilometr.Text = (s / 1E+5F).ToString();
                    Step.Text = (s / 80).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void MetrC(object sender, TextChangedEventArgs e)
        {
            if (Metr.IsSelectionActive)
            {
                try
                {
                    float m = float.Parse(Metr.Text);
                    Millimetr.Text = (m * 1000).ToString();
                    Santimetr.Text = (m * 100).ToString();
                    Kilometr.Text = (m / 1000).ToString();
                    Step.Text = (m * 1.25F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void KilometrC(object sender, TextChangedEventArgs e)
        {
            if (Kilometr.IsSelectionActive)
            {
                try
                {
                    float k = float.Parse(Kilometr.Text);
                    Millimetr.Text = (k * 1E+6F).ToString();
                    Santimetr.Text = (k * 100000).ToString();
                    Metr.Text = (k * 1000).ToString();
                    Step.Text = (k * 1250).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void StepC(object sender, TextChangedEventArgs e)
        {
            if (Step.IsSelectionActive)
            {
                try
                {
                    float st = float.Parse(Step.Text);
                    Millimetr.Text = (st * 800).ToString();
                    Santimetr.Text = (st * 80).ToString();
                    Metr.Text = (st / 1.25F).ToString();
                    Kilometr.Text = (st / 1250).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion
        #region Data
        private void ByteC(object sender, TextChangedEventArgs e)
        {
            if (Byte.IsSelectionActive)
            {
                try
                {
                    float b = float.Parse(Byte.Text);
                    KiloByte.Text = (b / 1024).ToString();
                    MegaByte.Text = (b / 1048576).ToString();
                    GigaByte.Text = (b / 1073741824).ToString();
                    TeraByte.Text = (b / 1099511627776).ToString();
                    Bit.Text = (b * 8).ToString();
                    KiloBit.Text = (b / 125).ToString();
                    MegaBit.Text = (b / 125000).ToString();
                    GigaBit.Text = (b / 1.25e+8F).ToString();
                    TeraBit.Text = (b / 1.25e+11F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void KilobyteC(object sender, TextChangedEventArgs e)
        {
            if (KiloByte.IsSelectionActive)
            {
                try
                {
                    float k = float.Parse(KiloByte.Text);
                    Byte.Text = (k * 1024).ToString();
                    MegaByte.Text = (k / 1024).ToString();
                    GigaByte.Text = (k / 1048576).ToString();
                    TeraByte.Text = (k / 1073741824).ToString();
                    Bit.Text = (k * 8000).ToString();
                    KiloBit.Text = (k * 8).ToString();
                    MegaBit.Text = (k / 125).ToString();
                    GigaBit.Text = (k / 125000).ToString();
                    TeraBit.Text = (k / 1.25e+8F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void MegabyteC(object sender, TextChangedEventArgs e)
        {
            if (MegaByte.IsSelectionActive)
            {
                try
                {
                    float m = float.Parse(MegaByte.Text);
                    Byte.Text = (m * 1048576).ToString();
                    KiloByte.Text = (m * 1024).ToString();
                    GigaByte.Text = (m / 1024).ToString();
                    TeraByte.Text = (m / 1048576).ToString();
                    Bit.Text = (m * 8e+6F).ToString();
                    KiloBit.Text = (m * 8000).ToString();
                    MegaBit.Text = (m * 8).ToString();
                    GigaBit.Text = (m / 125).ToString();
                    TeraBit.Text = (m / 125000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void GigabyteC(object sender, TextChangedEventArgs e)
        {
            if (GigaByte.IsSelectionActive)
            {
                try
                {
                    float g = float.Parse(GigaByte.Text);
                    Byte.Text = (g * 1073741824).ToString();
                    KiloByte.Text = (g * 1048576).ToString();
                    MegaByte.Text = (g * 1024).ToString();
                    TeraByte.Text = (g / 1024).ToString();
                    Bit.Text = (g * 8e+9F).ToString();
                    KiloBit.Text = (g * 8e+6F).ToString();
                    MegaBit.Text = (g * 8000).ToString();
                    GigaBit.Text = (g * 8).ToString();
                    TeraBit.Text = (g / 125).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void TerabyteC(object sender, TextChangedEventArgs e)
        {
            if (TeraByte.IsSelectionActive)
            {
                try
                {
                    float t = float.Parse(TeraByte.Text);
                    Byte.Text = (t * 1099511627776).ToString();
                    KiloByte.Text = (t * 1073741824).ToString();
                    MegaByte.Text = (t * 1048576).ToString();
                    GigaByte.Text = (t * 1024).ToString();
                    Bit.Text = (t * 8e+12F).ToString();
                    KiloBit.Text = (t * 8e+9F).ToString();
                    MegaBit.Text = (t * 8e+6F).ToString();
                    GigaBit.Text = (t * 8000).ToString();
                    TeraBit.Text = (t * 8).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void BitC(object sender, TextChangedEventArgs e)
        {
            if (Bit.IsSelectionActive)
            {
                try
                {
                    float bit = float.Parse(Bit.Text);
                    Byte.Text = (bit / 8).ToString();
                    KiloByte.Text = (bit / 8000).ToString();
                    MegaByte.Text = (bit / 8000000).ToString();
                    GigaByte.Text = (bit / 8000000000).ToString();
                    TeraByte.Text = (bit / 8000000000000).ToString();
                    KiloBit.Text = (bit / 1000).ToString();
                    MegaBit.Text = (bit / 1000000).ToString();
                    GigaBit.Text = (bit / 1000000000).ToString();
                    TeraBit.Text = (bit / 1000000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = Local.Local.StringException + ex.Message;
                }
            }
        }
        private void KilobitC(object sender, TextChangedEventArgs e)
        {
            if (KiloBit.IsSelectionActive)
            {
                try
                {
                    float ki = float.Parse(KiloBit.Text);
                    Byte.Text = (ki * 125).ToString();
                    KiloByte.Text = (ki / 8).ToString();
                    MegaByte.Text = (ki / 8000).ToString();
                    GigaByte.Text = (ki / 8000000).ToString();
                    TeraByte.Text = (ki / 8000000000).ToString();
                    Bit.Text = (ki * 1000).ToString();
                    MegaBit.Text = (ki / 1000).ToString();
                    GigaBit.Text = (ki / 1000000).ToString();
                    TeraBit.Text = (ki / 1000000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = Local.Local.StringException + ex.Message;
                }
            }
        }
        private void MegabitC(object sender, TextChangedEventArgs e)
        {
            if (MegaBit.IsSelectionActive)
            {
                try
                {
                    float mi = float.Parse(MegaBit.Text);
                    Byte.Text = (mi * 125000).ToString();
                    KiloByte.Text = (mi * 125).ToString();
                    MegaByte.Text = (mi / 8).ToString();
                    GigaByte.Text = (mi / 8000).ToString();
                    TeraByte.Text = (mi / 8000000).ToString();
                    Bit.Text = (mi * 1000000).ToString();
                    KiloBit.Text = (mi * 1000).ToString();
                    GigaBit.Text = (mi / 1000).ToString();
                    TeraBit.Text = (mi / 1000000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = Local.Local.StringException + ex.Message;
                }
            }
        }
        private void GigabitC(object sender, TextChangedEventArgs e)
        {
            if (GigaBit.IsSelectionActive)
            {
                try
                {
                    float gi = float.Parse(GigaBit.Text);
                    Byte.Text = (gi * 125000000).ToString();
                    KiloByte.Text = (gi * 125000).ToString();
                    MegaByte.Text = (gi * 125).ToString();
                    GigaByte.Text = (gi / 8).ToString();
                    TeraByte.Text = (gi / 8000).ToString();
                    Bit.Text = (gi * 1000000000).ToString();
                    KiloBit.Text = (gi * 1000000).ToString();
                    MegaBit.Text = (gi * 1000).ToString();
                    TeraBit.Text = (gi / 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = Local.Local.StringException + ex.Message;
                }
            }
        }
        private void TerabitC(object sender, TextChangedEventArgs e)
        {
            if (TeraBit.IsSelectionActive)
            {
                try
                {
                    float ti = float.Parse(TeraBit.Text);
                    Byte.Text = (ti * 125000000000).ToString();
                    KiloByte.Text = (ti * 125000000).ToString();
                    MegaByte.Text = (ti * 125000).ToString();
                    GigaByte.Text = (ti * 125).ToString();
                    TeraByte.Text = (ti / 8).ToString();
                    Bit.Text = (ti * 1000000000000).ToString();
                    KiloBit.Text = (ti * 1000000000).ToString();
                    MegaBit.Text = (ti * 1000000).ToString();
                    GigaBit.Text = (ti * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = Local.Local.StringException + ex.Message;
                }
            }
        }
        #endregion
        #region Pressure
        private void PaskalC(object sender, TextChangedEventArgs e)
        {
            if (Paskal.IsSelectionActive)
            {
                try
                {
                    float p = float.Parse(Paskal.Text);
                    Bar.Text = (p / 100000).ToString();
                    Atmospfere.Text = (p / 101325).ToString();
                    Torr.Text = (p / 133.322F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void BarC(object sender, TextChangedEventArgs e)
        {
            if (Bar.IsSelectionActive)
            {
                try
                {
                    float b = float.Parse(Bar.Text);
                    Paskal.Text = (b * 100000).ToString();
                    Atmospfere.Text = (b / 1.013F).ToString();
                    Torr.Text = (b * 750.062F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void AtmospfereC(object sender, TextChangedEventArgs e)
        {
            if (Atmospfere.IsSelectionActive)
            {
                try
                {
                    float a = float.Parse(Atmospfere.Text);
                    Paskal.Text = (a * 101325).ToString();
                    Bar.Text = (a * 1.013F).ToString();
                    Torr.Text = (a * 760).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void TorrC(object sender, TextChangedEventArgs e)
        {
            if (Torr.IsSelectionActive)
            {
                try
                {
                    float t = float.Parse(Torr.Text);
                    Paskal.Text = (t * 133.322F).ToString();
                    Atmospfere.Text = (t / 760).ToString();
                    Bar.Text = (t / 750.062F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion
        #region Volume
        private void MililitreC(object sender, TextChangedEventArgs e)
        {
            if (MiliLitre.IsSelectionActive)
            {
                try
                {
                    float m = float.Parse(MiliLitre.Text);
                    Litre.Text = (m / 1000).ToString();
                    MetrCube.Text = (m / 1e+6F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void LitreC(object sender, TextChangedEventArgs e)
        {
            if (Litre.IsSelectionActive)
            {
                try
                {
                    float l = float.Parse(Litre.Text);
                    MiliLitre.Text = (l * 1000).ToString();
                    MetrCube.Text = (l / 1000).ToString();
                    Error.Content = null;

                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void MetrCubeC(object sender, TextChangedEventArgs e)
        {
            if (MetrCube.IsSelectionActive)
            {
                try
                {
                    float m = float.Parse(MetrCube.Text);
                    MiliLitre.Text = (m * 1e+6F).ToString();
                    Litre.Text = (m * 1000).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion
        private async void Currenty()
        {
            try
            {
                await Task.Run(() => doc = XDocument.Load(Local.Local.ConverterSource));
                var USD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01235"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var EUR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01239"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UAH = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01720"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BYN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01090B"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AMD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01060"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AUD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01010"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var AZN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01020A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var GBP = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01035"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BGN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01100"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var BRL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01115"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HUF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01135"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var HKD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01200"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var DKK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01215"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var INR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01270"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KZT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01335"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CAD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01350"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KGS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01370"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CNY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01375"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var MDL = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01500"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var NOK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01535"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var PLN = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01565"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var RON = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01585F"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var XDR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01589"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SGD = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01625"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TJS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01670"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TRY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01700J"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var TMT = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01710A"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var UZS = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01717"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CZK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01760"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var SEK = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01770"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var CHF = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01775"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var ZAR = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01810"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var KRW = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01815"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();
                var JPY = (from x in doc.Descendants("Valute")
                           where x.Attribute("ID").Value == "R01820"
                           select new
                           {
                               nam = x.Element("Name").Value,
                               val = float.Parse(x.Element("Value").Value),
                               nom = float.Parse(x.Element("Nominal").Value)
                           }).SingleOrDefault();

                Curr1.SelectedValuePath = "Key";
                Curr1.DisplayMemberPath = "Value";
                Curr2.SelectedValuePath = "Key";
                Curr2.DisplayMemberPath = "Value";
                KeyValuePair<float, string>[] items = new[]
                {
                    new KeyValuePair<float, string>(1, Local.Local.ConverterRuble),
                    new KeyValuePair<float, string>(USD.val / USD.nom, USD.nam),
                    new KeyValuePair<float, string>(EUR.val / EUR.nom, EUR.nam),
                    new KeyValuePair<float, string>(UAH.val / UAH.nom, UAH.nam),
                    new KeyValuePair<float, string>(BYN.val / BYN.nom, BYN.nam),
                    new KeyValuePair<float, string>(AMD.val / AMD.nom, AMD.nam),
                    new KeyValuePair<float, string>(AUD.val / AUD.nom, AUD.nam),
                    new KeyValuePair<float, string>(AZN.val / AZN.nom, AZN.nam),
                    new KeyValuePair<float, string>(GBP.val / GBP.nom, GBP.nam),
                    new KeyValuePair<float, string>(BGN.val / BGN.nom, BGN.nam),
                    new KeyValuePair<float, string>(BRL.val / BRL.nom, BRL.nam),
                    new KeyValuePair<float, string>(HUF.val / HUF.nom, HUF.nam),
                    new KeyValuePair<float, string>(HKD.val / HKD.nom, HKD.nam),
                    new KeyValuePair<float, string>(DKK.val / DKK.nom, DKK.nam),
                    new KeyValuePair<float, string>(INR.val / INR.nom, INR.nam),
                    new KeyValuePair<float, string>(KZT.val / KZT.nom, KZT.nam),
                    new KeyValuePair<float, string>(CAD.val / CAD.nom, CAD.nam),
                    new KeyValuePair<float, string>(KGS.val / KGS.nom, KGS.nam),
                    new KeyValuePair<float, string>(CNY.val / CNY.nom, CNY.nam),
                    new KeyValuePair<float, string>(MDL.val / MDL.nom, MDL.nam),
                    new KeyValuePair<float, string>(NOK.val / NOK.nom, NOK.nam),
                    new KeyValuePair<float, string>(PLN.val / PLN.nom, PLN.nam),
                    new KeyValuePair<float, string>(RON.val / RON.nom, RON.nam),
                    new KeyValuePair<float, string>(XDR.val / XDR.nom, XDR.nam),
                    new KeyValuePair<float, string>(SGD.val / SGD.nom, SGD.nam),
                    new KeyValuePair<float, string>(TJS.val / TJS.nom, TJS.nam),
                    new KeyValuePair<float, string>(TRY.val / TRY.nom, TRY.nam),
                    new KeyValuePair<float, string>(TMT.val / TMT.nom, TMT.nam),
                    new KeyValuePair<float, string>(UZS.val / UZS.nom, UZS.nam),
                    new KeyValuePair<float, string>(CZK.val / CZK.nom, CZK.nam),
                    new KeyValuePair<float, string>(SEK.val / SEK.nom, SEK.nam),
                    new KeyValuePair<float, string>(CHF.val / CHF.nom, CHF.nam),
                    new KeyValuePair<float, string>(ZAR.val / ZAR.nom, ZAR.nam),
                    new KeyValuePair<float, string>(KRW.val / KRW.nom, KRW.nam),
                    new KeyValuePair<float, string>(JPY.val / JPY.nom, JPY.nam) //33
                };
                foreach (var i in items)
                {
                    Curr1.Items.Add(i);
                    Curr2.Items.Add(i);
                }
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = $"{ex.Message}";
            }
        }

        private void CurrConvert()
        {
            try
            {
                Res.Content = Convert.ToString(float.Parse(Curr1.SelectedValue.ToString()) / float.Parse(Curr2.SelectedValue.ToString()) * float.Parse(Number.Text) + " " + Curr2.Text);
                Error.Content = null;
            }
            catch (Exception ex)
            {
                Error.Content = $"{ex.Message}";
            }
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e) => CurrConvert();
        private void Curr1_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();
        private void Curr2_SelectionChanged(object sender, SelectionChangedEventArgs e) => CurrConvert();
        #region Area
        private void SantimetrSquareC(object sender, TextChangedEventArgs e)
        {
            if (SantimetrSquare.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(SantimetrSquare.Text);
                    MetrSquare.Text = (s / 10000).ToString();
                    KilometrSquare.Text = (s / 1e+10F).ToString();
                    HarSquare.Text = (s / 1e+8F).ToString();
                    MileSquare.Text = (s / 2.59e+10F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void MetrSquareC(object sender, TextChangedEventArgs e)
        {
            if (MetrSquare.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(MetrSquare.Text);
                    SantimetrSquare.Text = (s * 10000).ToString();
                    KilometrSquare.Text = (s / 1e+6F).ToString();
                    HarSquare.Text = (s / 10000).ToString();
                    MileSquare.Text = (s / 2.59e+6F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void KilometrSquareC(object sender, TextChangedEventArgs e)
        {
            if (KilometrSquare.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(KilometrSquare.Text);
                    SantimetrSquare.Text = (s * 1e+10F).ToString();
                    MetrSquare.Text = (s * 1e+6F).ToString();
                    HarSquare.Text = (s * 100).ToString();
                    MileSquare.Text = (s / 2.59F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void HarSquareC(object sender, TextChangedEventArgs e)
        {
            if (HarSquare.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(HarSquare.Text);
                    SantimetrSquare.Text = (s * 1e+8F).ToString();
                    MetrSquare.Text = (s * 10000).ToString();
                    KilometrSquare.Text = (s / 100).ToString();
                    MileSquare.Text = (s / 258.999F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void MileSquareC(object sender, TextChangedEventArgs e)
        {
            if (MileSquare.IsSelectionActive)
            {
                try
                {
                    float s = float.Parse(MileSquare.Text);
                    SantimetrSquare.Text = (s * 2.59e+10F).ToString();
                    MetrSquare.Text = (s * 2.59e+6F).ToString();
                    KilometrSquare.Text = (s * 2.59F).ToString();
                    HarSquare.Text = (s * 258.999F).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        #endregion

        private void DecimalC(object sender, TextChangedEventArgs e)
        {
            if (Decimal.IsSelectionActive)
            {
                try
                {

                    Double.Text = Convert.ToString(int.Parse(Decimal.Text), 2);
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }
        private void DoubleC(object sender, TextChangedEventArgs e)
        {
            if (Double.IsSelectionActive)
            {
                try
                {
                    Decimal.Text = Convert.ToInt32(Double.Text, 2).ToString();
                    Error.Content = null;
                }
                catch (Exception ex)
                {
                    Error.Content = $"{ex.Message}";
                }
            }
        }

    }
}
