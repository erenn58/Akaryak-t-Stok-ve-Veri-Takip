using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace test_petrol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=akaryakıt;Integrated Security=True");



        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From tblbenzin where Yakıt='Kursunsuz95'", baglanti);
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    lblkurşunsuz.Text = dr[3].ToString();
                    progressBar1.Value=int.Parse(dr[4].ToString());
                    lblk.Text = dr[4].ToString();
                }
                baglanti.Close ();
                {
                    baglanti.Open();
                    SqlCommand komut2 = new SqlCommand("Select * From tblbenzin where Yakıt='Dizel'", baglanti);
                    SqlDataReader dr2 = komut2.ExecuteReader();
                    while (dr2.Read())
                    {
                       lbldizel.Text = dr2[3].ToString();
                        progressBar2.Value = int.Parse(dr2[4].ToString());
                        lbld.Text = dr2[4].ToString();
                    }
                    baglanti.Close();

                    baglanti.Open();
                    SqlCommand komut3 = new SqlCommand("Select * From tblbenzin where Yakıt='Otogaz'", baglanti);
                    SqlDataReader dr3 = komut3.ExecuteReader();
                    while (dr3.Read())
                    {
                        lblotogaz.Text = dr3[3].ToString();
                        progressBar3.Value = int.Parse(dr3[4].ToString());
                        lblo.Text = dr3[4].ToString(); 
                    }
                    baglanti.Close();


                    baglanti.Open();
                    SqlCommand komut4 = new SqlCommand("Select * From tblbenzin where Yakıt='GazYaği'", baglanti);
                    SqlDataReader dr4 = komut4.ExecuteReader();
                    while (dr4.Read())
                    {
                        lblgaz.Text = dr4[3].ToString();
                        progressBar4.Value = int.Parse(dr4[4].ToString());
                        lblg.Text = dr4[4].ToString();
                    }
                    baglanti.Close();
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz, litre, tutar;
            kursunsuz = Convert.ToDouble(lblkurşunsuz.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar=kursunsuz * litre;
            txtKF.Text=tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double dizel, litre, tutar;
            dizel = Convert.ToDouble(lbldizel.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = dizel * litre;
            txtDF.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double otogaz, litre, tutar;
            otogaz = Convert.ToDouble(lblotogaz.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = otogaz * litre;
            txtOF.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double gazyaği, litre, tutar;
            gazyaği = Convert.ToDouble(lblgaz.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = gazyaği * litre;
            txtGF.Text = tutar.ToString();
        }

        private void btndepo_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value !=0)
            {
                baglanti.Open ();
                SqlCommand komut = new SqlCommand("INSERT INTO tblharaket(plaka,yakıt,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtplaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kursunsuz95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4",decimal.Parse( txtKF.Text));
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Satış Yapıldı");



            }
        }
    }
}
