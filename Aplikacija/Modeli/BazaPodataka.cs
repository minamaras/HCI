using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija.Modeli
{
    class BazaPodataka
    {

        
        

        public ObservableCollection<Tip> Tipovi
        {
            get;
            set;
        }

        public ObservableCollection<Spomenik> Spomenici
        {
            get;
            set;
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get;
            set;
        }
    }
}
