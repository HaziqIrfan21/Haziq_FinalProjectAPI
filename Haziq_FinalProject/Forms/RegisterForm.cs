using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Haziq_FinalProject
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void textBoxFirstName_Enter(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            if (firstName.ToLower().Trim().Equals("First Name"))
            {
                textBoxFirstName.Text = "";
                textBoxFirstName.ForeColor = Color.Black;
            }
        }

        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text;
            if (firstName.ToLower().Trim().Equals("First Name") || firstName.Trim().Equals(""))
            {
                textBoxFirstName.Text = "First Name";
                textBoxFirstName.ForeColor = Color.Gray;
            }

        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            textBoxFirstName.ForeColor = Color.Black;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            //remove focus from textboxes
            this.ActiveControl = label1;
        }

        private void textBoxLastName_Enter(object sender, EventArgs e)
        {
            string lastName = textBoxLastName.Text;
            if (lastName.ToLower().Trim().Equals("Last Name"))
            {
                textBoxLastName.Text = "";
                textBoxLastName.ForeColor = Color.Black;
            }
        }

        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            string lastName = textBoxLastName.Text;
            if (lastName.ToLower().Trim().Equals("Last Name") || lastName.Trim().Equals(""))
            {
                textBoxLastName.Text = "Last Name";
                textBoxLastName.ForeColor = Color.Gray;
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            textBoxLastName.ForeColor = Color.Black;
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.Black;
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "Email";
                textBoxEmail.ForeColor = Color.Gray;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            textBoxEmail.ForeColor = Color.Black;
        }


        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            string userName = textBoxUsername.Text;
            if (userName.ToLower().Trim().Equals("Username"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            string userName = textBoxUsername.Text;
            if (userName.ToLower().Trim().Equals("Username") || userName.Trim().Equals(""))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.ForeColor = Color.Gray;
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            textBoxUsername.ForeColor = Color.Black;
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("Password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.ForeColor = Color.Black;
        }

        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            string confirmPassword = textBoxPasswordConfirm.Text;
            if (confirmPassword.ToLower().Trim().Equals("Confirm Password") || confirmPassword.ToLower().Trim().Equals("Password") || confirmPassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "Confirm Password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            string confirmPassword = textBoxPasswordConfirm.Text;
            if (confirmPassword.ToLower().Trim().Equals("Confirm Password") || confirmPassword.ToLower().Trim().Equals("Password") || confirmPassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "Confirm Password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasswordConfirm_TextChanged(object sender, EventArgs e)
        {
            textBoxPasswordConfirm.UseSystemPasswordChar = true;
            textBoxPasswordConfirm.ForeColor = Color.Black;
        }



        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void buttonCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount(textBoxUsername.Text, textBoxPassword.Text, textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text);
        }

        public void CreateAccount(string userName,string password,string firstName,string lastName,string email)
        {
            //Add new user
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`, `firstname`, `lastname`, `email`) VALUES (@usn, @pass, @fn, @ln, @email)", db.GetConnection());

            //command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            //command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            //command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            //command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            //command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;


            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = firstName;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lastName;
            command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

            //Open the connection
            db.OpenConnection();

            //Checks if the textboxes contains the default values
            //TODO:Probably need to change the way the information is displayed otherwise user can add funky inputs

            if (!CheckTextBoxValues())
            {

                //Check if the password is the same as the confirm password
                if (textBoxPassword.Text.Equals(textBoxPasswordConfirm.Text))
                {
                    //Check if this username already exists
                    if (CheckUsername())
                    {
                        MessageBox.Show("Username taken,please select a different username");
                        //custom error message
                        //,"Duplicate Username",MessageBoxButtons.OKCancel,MessageBoxIcon.Error
                    }
                    else
                    {
                        //Execute the query
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Account Created");
                        }
                        else
                        {
                            MessageBox.Show("ERROR");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password entered is not the same, try again");
                }

            }
            else
            {
                MessageBox.Show("Please enter your information");
            }



            //close the connection
            db.CloseConnection();

        }

        public bool CheckUsername()
        {
            DB db = new DB();

            string username = textBoxUsername.Text;


            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `username` = @usn", db.GetConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);


            //check if the user is empty
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckTextBoxValues()
        {
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            if (firstName.Equals("First Name") || lastName.Equals("Last Name") || email.Equals("Email") || password.Equals("Password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void labelAccountLogIn_MouseEnter(object sender, EventArgs e)
        {
            labelAccountLogIn.ForeColor = Color.Yellow;
        }

        private void labelAccountLogIn_MouseLeave(object sender, EventArgs e)
        {
            labelAccountLogIn.ForeColor = Color.White;
        }

        private void labelAccountLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
