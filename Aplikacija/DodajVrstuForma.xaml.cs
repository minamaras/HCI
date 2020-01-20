using Aplikacija.Modeli;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;
using Xceed.Wpf.Toolkit;

namespace Aplikacija.Dijalozi
{
    /// <summary>
    /// Interaction logic for DodajVrstuForma.xaml
    /// </summary>
    public partial class DodajVrstuForma : Window, INotifyPropertyChanged
    {
        
        public static Spomenik trenutniSpomenik;
        private MainWindow mw;
        private string slika;

        public DodajVrstuForma()
        {
            this.DataContext = this;
            Tipovi = MainWindow.Tipovi;
            Etikete = MainWindow.Etikete;
            Spomenici = MainWindow.Spomenici;
            IzabraneEtikete = new ObservableCollection<Etiketa>();
            SlobodneEtikete = new ObservableCollection<Etiketa>();

            foreach(Etiketa et in MainWindow.Etikete)
            {
                SlobodneEtikete.Add(et);
            }

            InitializeComponent();
            Tip.SelectedIndex = 0;
            Tip_SelectionChanged(null, null);
            //ako inicijalno bude selekotvana slika izabranog tipa
          
            /*
                Tip temp = (Tip)Tip.SelectedItem;
                slika = temp.Ikonica;*/
            
            
            //btnDodaj.IsEnabled = false;

            

            trenutniSpomenik = null;

        }

        public DodajVrstuForma(Spomenik s, MainWindow mwi)
        {
            
            this.DataContext = this;
            Tipovi = MainWindow.Tipovi;
            Etikete = MainWindow.Etikete;
            Spomenici = MainWindow.Spomenici;
            SlobodneEtikete = new ObservableCollection<Etiketa>();

            IzabraneEtikete = s.Etikete;

            
            foreach(Etiketa et in MainWindow.Etikete)
            {
                SlobodneEtikete.Add(et);
            }

            
            foreach(Etiketa et in s.Etikete)
            {
                SlobodneEtikete.Remove(et);
            }

            trenutniSpomenik = s;
            InitializeComponent();

            Oznaka.Text = s.Oznaka;
            Ime.Text = s.Ime;
            Opis.Text = s.Opis;
            Turizam.SelectedIndex = s.TuristickiStatus;
            if(s.UgrozeneVrste == true)
            {
                StanisteDA.IsChecked = true;
            }
            else if(s.UgrozeneVrste == false)
            {
                StanisteNE.IsChecked = true;
            }

            if(s.Naseljen == true)
            {
                NaseljenoDA.IsChecked = true;
            }
            else if(s.Naseljen == false)
            {
                NaseljenoNE.IsChecked = true;
            }

            if(s.EkoloskiUgrozen == true)
            {
                UgrozenDA.IsChecked = true;
            }
            else if(s.EkoloskiUgrozen == false)
            {
                UgrozenNE.IsChecked = true;
            }

            Prihod.Text = s.Prihod;
            Klima.SelectedIndex = s.TuristickiStatus;
            Datum.SelectedDate = DateTime.Parse(s.Datum);
            //Slika = s.Ikonica;
            img.Source = new BitmapImage(new Uri(s.Ikonica));
            Tip.SelectedItem = s.Tip;
            mw = mwi;


        }

