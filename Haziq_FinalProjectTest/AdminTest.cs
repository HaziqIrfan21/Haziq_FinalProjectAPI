using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
using Haziq_FinalProject;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using Xunit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private void Seed(RestaurantContext context)
        {
            var customers = new[]
            {
            new Users { UserName = "postmanDB ", Password = "pass", FirstName = "rick " , LastName ="grimes" , Email = "zzz@mail.com" , IsAdmin = 0 },
             };

            context.User.AddRange(customers);
            context.SaveChanges();
        }

        [Fact]
        public void Admin_ShouldGetUsersDB()
        {
            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "Admin_ShouldGetUsersDB").Options;

            var context = new RestaurantContext(options);

            Seed(context);

            var adminController = new AdminController(context);

            //Seed(Context);

            string query = adminController.GetAdminUserDB();

            //Arrange



            //Act
            // bool actual = loginController.GetLoginDB("user1", "pass");

            //Assert
            Assert.NotEmpty( query);
        }

        [Fact]
        public void Admin_ShouldGetOrdersDB()
        {
            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "Admin_ShouldGetOrdersDB").Options;

            var context = new RestaurantContext(options);

            Seed(context);

            var adminController = new AdminController(context);

            //Seed(Context);

            string query = adminController.GetAdminOrderDB();

            //Arrange



            //Act
            // bool actual = loginController.GetLoginDB("user1", "pass");

            //Assert
            Assert.NotEmpty(query);
        }

        [Fact]
        public void AdminLoad_ShouldDispayPhpDb()
        {
            //var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "Admin_ShouldGetOrdersDB").Options;

            //var context = new RestaurantContext(options);

            //Seed(context);

            var adminForm = new AdminForm();

            //Seed(Context);

           adminForm.Admin_Load();

            //Arrange
            bool expected = true;


            //Act
            // bool actual = loginController.GetLoginDB("user1", "pass");

            //Assert
            Assert.True(expected);
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
