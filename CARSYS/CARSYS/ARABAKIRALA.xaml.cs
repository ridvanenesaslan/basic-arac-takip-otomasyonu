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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CARSYS
{
    /// <summary>
    /// ARABAKIRALA.xaml etkileşim mantığı
    /// </summary>
    public partial class ARABAKIRALA : Window
    {
        public ARABAKIRALA()
        {
            InitializeComponent();
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string ekle = "SELECT DISTINCT ARABAMARKAMODEL FROM ARABALAR";
                OleDbCommand cmd = new OleDbCommand(ekle, db);
                db.Open();
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["ARABAMARKAMODEL"]);
                }
            }
        }

        private void ekle()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string ekle = "INSERT INTO SIPARISLER (ARABAMARKAMODEL, MUSTERIAD, MUSTERISOYAD) VALUES (?, ?, ?)";
                OleDbCommand cmd = new OleDbCommand(ekle, db);
                cmd.Parameters.AddWithValue("@ARABAMARKAMODEL", comboBox1.Text);
                cmd.Parameters.AddWithValue("@MUSTERIAD", textBox1.Text);
                cmd.Parameters.AddWithValue("@MUSTERISOYAD", textBox2.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt eklendi!");
            }
            listele();
        }

        private void guncelle()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string guncelle = "UPDATE SIPARISLER SET ARABAMARKAMODEL = ?, MUSTERIAD = ?, MUSTERISOYAD = ? WHERE ID = ?";
                OleDbCommand cmd = new OleDbCommand(guncelle, db);
                cmd.Parameters.AddWithValue("@ARABAMARKAMODEL", comboBox1.Text);
                cmd.Parameters.AddWithValue("@MUSTERIAD", textBox1.Text);
                cmd.Parameters.AddWithValue("@MUSTERISOYAD", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", textBox3.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt güncellendi!");
            }
            listele();
        }

        private void sil()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string sil = "DELETE FROM SIPARISLER WHERE ID = ?";
                OleDbCommand cmd = new OleDbCommand(sil, db);
                cmd.Parameters.AddWithValue("@ID", textBox3.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt silindi!");
            }
            listele();
        }

        private void listele()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string listele = "SELECT * FROM SIPARISLER";
                OleDbDataAdapter da = new OleDbDataAdapter(listele, db);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
        }

        private void EkleBtn_Click(object sender, RoutedEventArgs e)
        {
            ekle();
        }

        private void GuncelleBtn_Click(object sender, RoutedEventArgs e)
        {
            guncelle();
        }

        private void EkleBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            listele();
        }

        private void SilBtn_Click(object sender, RoutedEventArgs e)
        {
            sil();
        }
    }
}