        private void BtnIzaberi_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dijalog = new OpenFileDialog();
            dijalog.Title = "Odaberite sliku";
            dijalog.Filter = "Slike|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (dijalog.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(dijalog.FileName));
                slika = dijalog.FileName;
            }
        }

        private void BtnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            img.Source = new BitmapImage(new Uri("images/question.png", UriKind.Relative));
        }

        private void Tip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tip.SelectedValue != null && img != null)
            {
                Tip t = (Tip)Tip.SelectedValue;
                img.Source = t.Ikona;
                
                Slika = t.Ikonica;
            }
        }

        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            //validacija
            bool vOznaka = false;
            if(Oznaka.Text == "")
            {
                vOznaka = false;
                Oznaka.Background = Brushes.PaleVioletRed;
                System.Windows.MessageBox.Show("Morate uneti oznaku za vrstu!");
                return;
            }
            else
            {
                vOznaka = true;
            }
            bool vIme = false;
            if (Ime.Text == "")
            {
                vIme = false;
                Ime.Background = Brushes.PaleVioletRed;
                System.Windows.MessageBox.Show("Morate uneti ime za vrstu!");
                return;
            }
            else
            {
                vIme = true;
            }



            /*bool iznos = false;
            if(Prihod.Text == "")
            {
                iznos = false;
                Prihod.Background = Brushes.Coral;
                System.Windows.MessageBox.Show("Morate uneti prihod");
                return;
            }
            else
            {
                foreach (char c in Prihod.Text)
                {
                    if (c != '0' || c != '1' || c != '2' || c != '3' || c != '4' || c != '5' || c != '6' || c != '7' || c != '8' || c != '9' || c != ',' || c != '.')
                    {
                        System.Windows.MessageBox.Show("Ne smete unositi slova, iskljucivo brojeve");
                        return;
                    }
                }
                iznos = true;
            }


            int p = Int32.Parse(Prihod.Text);
            if(p <= 0)
            {
                System.Windows.MessageBox.Show("Prihod mora biti veci od nule!");
                return;
            }*/

            bool staniste;
            bool ekoloski;
            bool naselje;

            if(StanisteDA.IsChecked == true)
            {
                staniste = true;
            }
            else
            {
                staniste = false;
            }

            if(UgrozenDA.IsChecked == true)
            {
                ekoloski = true;
            }
            else
            {
                ekoloski = false;
            }

            if(NaseljenoDA.IsChecked == true)
            {
                naselje = true;
            }
            else
            {
                naselje = false;
            }

            if(trenutniSpomenik == null)
            {
                Spomenik s = new Spomenik
                {
                    Ime = Ime.Text,
                    Oznaka = Oznaka.Text,
                    Opis = Opis.Text,
                    Tip = (Tip)Tip.SelectedItem,
                    Etikete = IzabraneEtikete,
                    Prihod = Prihod.Text,
                    Datum = Datum.ToString(),
                    TuristickiStatus = Turizam.SelectedIndex,
                    Klima = Klima.SelectedIndex,
                    EkoloskiUgrozen = ekoloski,
                    Naseljen = naselje,
                    UgrozeneVrste = staniste,
                    //Ikonica = Slika,
                    Ikonica = img.Source.ToString(),
                };

                foreach (Spomenik sp in MainWindow.Spomenici)
                {
                    if (sp.Oznaka.Equals(Oznaka.Text))
                    {
                        System.Windows.MessageBox.Show("Vec postoji spomenik sa ovom oznakom");
                        return;
                    }
                }

                //dodajemo u listu tipova sve vrste koje su bile u njemu
                Tip t = (Tip)Tip.SelectedItem;
                
                //t.Vrste.Add(s);
                MainWindow.Spomenici.Add(s);

                

            }
            //ako je izmena u pitanju
            else
            {

                
                foreach (Spomenik sp in MainWindow.Spomenici)
                {
                    if (sp.Oznaka.Equals(Oznaka.Text) && !(sp.Oznaka.Equals(trenutniSpomenik.Oznaka)))
                    {
                        System.Windows.MessageBox.Show("Vec postoji spomenik sa ovom oznakom");
                        return;
                    }
                }


                trenutniSpomenik.Ime = Ime.Text;
                trenutniSpomenik.Ikonica = Slika;
                trenutniSpomenik.Oznaka = Oznaka.Text;
                trenutniSpomenik.Opis = Opis.Text;
                trenutniSpomenik.TuristickiStatus = Turizam.SelectedIndex;
                trenutniSpomenik.Prihod = Prihod.Text;
                trenutniSpomenik.EkoloskiUgrozen = ekoloski;
                trenutniSpomenik.UgrozeneVrste = staniste;
                trenutniSpomenik.Naseljen = naselje;
                trenutniSpomenik.Datum = Datum.ToString();
                trenutniSpomenik.Etikete = IzabraneEtikete;
                //trenutniSpomenik.Tip.Vrste.Remove(trenutniSpomenik);
                trenutniSpomenik.Tip = (Tip)Tip.SelectedItem;
                //trenutniSpomenik.Tip.Vrste.Add(trenutniSpomenik);
            }

            this.Close();
        }


        private void BtnOdaberi_MouseEnter(object sender, MouseEventArgs e)
        {
            btnOdaberi.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BtnOdaberi_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOdaberi.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnOdbaci_MouseEnter(object sender, MouseEventArgs e)
        {
            btnOdbaci.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BtnOdbaci_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOdbaci.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnDodaj_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDodaj.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BtnDodaj_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDodaj.Foreground = new SolidColorBrush(Colors.White);
        }

        private void OdustaniBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            OdustaniBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void OdustaniBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            OdustaniBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void DodajUIzabrane_Click(object sender, RoutedEventArgs e)
        {
            if (Slobodne.SelectedValue != null)
            {
                Etiketa et = (Etiketa)Slobodne.SelectedValue;
                IzabraneEtikete.Add(et);
                SlobodneEtikete.Remove(et);
            }
        }

        private void DodajUSlobodne_Click(object sender, RoutedEventArgs e)
        {
            if (Izabrane.SelectedValue != null)
            {
                Etiketa et = (Etiketa)Izabrane.SelectedValue;
                SlobodneEtikete.Add(et);
                IzabraneEtikete.Remove(et);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        public string Slika
        {
            get
            {
                return slika;
            }
            set
            {
                if (value != slika)
                {
                    slika = value;
                    OnPropertyChanged("Slika");
                }
            }
        }



        public ObservableCollection<Etiketa> SlobodneEtikete
        {
            get;
            set;
        }
        public ObservableCollection<Etiketa> IzabraneEtikete
        {
            get;
            set;
        }

        public ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

        private void Oznaka_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Oznaka.Text.Equals(""))
            {
                ValOznaka.Visibility = Visibility.Hidden;
                Oznaka.Background = Brushes.White;

            }
            else
            {
                ValOznaka.Visibility = Visibility.Visible;
                Oznaka.Background = Brushes.PaleVioletRed;
            }
        }

        private void Ime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Ime.Text.Equals(""))
            {
                ValIme.Visibility = Visibility.Hidden;
                Ime.Background = Brushes.White;

            }
            else
            {
                ValIme.Visibility = Visibility.Visible;
                Ime.Background = Brushes.PaleVioletRed;
            }
        }

        private void Prihod_LostFocus(object sender, RoutedEventArgs e)
        {
            int broj;

            if (int.TryParse(Prihod.Text, out broj) != false)
            {
                ValPrihod.Visibility = Visibility.Hidden;
                Prihod.Background = Brushes.White;

            }
            else
            {
                ValPrihod.Visibility = Visibility.Visible;
                Prihod.Background = Brushes.PaleVioletRed;
                System.Windows.MessageBox.Show("Ne smete unositi slova, iskljucivo brojeve");
                return;

            }

        }
    }
}
