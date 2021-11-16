using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DatabaseSQL;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
using Haziq_FinalProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly RestaurantContext _db;

        public LoginController(RestaurantContext db)
        {

            _db = db;
        }

        [Route("getDB")]
        [HttpPost]
        public void OnGet()
        {
            LoadSampleData();

            //var people = _db.User.ToList();
        }

        private void LoadSampleData()
        {

            string file = System.IO.File.ReadAllText("users.json");
            var user = JsonSerializer.Deserialize<List<Users>>(file);
            _db.AddRange(user);
            _db.SaveChanges();



        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        [Route("login")]
        [HttpGet]
        public bool GetLogin(string userName, string password)
        {
            DBAPI db = new DBAPI();

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
                    return true;
                }
                //User Control
                else
                {
                    return true;
                }

            }

            else
            {
                return false;

            }
        }

        [Route("loginDB")]
        [HttpGet]
        public bool GetLoginDB(string userName, string password)
        {
            // Users Users = new Users();

            var users = _db.User.Where(p => p.UserName == userName && p.Password == password);
            


            foreach (var item in users)
            {
                if (item.UserName == userName && item.Password == password)
                {
                    //Admin Control
                    if (userName == "user1" && password == "pass")
                    {
                        return true;
                    }
                    //User Control
                    else
                    {
                        return true;
                    }
                }

                else
                {
                    return false;

                }
            }

            return false;

        }


    }


}





