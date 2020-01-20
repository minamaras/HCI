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
using Xceed.Wpf.Toolkit;

namespace Aplikacija.Dijalozi
{
    /// <summary>
    /// Interaction logic for DodajEtiketuForma.xaml
    /// </summary>
    public partial class DodajEtiketuForma : Window
    {
        private MainWindow mw;
        public static Etiketa trenutnaEtiketa;
        private Color mojaBoja;

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public DodajEtiketuForma()
        {
            this.DataContext = this;
            InitializeComponent();
            trenutnaEtiketa = null;
            
        }

        public DodajEtiketuForma(Etiketa e, MainWindow mwi)
        {
            this.DataContext = this;
            trenutnaEtiketa = e;
            InitializeComponent();
            Etikete = MainWindow.Etikete;

            //mw = null;
            

            Oznaka.Text = e.Oznaka;
            Opis.Text = e.Opis;
            ClrPcker_Background.SelectedColor = (Color)ColorConverter.ConvertFromString(e.Boja);
            mw = mwi;

        }

        private String boja;

        public String Boja
        {
            get { return boja; }
            set { boja = value; }
        }

   
        private void OdustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            
            /*System.Windows.Media.Color color = (System.Windows.Media.Color)this.ClrPcker_Background.SelectedColor.Value;
            boja = (Color.FromArgb(color.A, color.R, color.G, color.B)).ToString();*/

            if(ClrPcker_Background.SelectedColor.HasValue)
            {
                mojaBoja = ClrPcker_Background.SelectedColor.Value;
                byte red = mojaBoja.R;
                byte green = mojaBoja.G;
                byte blue = mojaBoja.B;
            }
            else
            {
                mojaBoja = new Color();
            }
            
        }

        private void DodajBtn_Click(object sender, RoutedEventArgs e)
        {
            //validacija
            bool vOznaka = false;
            if(Oznaka.Text == "")
            {
                vOznaka = false;
                Oznaka.Background = Brushes.Coral;

            }
            else
            {
                vOznaka = true;
                
            }

            if(!vOznaka)
            {
                //System.Windows.MessageBox.Show("Popunite polje za oznaku");
                VOznaka.Visibility = Visibility.Visible;
                return;   
            }
            


            

            Color boja = (Color)ClrPcker_Background.SelectedColor;
            //SolidColorBrush solid = new SolidColorBrush(boja);
            string myclr = boja.ToString();

            

            if (trenutnaEtiketa != null)
            {

                foreach (Etiketa et in MainWindow.Etikete)
                {
                    if (et.Oznaka == Oznaka.Text && !(et.Oznaka.Equals(trenutnaEtiketa.Oznaka)))
                    {
                        System.Windows.MessageBox.Show("Vec postoji etiketa sa ovakvom oznakom");
                        return;
                    }
                }
                trenutnaEtiketa.Oznaka = Oznaka.Text;
                trenutnaEtiketa.Opis = Opis.Text;
                //trenutnaEtiketa.Boja = solid;
                trenutnaEtiketa.Boja = myclr;
            }
            else
            {


                Etiketa etiketa = new Etiketa();
                etiketa.Oznaka = Oznaka.Text;
                etiketa.Opis = Opis.Text;
                //etiketa.Boja = solid;
                etiketa.Boja = myclr;

                foreach (Etiketa et in MainWindow.Etikete)
                {
                    if (et.Oznaka == Oznaka.Text)
                    {
                        System.Windows.MessageBox.Show("Vec postoji etiketa sa ovakvom oznakom");
                        return;
                    }
                }

                //etiketa.Boja = ClrPcker_Background.SelectedColor.Value.ToString();
                MainWindow.Etikete.Add(etiketa);
            }
            
            this.Close();
        }

        private void DodajBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            DodajBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void DodajBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            DodajBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void OdustaniBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            OdustaniBtn.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void OdustaniBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            OdustaniBtn.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Oznaka_LostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
