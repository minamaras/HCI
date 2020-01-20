using Aplikacija.Dijalozi;
using Aplikacija.Modeli;
using Aplikacija.Serijalizacija;
using Aplikacija.Tabele;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aplikacija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged

    {
        
        public MainWindow()
        {
            this.DataContext = this;
            Tipovi = new ObservableCollection<Tip>();
            Etikete = new ObservableCollection<Etiketa>();
            Spomenici = new ObservableCollection<Spomenik>();
            MapaLista = new ObservableCollection<Spomenik>();
            MapaLista = Spomenici;
            InitializeComponent();
        }

        private void DodajTip_Click(object sender, RoutedEventArgs e)
        {
            DodajTipForma prozor = new DodajTipForma();
            
            prozor.ShowDialog();
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private Point startPoint;

        private void DodajTipMenu_Click(object sender, RoutedEventArgs e)
        {
            DodajTipForma prozor = new DodajTipForma();
            prozor.ShowDialog();
        }

        private void DodajVrstu_Click(object sender, RoutedEventArgs e)
        {
            DodajVrstuForma prozor = new DodajVrstuForma();
            if(Tipovi.Count() == 0)
            {
                MessageBox.Show("Morate prvo dodati tip");
                return;
            }
            else
            {
                prozor.ShowDialog();
            }
            
        }



        private void DodajVrstuMenu_Click(object sender, RoutedEventArgs e)
        {
            DodajVrstuForma prozor = new DodajVrstuForma();
            prozor.ShowDialog();
        }

        private void DodajEtiketuButton_Click(object sender, RoutedEventArgs e)
        {
            DodajEtiketuForma prozor = new DodajEtiketuForma();
            prozor.ShowDialog();
        }

        private void IzaberiBtn_Click(object sender, RoutedEventArgs e)
        {
            IzaberiFormu prozor = new IzaberiFormu();
            prozor.ShowDialog();
        }

        private void PregledTipa_Click(object sender, RoutedEventArgs e)
        {
            PregledTipa prozor = new PregledTipa();
            prozor.ShowDialog();
        }

        private void PregledVrste_Click(object sender, RoutedEventArgs e)
        {
            PregledVrste prozor = new PregledVrste();
            prozor.ShowDialog();
        }

        private void PregledEtikete_Click(object sender, RoutedEventArgs e)
        {
            PregledEtikete prozor = new PregledEtikete();
            prozor.ShowDialog();
        }
        //obrisala sam static
        public static ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }

        public static ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }

        public static ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

        private ObservableCollection<Spomenik> mapalista;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Spomenik> MapaLista
        {

            get { return mapalista; }

            set
            {
                if(mapalista != value)
                {
                    mapalista = value;
                    OnPropertyChanged("MapaLista");

                }


            }

        }

        //kad prevlacimo da se stvori tackasti pravougaonik
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            //stvori transparenti pravougaonik oko nase trenutne drag pozicije
            //i hocemo da proverimo da li smo u okviru tog pravougaonika
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                try
                {
                    Spomenik selektovana = (Spomenik)tabelaSpomenika.SelectedValue;
                    if (selektovana != null)
                    {
                        DataObject dragData = new DataObject("spomenik", selektovana);
                        //prikaz - ono sto ce drag-ovati
                        //dodragdrop - metoda koja proverava sta je to iznad cega je kursor
                        //a zatim proverava da li je validno za drag-ovanje
                        DragDrop.DoDragDrop(prikaz, dragData, DragDropEffects.Link);
                    }
                }
                catch
                {
                    return;
                }
            }
        }

        //pocetna pozicija
        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void TabelaSpomenika_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabelaSpomenika.SelectedValue is Spomenik)
            {
                Spomenik s = (Spomenik)tabelaSpomenika.SelectedValue;
                if (!s.Ikonica.Equals(""))
                    prikaz.Source = new BitmapImage(new Uri(s.Ikonica));
                else
                    prikaz.Source = new BitmapImage(new Uri(s.Tip.Ikonica));

            }
            else { prikaz.Source = null; }
        }

        //event koji se javlja ako promenimo element nad kojim je mis
        private void Mapa_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("spomenik") || sender == e.Source)
            {
                //jer podatak za drag-ovanje nije string
                e.Effects = DragDropEffects.None;
            }
        }

        //kad se otpusti dugme da se prikaze na mapi..valjda?
        private void Mapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("spomenik"))
            {
                Spomenik s = e.Data.GetData("spomenik") as Spomenik;

                bool result = mapa.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == s.Oznaka);
                //  bool preklapanje = false;
                System.Windows.Point d0 = e.GetPosition(mapa);
                foreach (Spomenik r0 in Spomenici)
                {
                    if (s.Oznaka != r0.Oznaka)
                    {
                        if (r0.X != -1 && r0.Y != -1)
                        {
                            if (Math.Abs(r0.X - d0.X) <= 30 && Math.Abs(r0.Y - d0.Y) <= 30)
                            {
                                System.Windows.MessageBox.Show("Ne mogu da se preklapaju", "Preklapanje");
                                
                                
                                return;
                            }
                        }
                    }
                }
                if (result == false)
                {

                    Image img = new Image();
                    if (!s.Ikonica.Equals(""))
                        img.Source = new BitmapImage(new Uri(s.Ikonica));
                    else
                        img.Source = new BitmapImage(new Uri(s.Tip.Ikonica));

                    img.Width = 50;
                    img.Height = 50;
                    img.Tag = s.Oznaka;
                    var positionX = e.GetPosition(mapa).X;
                    var positionY = e.GetPosition(mapa).Y;
                    
                    s.X = positionX;
                    s.Y = positionY;
              
                    ObservableCollection<Spomenik> spomeniciList = Spomenici;
                    int idx = 0;
                    foreach (Spomenik spo in spomeniciList)
                    {
                        if (spo.Oznaka.Equals(s.Oznaka))
                            break;
                        idx++;
                    }
                    spomeniciList[idx] = s;
                    mapa.Children.Add(img);
                    Canvas.SetLeft(img, positionX - 20);
                    Canvas.SetTop(img, positionY - 20);

                }
                else
                {
                    System.Windows.MessageBox.Show("Ovaj spomenik vec postoji na mapi.", "Dodavanje");

                }
            }
        }

        private void TabelaSpomenika_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }


        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            SacuvajEtiketu.serijalizacijaEtikete();
            SacuvajTip.serijalizacijaTipa();
            SacuvajSpomenik.serijalizacijaSpomenika();
        }

        private void Ucitaj_Click(object sender, RoutedEventArgs e)
        {
            SacuvajEtiketu.deserijalizacijaEtikete();
            SacuvajTip.deserijalizacijaTipa();
            SacuvajSpomenik.deserijalizacijaSpomenika();

            tabelaSpomenika.ItemsSource = null;
            tabelaSpomenika.ItemsSource = Spomenici;
        }

        private void ObrisiSaMape_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Spomenik selektovano = (Spomenik)tabelaSpomenika.SelectedItem;
                if(selektovano != null)
                {
                    bool postoji = mapa.Children.Cast<Image>()
                           .Any(x => x.Tag != null && x.Tag.ToString() == selektovano.Oznaka);
                    if (postoji)
                    {
                        Image img = null;
                        foreach (Image i in mapa.Children)
                        {
                            if (i.Tag.Equals(selektovano.Oznaka))
                                img = i;
                        }
                        mapa.Children.Remove(img);
                        int idx = 0;
                        foreach (Spomenik s in MapaLista)
                        {
                            if (selektovano.Oznaka.Equals(s.Oznaka))
                                break;
                            idx++;
                        }
                        Spomenici[idx].X = -1;
                        Spomenici[idx].Y = -1;


                        MapaLista = Spomenici;

                    }



                }
            } catch
            {
                return;
            }
        }
    }
}
