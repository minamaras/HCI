using Aplikacija.Dijalozi;
using Aplikacija.Modeli;
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
    /// Interaction logic for PregledEtikete.xaml
    /// </summary>
    public partial class PregledEtikete : Window
    {

        private MainWindow mw;
        

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public PregledEtikete()
        {
            
            InitializeComponent();
            this.DataContext = this;
            Etikete = MainWindow.Etikete;
            
        }

        private void BtnOdustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {
            
            Etiketa etiketa = (Etiketa)dgEtiketa.SelectedItem;
            if (etiketa == null)
            {
                MessageBox.Show("Potrebno je prvo selektovati etiketu koju zelite da obrisete.");
            }
            else
            {
                Etikete.Remove(etiketa);
            }
        }

        private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            Etiketa selektovana = (Etiketa)dgEtiketa.SelectedItem;

            //ako nista nije selektovano
            if (selektovana == null)
            {
                MessageBox.Show("Potrebno je prvo selektovati etiketu koju zelite da izmenite.");
            }
            else
            {
                DodajEtiketuForma izmena = new DodajEtiketuForma(selektovana, mw);
                izmena.ShowDialog();
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
