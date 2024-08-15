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

namespace CARSYS
{
    /// <summary>
    /// AnaEkran.xaml etkileşim mantığı
    /// </summary>
    public partial class AnaEkran : Window
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        private void ArabaBtn_Click(object sender, RoutedEventArgs e)
        {
            ARABALAR form = new ARABALAR();
            form.ShowDialog();
        }

        private void KıralamaEkranBtn_Click(object sender, RoutedEventArgs e)
        {
            ARABAKIRALA form = new ARABAKIRALA();
            form.ShowDialog();
        }

        private void RaporBtn_Click(object sender, RoutedEventArgs e)
        {
            RAPOR form = new RAPOR();
            form.ShowDialog();
        }
    }
}
