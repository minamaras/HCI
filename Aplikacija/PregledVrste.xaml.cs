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
    /// Interaction logic for PregledVrste.xaml
    /// </summary>
    public partial class PregledVrste : Window
    {
        private MainWindow mw;
        public PregledVrste()
        {
            InitializeComponent();
            this.DataContext = this;
            Spomenici = MainWindow.Spomenici;
        }

        public ObservableCollection<Spomenik> Spomenici
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
            Spomenik s = (Spomenik)dgSpomenik.SelectedItem;
            if (s == null)
            {
                MessageBox.Show("Morate prvo selektovate spomenik da biste ga izmenili.");
            }
            else
            {
                DodajVrstuForma izmena = new DodajVrstuForma(s, mw);
                izmena.ShowDialog();
            }

            
        }

        private void ObrisiBtn_Click(object sender, RoutedEventArgs e)
        {

            Spomenik s = (Spomenik)dgSpomenik.SelectedItem;
            if (s == null)
            {
                MessageBox.Show("Morate prvo selektovate spomenik da biste ga obrisali.");
            }
            else
            {
                Spomenici.Remove(s);
            }

            
            
        }

        private void hoverOdustani(object sender, MouseEventArgs e)
        {
            BtnOdustani.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void otpustiOdustani(object sender, MouseEventArgs e)
        {
            BtnOdustani.Foreground = new SolidColorBrush(Colors.White);
        }

        private void hoverIzmeni(object sender, MouseEventArgs e)
        {
            IzmeniBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void otpustiIzmeni(object sender, MouseEventArgs e)
        {
            IzmeniBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void hoverObrisi(object sender, MouseEventArgs e)
        {
            ObrisiBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void otpustiObrisi(object sender, MouseEventArgs e)
        {
            ObrisiBtn.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
