using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseSQL;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly RestaurantContext _db;

        public AdminController(RestaurantContext db)
        {

            _db = db;
        }

        //GET: api/<AdminController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //GET api/<AdminController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST api/<AdminController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //PUT api/<AdminController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE api/<AdminController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [Route("admin")]
        [HttpGet]
        public string GetAdmin()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.users", connection);
                MySqlDataAdapter adapter2 = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);

                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "users");
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

        //REMEMBER TO MOVE THIS TO ADMIN CONTROLLER INSTEAD-----------------------------------------------------------------

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

        [Route("adminUserDB")]
        [HttpGet]
        public string GetAdminUserDB()
        {
            try
            {
                var context = _db.User.ToList();
                string json = JsonConvert.SerializeObject(context);
                return json;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }

        [Route("adminOrderDB")]
        [HttpGet]
        public string GetAdminOrderDB()
        {
            try
            {
                var context = _db.Order.ToList();
                string json = JsonConvert.SerializeObject(context);
                return json;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }

        [Route("adminAddFood")]
        [HttpPost]
        public void PostAddFood(string itemCategory, string itemName, string itemDescription, decimal itemPrice)
        {
            try
            {
                Items items = new Items() { ItemCategory = itemCategory, ItemName = itemName, ItemDescription = itemDescription, ItemPrice = itemPrice };
                _db.Item.Add(items);
                _db.SaveChanges();
            }
            catch (Exception)
            {

                throw;  
            }
        }

        [Route("adminGetUserOrderList")]
        [HttpGet]
        public string AdminGetUserOrders(int userId)
        {
            try
            {
                var order = _db.Order.Where(p => p.UsersId == userId);

                string json = JsonConvert.SerializeObject(order);
                return json;
            }
            catch (Exception)
            {

                throw;
            }
        }



    }

}
