using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;
using Autofac.Extras.Moq;
using EFDataAcessLibrary.DataAccess;
using EFDataAcessLibrary.Models;
using Haziq_FinalProject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Moq;
using MySql.Data.MySqlClient;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using Xunit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Haziq_FinalProjectTest
{
    public class LoginTest
    {
        private readonly RestaurantContext _db;
        private Mock<RestaurantContext> _mockDb = new Mock<RestaurantContext>();

        public LoginTest()
        {

            // this._db = _db;
        }

        [Fact]
        public void GetLogin_UserCredentialShouldAuth()
        {
            LoginController loginController = new LoginController(_db);

            // var loginController = new LoginController(_mockDb.Object);

            //Arrange
            bool expected = true;

            //Act
            bool actual = loginController.GetLogin("user1", "pass");

            //Assert
            Assert.Equal(expected, actual);


            //bool expected = true;

            ////Act
            //bool actual = true;

            ////Assert
            //Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("user1", "pass", true)]
        [InlineData("hello", "hello", true)]
        [InlineData("adadasd", "asdasddas", false)]
        public void GetLogin_UserCredentialShouldAuthMulti(string username, string password, bool expected)
        {
            LoginController loginController = new LoginController(_db);

            //Arrange


            //Act
            bool actual = loginController.GetLogin(username, password);

            //Assert
            Assert.Equal(expected, actual);

            //bool expected = true;

            ////Act
            //bool actual = true;

            ////Assert
            //Assert.Equal(expected, actual);

        }

        [Fact]
        public void Login_UserCredentialShouldAuthDB()
        {
            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "Login_UserCredentialShouldAuthDB").Options;

            var context = new RestaurantContext(options);

            Seed(context);

            var loginController = new LoginController(context);

            //Seed(Context);

            bool query = loginController.GetLoginDB("user1", "pass");

            //Arrange

            bool expected = true;

            //Act
            // bool actual = loginController.GetLoginDB("user1", "pass");

            //Assert
            Assert.Equal(expected, query);


            //bool expected = true;

            ////Act
            //bool actual = true;

            ////Assert
            //Assert.Equal(expected, actual);



        }

        [Theory]
        [InlineData("user1", "pass", true)]
        [InlineData("hello", "hello", true)]
        [InlineData("asdasdad", "asdadsa", false)]
        [InlineData("", "pass", false)]
        [InlineData("user1", "", false)]
        [InlineData("", "", false)]
        [InlineData(null, null, false)]
        public void Login_UserCredentialShouldAuthDBMulti(string userName, string password, bool expected)
        {

            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "Login_UserCredentialShouldAuthDBMulti").Options;

            var context = new RestaurantContext(options);

            Seed(context);

            var loginController = new LoginController(context);

            //Seed(Context);

            bool query = loginController.GetLoginDB(userName, password);

            //Arrange

            expected = true;

            //Act
            // bool actual = loginController.GetLoginDB("user1", "pass");

            //Assert
            Assert.Equal(expected, query);


            //bool expected = true;

            ////Act
            //bool actual = true;

            ////Assert
            //Assert.Equal(expected, actual);

        }

        private void Seed(RestaurantContext context)
        {
            var customers = new[]
            {


            new Users { UserName = "user1", Password = "pass" },
            new Users { UserName = "hello", Password = "hello"},
             new Users { UserName = "asdasdad", Password = "asdadsa" },
              new Users { UserName = "", Password = "pass" },
                new Users { UserName = "user1", Password = "" },
               new Users { UserName = "", Password = "" },
                 new Users { UserName = null, Password = null },                
             };

            context.User.AddRange(customers);
            context.SaveChanges();
        }
        [Theory]
        [InlineData("user1", "pass", true)]
        [InlineData("hello", "hello", true)]
        [InlineData("asdasdad", "asdadsa", false)]
        [InlineData("", "pass", false)]
        [InlineData("user1", "", false)]
        public void GetLogin_LoginShouldGetUserAuth(string userName, string password, bool expected)
        {

            LoginForm loginForm = new LoginForm();

           // loginForm.Login(userName, password);
            bool actual = loginForm.GetLogin(userName, password);

            Assert.Equal(expected, actual);
        }

    }
}

