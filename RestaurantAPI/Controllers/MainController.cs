using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DatabaseSQL;
using Haziq_FinalProject;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/mainmenu")]
    [ApiController]
    public class MainController : ControllerBase
    {
        // GET: api/<MainController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MainController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MainController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MainController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MainController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("AddToOrder")]
        [HttpPut]
        public void AddToOrder(string userName, string itemName, int qty, decimal price, decimal total)
        {

            //---------//

            //Add new user
            DBAPI db = new DBAPI();
            MySqlCommand command = new MySqlCommand("INSERT INTO `orders` (`UserName`,`ItemName`, `Qty`, `Price`, `TotalPrice`) VALUES (@nme,@itn, @qty, @price, @total_price)", db.GetConnection());

           


            // command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = GetUser();
            command.Parameters.Add("@nme", MySqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = itemName;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
            command.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;
            command.Parameters.Add("@total_price", MySqlDbType.Decimal).Value = total;

            //adapter.SelectCommand = command;


            //adapter.Fill(table);

            //Open the connection
            db.OpenConnection();
            command.ExecuteNonQuery();

            //close the connection
            db.CloseConnection();
        }

        [Route("AddtoOrderDB")]
        [HttpPut]
        public void AddToOrderDB(string name, int qty, decimal price, decimal total)
        {

            //---------//

            //Add new user
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `orders` (`ItemName`, `Qty`, `Price`, `TotalPrice`) VALUES (@itn, @qty, @price, @total_price)", db.GetConnection());

            //command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            //command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            //command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            //command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            //command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;


            // command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = GetUser();
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
            command.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;
            command.Parameters.Add("@total_price", MySqlDbType.Decimal).Value = total;

            //adapter.SelectCommand = command;


            //adapter.Fill(table);

            //Open the connection
            db.OpenConnection();
            command.ExecuteNonQuery();

            //close the connection
            db.CloseConnection();
        }

    }
}
