using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFDataAcessLibrary.DataAccess;
using Haziq_FinalProject;
using RestaurantAPI;
using RestaurantAPI.Controllers;
using Xunit;

namespace Haziq_FinalProjectTest
{
    public class LoginTest
    {
        private readonly RestaurantContext _db;

        public LoginTest()
        {


        }
       
        [Fact]
        public void Login_UserCredentialShouldAuth()
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
        public void Login_UserCredentialShouldAuthMulti(string username, string password,bool expected)
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
    }
}
