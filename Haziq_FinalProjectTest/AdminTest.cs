using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using EFDataAcessLibrary.DataAccess;
using Haziq_FinalProject;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using Xunit;

namespace Haziq_FinalProjectTest
{
    public class AdminTest
    {
        private readonly RestaurantContext _db;

        [Fact]
        public void GetAdmin_ShouldGetUsers()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.users", connection);


            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "users");
            string json = JsonConvert.SerializeObject(ds);


            AdminController adminController = new AdminController(_db);
            //Arrange
            string expected = json;

            //Act
            string actual = adminController.GetAdmin();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetReceipt_ShouldGetOrders()
        {
            MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);


            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "orders");
            string json = JsonConvert.SerializeObject(ds);



            AdminController adminController = new AdminController(_db);
            //Arrange
            string expected = json;

            //Act
            string actual = adminController.GetReceipt();

            //Assert
            Assert.Equal(expected, actual);
        }

        //[Fact]
        //public void Admin_ShouldGetOrdersException()
        //{
        //    MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;SSL Mode=None");
        //    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM finalproject_users_db.orders", connection);


        //    connection.Open();
        //    DataSet ds = new DataSet();
        //    adapter.Fill(ds, "orders");
        //    string json = JsonConvert.SerializeObject(ds);



        //    AdminController adminController = new AdminController(_db);
        //    //Arrange
        //    var exception = Assert.Throws<Exception>(() => adminController.GetAdmin());

        //    //Act
        //    string actual = adminController.GetAdmin();

        //    //Assert
        //    Assert.Equal(actual, exception.Message);
        //}


    }
}
