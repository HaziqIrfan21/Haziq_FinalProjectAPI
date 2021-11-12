using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/main")]
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

        [Route("getreceipt")]
        [HttpGet]
        public string GetReceipt()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);
               // MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "orders");
                string json = JsonConvert.SerializeObject(ds);
                return json;

                //DataSet ds2 = new DataSet();
                //adapter2.Fill(ds2, "orders");
                //dataGridView2.DataSource = ds2.Tables["orders"];
                //connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
