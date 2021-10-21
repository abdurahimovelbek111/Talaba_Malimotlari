using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Data.SqlClient;
namespace Talaba_Malimotlari
{
    public partial class Form1 : Form
    {
        Student model = new Student();
        public Form1()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }      


        void Tozala()
        {
            txtName.Text = "";
            txtFirstName.Text = "";
            txtMiddilName.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";

        }
        void datagrivChiqar()
        {
           // dataGridView1.AutoGenerateColumns = true ;  
            // List<Student> students = new List<Student>();
            using (Model1 db = new Model1())
            {
                // students = db.Students.ToList<Student>();
                dataGridView1.DataSource = db.Students.ToList<Student>();
            }           
            btnDelete.Enabled = false;            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datagrivChiqar();        
        }     

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            model.Name = txtName.Text.Trim();
            model.FirstName = txtFirstName.Text.Trim();
            model.MiddilName = txtMiddilName.Text.Trim();
            model.Age = int.Parse(txtAge.Text.Trim());
            model.Phone = txtPhone.Text.Trim();
            using (Model1 db=new Model1())
            {
                if (model.id == 0)
                   db.Students.Add(model);
                else
                    db.Entry(model).State = EntityState.Modified;               
                db.SaveChanges();
            }
                MessageBox.Show("Malimot yangilandii");
                datagrivChiqar();
                Tozala();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
        }
       

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Haqiqatanam malimotni uchirmoqchimisiz","",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                using (Model1 db=new Model1())
                {
                    var entity = db.Entry(model);
                    //if(entity.State==EntityState.Detached)
                    //{
                        db.Students.Attach(model);
                        db.Students.Remove(model);
                        db.SaveChanges();
                        MessageBox.Show("Students jadvalidan ma'limot uchirilmoqda");
                        datagrivChiqar();
                        MessageBox.Show("Malimot uchirildii");
                        Tozala();
                    //}
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.Text != "" && txtFirstName.Text != "" && txtMiddilName.Text != "" && txtAge.Text != "" && txtPhone.Text != "")
            {
                    // insert 1-usul
                model.Name = txtName.Text.Trim();
                model.FirstName = txtFirstName.Text.Trim();
                model.MiddilName = txtMiddilName.Text.Trim();
                model.Age = int.Parse(txtAge.Text.Trim());
                model.Phone = txtPhone.Text.Trim();
                using (Model1 db = new Model1())
                {
                    // insert 2-usul
                    // Student student = new Student { Name = txtName.Text, FirstName = txtFirstName.Text, MiddilName = txtMiddilName.Text, Age = Convert.ToInt32(txtAge.Text), Phone = txtPhone.Text };
                    db.Students.Add(model);
                    db.SaveChanges();
                    MessageBox.Show("Malumot qushildii");
                    Tozala();
                    datagrivChiqar();
                }
            }
            else
            {
                MessageBox.Show("Iltimos qushishdan oldin malimotni kiriting!!!");
            }          
        }

     
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if(cmbSearch.Text=="Name" || cmbSearch.Text=="FirstName" || cmbSearch.Text=="MiddilName" || cmbSearch.Text=="Age" || cmbSearch.Text=="Phone")
            {
                MessageBox.Show("DataGriewdagi malimotlarni olib bulmaydii");
            }
            else
            if (dataGridView1.CurrentRow.Index != -1)
            {
              
                model.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                using (Model1 db = new Model1())
                {
                    model = db.Students.Where(x => x.id == model.id).FirstOrDefault();
                    txtName.Text = model.Name;
                    txtFirstName.Text = model.FirstName;
                    txtMiddilName.Text = model.MiddilName;
                    txtAge.Text = model.Age.ToString();
                    txtPhone.Text = model.Phone;
                }                
                btnDelete.Enabled = true;
            }
        }

     

        private void cmbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearch.Text == "Name")
            {
                txtFirstName.Text = "";
                txtMiddilName.Text = "";
                txtAge.Text = "";
                txtPhone.Text = "";
                txtName.Enabled = true;
                txtFirstName.Enabled = false;
                txtMiddilName.Enabled = false;
                txtAge.Enabled = false;
                txtPhone.Enabled = false;
            }
            if (cmbSearch.Text == "FirstName")
            {
                txtName.Text = "";
                txtMiddilName.Text = "";
                txtAge.Text = "";
                txtPhone.Text = "";
                txtFirstName.Enabled = true;
                txtName.Enabled = false;
                txtMiddilName.Enabled = false;
                txtAge.Enabled = false;
                txtPhone.Enabled = false;
            }
            if (cmbSearch.Text == "MiddilName")
            {
                txtName.Text = "";
                txtFirstName.Text = "";
                txtAge.Text = "";
                txtPhone.Text = "";
                txtMiddilName.Enabled = true;
                txtFirstName.Enabled = false;
                txtName.Enabled = false;
                txtAge.Enabled = false;
                txtPhone.Enabled = false;
            }
            if (cmbSearch.Text == "Age")
            {
                txtName.Text = "";
                txtMiddilName.Text = "";
                txtFirstName.Text = "";
                txtPhone.Text = "";
                txtAge.Enabled = true;
                txtFirstName.Enabled = false;
                txtMiddilName.Enabled = false;
                txtName.Enabled = false;
                txtPhone.Enabled = false;
            }
            if (cmbSearch.Text == "Phone")
            {
                txtName.Text = "";
                txtMiddilName.Text = "";
                txtAge.Text = "";
                txtFirstName.Text = "";
                txtPhone.Enabled = true;
                txtFirstName.Enabled = false;
                txtMiddilName.Enabled = false;
                txtAge.Enabled = false;
                txtName.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (Model1 db = new Model1())
            {

                switch (cmbSearch.Text)
                {
                    case "Name":
                        dataGridView1.DataSource = db.Students.Where(x => x.Name.Contains(txtName.Text)).ToList(); break;
                    case "FirstName":
                        dataGridView1.DataSource = db.Students.Where(x => x.FirstName.Contains(txtFirstName.Text)).ToList(); break;
                    case "MiddilName":
                        dataGridView1.DataSource = db.Students.Where(x => x.MiddilName.Contains(txtMiddilName.Text)).ToList(); break;
                    case "Age":
                        dataGridView1.DataSource = db.Students.Where(x => x.Age.ToString().Contains(txtAge.Text)).ToList(); break;
                    case "Phone":
                        dataGridView1.DataSource = db.Students.Where(x => x.Phone.Contains(txtPhone.Text)).ToList(); break;
                }
            }
        }       
        private void btnNew_Click_1(object sender, EventArgs e)
        {          
            txtName.Text = "";
            txtFirstName.Text = "";
            txtMiddilName.Text = "";
            txtAge.Text = "";
            txtPhone.Text = "";
            txtName.Enabled = true;
            txtFirstName.Enabled = true;
            txtMiddilName.Enabled = true;
            txtAge.Enabled = true;
            txtPhone.Enabled = true;
            cmbSearch.Text = "";
            datagrivChiqar();
        }
    }
}
