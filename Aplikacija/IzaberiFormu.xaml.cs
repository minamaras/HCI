using Aplikacija.Tabele;
using System;
using System.Collections.Generic;
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

namespace Aplikacija.Dijalozi
{
    /// <summary>
    /// Interaction logic for IzaberiFormu.xaml
    /// </summary>
    public partial class IzaberiFormu : Window
    {
        public IzaberiFormu()
        {
            InitializeComponent();
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
    }
}
