using DevExpress.Xpf.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CARSYS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GirisBtn_Click(object sender, RoutedEventArgs e)
        {
            ArrayList dizi = new ArrayList();
            string ekle = "SELECT TOP 1 KullanıcıAdı FROM PERSONELLER where KullanıcıAdı = ? AND Sifre = ?";

            using (OleDbConnection db = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CARDB.mdb"))
            {
                OleDbCommand cmd = new OleDbCommand(ekle, db);
                cmd.Parameters.AddWithValue("@KullanıcıAdı", KullaniciAdiTxt.Text);
                cmd.Parameters.AddWithValue("@Sifre", ŞifreTxt.Text);

                db.Open();
                OleDbDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dizi.Add(dr["KullanıcıAdı"].ToString());
                }
            }

            if (dizi.Count > 0)
            {
                AnaEkran form = new AnaEkran();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya şifre hatalı.");
            }
        }
    }
}
