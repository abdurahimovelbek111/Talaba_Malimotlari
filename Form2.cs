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
using System.Data.Entity;
using System.IO;
namespace Talaba_Malimotlari
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUC7BS4\\SQL_BAZA;Initial Catalog=AAAA;Integrated Security=True");
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnUnload_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "select image(*.JpG;*.pnf;*.Gif)| *.JpG;*.pnf;*.Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("insert into Table1(Name,image11)Vaules(@Name,@image11)",con);
                cmd.Parameters.AddWithValue("Name", textBox1.Text);
                MemoryStream memstrm = new MemoryStream();
                pictureBox1.Image.Save(memstrm, pictureBox1.Image.RawFormat);
                cmd.Parameters.AddWithValue("image11", memstrm.ToArray());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ddfhdfdfhjd");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xatolik turi :" + ex);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
