using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace Aplikacija.Modeli
{
    [Serializable]
    public class Etiketa : INotifyPropertyChanged
    {
        private string oznaka;
        private string opis;
        //private SolidColorBrush boja;
        private string boja;

        public Etiketa(String o, String op, String c)
        {

            oznaka = o;
            opis = op;
            boja = c;

        }
        public Etiketa()
        {

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


        /*public Brush Boja
        {
            get
            {
                return boja;
            }
            set
            {
                if(value != boja)
                {
                    boja = (SolidColorBrush)value;
                    OnPropertyChanged("Boja");
                }
            }
        }*/

        public String Boja
        {
            get
            {
                return boja;
            }
            set
            {
                if (value != boja)
                {
                    boja = value;
                    OnPropertyChanged("Boja");
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
