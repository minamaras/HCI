using Aplikacija.Modeli;
using Aplikacija.Serijalizacija;
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

namespace Aplikacija.Tabele
{
    /// <summary>
    /// Interaction logic for PregledTipa.xaml
    /// </summary>
    public partial class PregledTipa : Window
    {
        private MainWindow mw;
        private DodajTipForma forma = new DodajTipForma();
        

        public PregledTipa()
        {
            InitializeComponent();
            this.DataContext = this;
            Tipovi = MainWindow.Tipovi;
            

        }

        public ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }
        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            Tip selektovani = (Tip)dgTip.SelectedItem;
            if(selektovani == null)
            {
                MessageBox.Show("Potrebno je prvo selektovati tip");
            }

            else
            {

                DodajTipForma izmenaTipa = new DodajTipForma(selektovani, mw);
                
                izmenaTipa.ShowDialog();
            }

        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            Tip tip = (Tip)dgTip.SelectedItem;

            

            if (tip == null)
            {
                MessageBox.Show("Potrebno je prvo selektovati tip");
            }
            else
            {
                if(MessageBox.Show("Ako obrisete tip, obrisace se i svi spomenici sa tim tipom", "Brisanje tipa spomenika", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    List<Spomenik> spomenici = MainWindow.Spomenici.ToList();


                    foreach (Spomenik spo in spomenici)
                    {
                        if (spo.Tip.Equals(tip))
                        {
                            MainWindow.Spomenici.Remove(spo);
                        }
                    }

                    MainWindow.Tipovi.Remove(tip);
                }

                else
                {
                    return;
                }
               

            }

       
            
        }

        private void BtnOdustani_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnOdustani.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BtnOdustani_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnOdustani.Foreground = new SolidColorBrush(Colors.White);
        }

        private void ObrisiBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ObrisiBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void ObrisiBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ObrisiBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void IzmeniBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            IzmeniBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void IzmeniBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            IzmeniBtn.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
