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
    public class Spomenik : INotifyPropertyChanged
    {
        private string oznaka;
        private string ime;
        private Tip tip = new Tip();
        private ObservableCollection<Etiketa> etikete = new ObservableCollection<Etiketa>();
        private string opis;
        private string ikonica;
        private int klima;
        private int status;
        private string prihod;
        private String datum;
        private bool ekoloskiUgrozen = false;
        private bool naseljen = false;
        private bool ugrozeneVrste = false;
        private double x = -1;
        private double y = -1;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                if (value != x)
                    x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value != y)
                    y = value;
                OnPropertyChanged("Y");
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
                if(value != oznaka)
                {
                    oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

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

        public Tip Tip
        {
            get
            {
                return tip;
            }
            set
            {
                if(value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }

        }


        public ObservableCollection<Etiketa> Etikete
        {
            get
            {
                return etikete;
            }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
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

       

        public int Klima
        {
            get
            {
                return klima;
            }
            set
            {
                if (value != klima)
                {
                    klima = value;
                    OnPropertyChanged("Klima");
                }
                    
            }
        }

        public int TuristickiStatus
        {
            get
            {
                return status;
            }
            set
            {
                if (value != status)
                {
                    status = value;
                    OnPropertyChanged("TuristickiStatus");
                }
            }
        }

        public string Prihod
        {
            get
            {
                return prihod;
            }

            set
            {

                if (value != prihod)
                {
                    prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }

        public string Datum
        {
            get
            {
                return datum;
            }
            set
            {
                if (value != datum)
                {
                    datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public bool EkoloskiUgrozen
        {
            get
            {
                return ekoloskiUgrozen;
            }
            set
            {
                if(value != ekoloskiUgrozen)
                {
                    ekoloskiUgrozen = value;
                    OnPropertyChanged("EkoloskiUgrozen");
                }
            }
        }
        public bool Naseljen
        {
            get
            {
                return naseljen;
            }
            set
            {
                if (value != naseljen)
                {
                    naseljen = value;
                    OnPropertyChanged("Naseljen");
                } 
            }
        }

        public bool UgrozeneVrste
        {
            get
            {
                return ugrozeneVrste;
            }

            set
            {
                if(value != ugrozeneVrste)
                {
                    ugrozeneVrste = value;
                    OnPropertyChanged("UgrozeneVrste");
                }
            }
        }

        public Spomenik()
        {

        }


        public Spomenik(string oz, string i, Tip t, ObservableCollection<Etiketa> e, string op, string ik, int k, int s, string p, String d, bool eu, bool n, bool uv)
        {
            this.oznaka = oz;
            this.ime = i;
            this.tip = t;
            this.etikete = e;
            this.opis = op;
            this.ikonica = ik;
            this.klima = k;
            this.status = s;
            this.prihod = p;
            this.datum = d;
            this.ekoloskiUgrozen = eu;
            this.naseljen = n;
            this.ugrozeneVrste = uv;

        }

       
        [field: NonSerialized]public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public static implicit operator Spomenik(string v)
        {
            throw new NotImplementedException();
        }
    }
}
