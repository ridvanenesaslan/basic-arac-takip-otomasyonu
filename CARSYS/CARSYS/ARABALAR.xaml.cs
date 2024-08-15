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
    /// ARABALAR.xaml etkileşim mantığı
    /// </summary>
    public partial class ARABALAR : Window
    {
        public ARABALAR()
        {
            InitializeComponent();
        }

        private void ekle()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string ekle = "INSERT INTO ARABALAR (ARABAMARKAMODEL, ARABARENK, ARABAFIYAT) VALUES (?, ?, ?)";
                OleDbCommand cmd = new OleDbCommand(ekle, db);
                cmd.Parameters.AddWithValue("@ARABAMARKAMODEL", textBox1.Text);
                cmd.Parameters.AddWithValue("@ARABARENK", textBox2.Text);
                cmd.Parameters.AddWithValue("@ARABAFIYAT", textBox3.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Araç eklendi!");
            }
            listele();
        }

        private void guncelle()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string guncelle = "UPDATE ARABALAR SET ARABAMARKAMODEL = ?, ARABARENK = ?, ARABAFIYAT = ? WHERE ID = ?";
                OleDbCommand cmd = new OleDbCommand(guncelle, db);
                cmd.Parameters.AddWithValue("@ARABAMARKAMODEL", textBox1.Text);
                cmd.Parameters.AddWithValue("@ARABARENK", textBox2.Text);
                cmd.Parameters.AddWithValue("@ARABAFIYAT", textBox3.Text);
                cmd.Parameters.AddWithValue("@ID", textBox4.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Araç güncellendi!");
            }
            listele();
        }

        private void sil()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string sil = "DELETE FROM ARABALAR WHERE ID = ?";
                OleDbCommand cmd = new OleDbCommand(sil, db);
                cmd.Parameters.AddWithValue("@ID", textBox4.Text);

                db.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Araç silindi!");
            }
            listele();
        }

        private void listele()
        {
            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                string listele = "SELECT * FROM ARABALAR";
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
