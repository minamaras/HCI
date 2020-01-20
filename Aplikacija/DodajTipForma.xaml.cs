using Aplikacija.Modeli;
using Aplikacija.Serijalizacija;
using Aplikacija.Tabele;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for DodajTipForma.xaml
    /// </summary>
    public partial class DodajTipForma : Window
    {
        private MainWindow mw;
        
        public static Tip trenutniTip;
        private string slika;

        
        public DodajTipForma()
        {
            this.DataContext = this;
            InitializeComponent();
            img.Source = new BitmapImage(new Uri("images/paris.png", UriKind.Relative));
            trenutniTip = null;
           

        }

        
        public DodajTipForma(Tip tip, MainWindow mwi)
        {
            this.DataContext = this;
            trenutniTip = tip;
            InitializeComponent();
            
            
            Oznaka.Text = tip.Oznaka;
            Ime.Text = tip.Ime;
            Opis.Text = tip.Opis;
            img.Source = new BitmapImage(new Uri(tip.Ikonica));
            mw = mwi;

          

        }

        public static ObservableCollection<Tip> Tipovi
        {
            get;
            set;
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


        private void OdustaniButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.MainWindow.Show();
        }

        private void hoverDodaj(object sender, MouseEventArgs e)
        {
            DodajButton.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void otpustiDodaj(object sender, MouseEventArgs e)
        {
            DodajButton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnOdbaci_Click(object sender, RoutedEventArgs e)
        {
            img.Source = new BitmapImage(new Uri("images/paris.png", UriKind.Relative));
        }

        
        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            bool vOznaka = false;
            bool vIme = false;

            if (Oznaka.Text == "" || Ime.Text == "")
            {
                vOznaka = false;
                vIme = false;
                Oznaka.Background = Brushes.PaleVioletRed;
                Ime.Background = Brushes.PaleVioletRed;
                MessageBox.Show("Morate uneti oznaku i ime!");
                return;

            }
            else
            {
                vOznaka = true;
                vIme = true;
            }

            if (trenutniTip == null)
            {
                foreach (Tip t in MainWindow.Tipovi)
                {

                    if (t.Oznaka.Equals(Oznaka.Text))
                    {
                        MessageBox.Show("Vec postoji tip sa ovim imenom");
                        return;
                    }
                }

                Tip tip = new Tip { Oznaka = Oznaka.Text, Ime = Ime.Text, Opis = Opis.Text, Ikonica = img.Source.ToString() };
                MainWindow.Tipovi.Add(tip);
                
            }

            else if(trenutniTip != null)
            {
                foreach (Tip t in MainWindow.Tipovi)
                {
                    if (t.Oznaka.Equals(trenutniTip.Oznaka) && !(t.Oznaka.Equals(trenutniTip.Oznaka)))
                    {
                        vOznaka = true;
                        vIme = true;
                    }
                }

                trenutniTip.Oznaka = Oznaka.Text;
                trenutniTip.Ime = Ime.Text;
                trenutniTip.Opis = Opis.Text;
                trenutniTip.Ikonica = img.Source.ToString();

                


            }

            
            /*if (trenutniTip != null)
            {
                trenutniTip.Oznaka = Oznaka.Text;
                trenutniTip.Ime = Ime.Text;
                trenutniTip.Opis = Opis.Text;
                trenutniTip.Ikonica = img.Source.ToString();

                foreach(Tip t in MainWindow.Tipovi)
                {
                    if(t.Oznaka.Equals(trenutniTip.Oznaka))
                    {
                        vOznaka = true;
                        vIme = true;
                    }
                }

                
            } */
            /*
            else
            {
                
                Tip tip = new Tip { Oznaka = Oznaka.Text, Ime = Ime.Text, Opis = Opis.Text, Ikonica = img.Source.ToString() };
                MainWindow.Tipovi.Add(tip);
            }*/


            
            this.Close();
            
         }

        private void OdustaniButton_MouseEnter(object sender, MouseEventArgs e)
        {
            OdustaniButton.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void OdustaniButton_MouseLeave(object sender, MouseEventArgs e)
        {
            OdustaniButton.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnOdaberi_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOdaberi.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnOdaberi_MouseEnter(object sender, MouseEventArgs e)
        {
            btnOdaberi.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BtnOdbaci_MouseLeave(object sender, MouseEventArgs e)
        {
            btnOdbaci.Foreground = new SolidColorBrush(Colors.White);
        }

        private void BtnOdbaci_MouseEnter(object sender, MouseEventArgs e)
        {
            btnOdbaci.Foreground = new SolidColorBrush(Colors.Black);
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
    }
}
