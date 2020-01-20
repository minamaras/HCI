using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Aplikacija.Modeli
{
    [Serializable]
    public class Tip : INotifyPropertyChanged
    {
        private string oznaka;
        private string ime;
        private string opis;
        private string ikonica;
        //private ObservableCollection<Spomenik> vrste;
        

        public Tip(String o, String i, String op, String ik)
        {
            oznaka = o;
            ime = i;
            opis = op;
            ikonica = ik;
            //Vrste = new ObservableCollection<Spomenik>();
        }

        public Tip()
        {
            //Vrste = new ObservableCollection<Spomenik>();
        }


        public BitmapImage Ikona
        {
            get
            {
                Uri uri = new Uri(ikonica);
                BitmapImage bmpimg = null;
                try
                {
                    bmpimg = new BitmapImage(uri);
                }
                catch (Exception e)
                {

                }
                return bmpimg;
            }
        }


        public string Oznaka
        {
            get
            {
                return oznaka;
            }
            set
            {
                if (value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        /*public ObservableCollection<Spomenik> Vrste
        {
            get
            {
                return vrste;
            }
            set
            {
                if (value != vrste)
                {
                    vrste = value;
                    OnPropertyChanged("Vrste");
                }
            }
        }*/

        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                if(value != ime)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Opis
        {
            get
            {
                return opis;
            }
            set
            {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public String Ikonica
        {
            get
            {
                return ikonica;
            }
            set
            {
                if (value != ikonica)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }


        public static implicit operator Tip(string v)
        {
            throw new NotImplementedException();
        }

        [field:NonSerialized]public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
