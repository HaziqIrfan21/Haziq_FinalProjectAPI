using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Haziq_FinalProject
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

           


        }

        private void Admin_Load(object sender, EventArgs e)
        {

            Admin_Load();

        }

       

        public void Admin_Load()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.users", connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "users");
                dataGridView1.DataSource = ds.Tables["users"];

                DataSet ds2 = new DataSet();
                adapter2.Fill(ds2, "orders");
                dataGridView2.DataSource = ds2.Tables["orders"];
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelAccountSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
