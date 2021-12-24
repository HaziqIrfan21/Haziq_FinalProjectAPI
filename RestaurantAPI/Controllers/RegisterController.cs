using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseSQL;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
using Haziq_FinalProject;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly RestaurantContext _db;

        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ValuesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public RegisterController(RestaurantContext db)
        {
            _db = db;
        }

        [Route("registerDB")]
        [HttpPut]
        public void CreateAccountDB(string userName, string password, string confirmPassword, string firstName, string lastName, string email)
        {
            Users user = new Users() { UserName = userName, Password = password, FirstName = firstName, LastName = lastName, Email = email };

            bool users = _db.User.Any(p => p.UserName == userName);



            if (!CheckTextBoxValues(firstName, lastName, email, password))
            {

                //Check if the password is the same as the confirm password
                if (password == confirmPassword)
                {
                    //Check if this username already exists
                    if (users)
                    {
                        MessageBox.Show("Username taken,please select a different username");
                        //custom error message
                        //,"Duplicate Username",MessageBoxButtons.OKCancel,MessageBoxIcon.Error
                    }
                    else
                    {
                        //Execute the query
                        _db.User.Add(user);
                        _db.SaveChanges();
                        MessageBox.Show("Account Created");


                    }
                }
                else
                {
                    MessageBox.Show("Password entered is not the same, try again");
                }

            }
            else
            {

            }
            {
                MessageBox.Show("Please enter your information");
            }
           
        }



        [Route("register")]
        [HttpPut]
        public void CreateAccount(string userName, string password, string confirmPassword, string firstName, string lastName, string email)
        {
            //Add new user
            DBAPI db = new DBAPI();
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

            if (!CheckTextBoxValues(firstName, lastName, email, password))
            {

                //Check if the password is the same as the confirm password
                if (password == confirmPassword)
                {
                    //Check if this username already exists
                    if (CheckUsername(userName))
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
        [Route("checkusername")]
        [HttpGet]
        public bool CheckUsername(string username)
        {
            DBAPI db = new DBAPI();

            //string username = textBoxUsername.Text;


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
        [Route("checktextbox")]
        [HttpGet]
        public bool CheckTextBoxValues(string firstName, string lastName, string email, string password)
        {
            //string firstName = textBoxFirstName.Text;
            //string lastName = textBoxLastName.Text;
            //string email = textBoxEmail.Text;
            //string password = textBoxPassword.Text;

            if (firstName == ("First Name") || lastName == ("Last Name") || email == ("Email") || password == ("Password"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
