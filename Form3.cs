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
namespace Talaba_Malimotlari
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HUC7BS4\\SQL_BAZA;Initial Catalog=Student;Integrated Security=True");
        SqlCommand command=new SqlCommand();
        public Form3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            command.CommandType = CommandType.Text;
            command.CommandText = "insert into Students(Name,Surname,Adress) values('"+txtName.Text+"','"+txtSurname.Text+"','"+txtAdress.Text+"')";
            command.ExecuteNonQuery();
            con.Close();
            txtName.Text = "";
            txtSurname.Text = "";
            txtAdress.Text = "";
            MessageBox.Show("ffvfv");
            dataGriewga_Chiqar();
        }
        void dataGriewga_Chiqar()
        {
            con.Open();
            command =new SqlCommand("select * from Students", con);
            command.ExecuteNonQuery();
            DataTable table = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            sqlDataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGriewga_Chiqar();
        }
    }
}
