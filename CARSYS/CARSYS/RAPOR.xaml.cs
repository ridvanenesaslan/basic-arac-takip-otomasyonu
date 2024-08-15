using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// RAPOR.xaml etkileşim mantığı
    /// </summary>
    public partial class RAPOR : Window
    {
        public RAPOR()
        {
            InitializeComponent();
        }

        private void LISTELE1_Click(object sender, RoutedEventArgs e)
        {
            gridControl4.Columns.Clear();
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("select * FROM SIPARISLER", db);
                DataSet ds = new DataSet();

                db.Open();
                da.Fill(ds);
                gridControl4.DataSource = ds.Tables[0];
            }
        }
    }
}
