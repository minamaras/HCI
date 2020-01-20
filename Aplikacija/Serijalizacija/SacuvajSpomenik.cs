using Aplikacija.Modeli;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Aplikacija.Serijalizacija
{
    public class SacuvajSpomenik
    {
        private static string file = "spomenici.xml";

        public SacuvajSpomenik()
        { }

        public static void serijalizacijaSpomenika()
        {
            using (Stream s = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Spomenik>));
                serializer.Serialize(s, MainWindow.Spomenici);
            }



        }

        public static void deserijalizacijaSpomenika()
        {
            if (File.Exists(file) == false)

                serijalizacijaSpomenika();

            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Spomenik>));

            using (FileStream fs = File.OpenRead(file))
            {
                MainWindow.Spomenici = (ObservableCollection<Spomenik>)serializer.Deserialize(fs);
            }
        }
    }
}
