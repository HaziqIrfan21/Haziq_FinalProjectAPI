using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DatabaseSQL;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
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
        private readonly RestaurantContext _db;
        //// GET: api/<MainController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<MainController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<MainController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MainController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MainController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

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

        [Route("AddToOrderCheck")]
        [HttpGet]
        public bool AddToOrderCheck(string userName, string itemName, int qty, decimal price, decimal total)
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

            if(command.ExecuteNonQuery()==1)
            {
                return true;
            }
            else
            {
                return false;
            }

            //close the connection
            db.CloseConnection();

            return false;
        }

        public MainController(RestaurantContext db)
        {
            _db = db;
        }

        [Route("AddtoOrderDB")]
        [HttpPut]
        public void AddToOrderDB(string userName, string itemName, int qty, decimal price, decimal total, int id)
        {

            //---------//
             Orders orders = new Orders() {UserName = userName,ItemName = itemName, Qty = qty,Price = price,TotalPrice = total ,Id = id};
            
            _db.Order.Add(orders);
            _db.SaveChanges();
            MessageBox.Show("Added to orderDB");
        }

    }
}
