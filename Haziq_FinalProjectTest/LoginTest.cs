using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EFDataAcessLibrary.DataAccess;
using Haziq_FinalProject;
using MySql.Data.MySqlClient;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using Xunit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Haziq_FinalProjectTest
{
    public class LoginTest
    {
        private readonly RestaurantContext _db;

        public LoginTest()
        {


        }

        [Fact]
        public void GetLogin_UserCredentialShouldAuth()
        {
            LoginController loginController = new LoginController(_db);

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

        //[Theory]
        //[InlineData("user1", "pass", true)]
        //[InlineData("hello", "hello", true)]
        //[InlineData("adadasd", "asdasddas", false)]
        //public void Login_UserCredentialShouldAuthDBMulti(string username, string password, bool expected)
        //{


        //    LoginController loginController = new LoginController(_db);


        //    //Arrange



        //    //Act
        //    bool actual = loginController.GetLoginDB(username, password);

        //    //Assert
        //    Assert.Equal(expected, actual);

        //    //bool expected = true;

        //    ////Act
        //    //bool actual = true;

        //    ////Assert
        //    //Assert.Equal(expected, actual);

        //}
        [Theory]
        [InlineData("user1","pass",true)]
        [InlineData("hello", "hello", true)]
        [InlineData("asdasdad", "asdadsa", false)]
        [InlineData("", "pass", false)]
        [InlineData("user1", "", false)]
        public void GetLogin_LoginShouldGetUserAuth(string userName,string password,bool expected)
        {

            LoginForm loginForm = new LoginForm();

            loginForm.Login(userName, password);
           bool actual = loginForm.GetLogin(userName, password);
            
            Assert.Equal(expected, actual);
        }
        
    }
}
