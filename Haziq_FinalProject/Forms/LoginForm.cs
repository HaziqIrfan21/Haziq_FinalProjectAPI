using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Haziq_FinalProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

           
            this.textBoxPassword.Size = new Size(this.textBoxPassword.Size.Width,50);


            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;email=;database=finalproject_users_db;SSL Mode=None");
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login(textBoxUsername.Text, textBoxPassword.Text);

        }

        public void Login(string userName,string password)
        {
            DB db = new DB();

            //string username = textBoxUsername.Text;
            //string password = textBoxPassword.Text;

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn and `password` = @pass", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;

            adapter.Fill(table);


            //check if the user is empty
            if (table.Rows.Count > 0)
            {
                //Admin Control
                if (userName == "user1" && password == "pass")
                {
                    this.Hide();
                    AdminForm adminForm = new AdminForm();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                    adminForm.Show();
                }
                //User Control
                else
                {
                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }

            }

            else
            {
                if (userName.Trim().Equals(""))
                {
                    MessageBox.Show("Username is empty,please enter a username");
                }

                else if (password.Trim().Equals(""))
                {
                    MessageBox.Show("Password is empty,please enter a Password");
                }
                else
                {
                    MessageBox.Show("Wrong username or password, try again");
                }

            }
        }
        private void labelAccountSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void labelAccountSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelAccountSignUp.ForeColor = Color.Yellow;
        }

        private void labelAccountSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelAccountSignUp.ForeColor = Color.White;
        }

      
    }
}
