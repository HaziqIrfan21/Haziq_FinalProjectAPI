using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using DatabaseSQL;
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
    public class RegistrationTest
    {
        private readonly RestaurantContext _db;

        [Theory]
        [InlineData("testUsername1", "testPassword123", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "testPassword123", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("testUsername123", "", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "Password", "Password", "First Name", "Last Name", "Email", false)]
        public void CreateAccount_UserShouldRegister(string userName, string password, string confirmPassword, string firstName, string lastName, string email, bool expected)
        {
            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "CreateAccount_UserShouldRegister").Options;

            var context = new RestaurantContext(options);



            var registerController = new RegisterController(context);

            Seed(context);

            registerController.CreateAccount(userName, password, confirmPassword, firstName, lastName, email);
            bool query = false;

            //Arrange



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
        [InlineData("testUsername1", "testPassword123", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "testPassword123", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("testUsername123", "", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "Password", "Password", "First Name", "Last Name", "Email", false)]
        public void CreateAccount_UserShouldRegisterDb(string userName, string password, string confirmPassword, string firstName, string lastName, string email, bool expected)
        {

            var options = new DbContextOptionsBuilder<RestaurantContext>().UseInMemoryDatabase(databaseName: "CreateAccount_UserShouldRegisterDb").Options;

            var context = new RestaurantContext(options);

            //Seed(context);

            var registerController = new RegisterController(context);

            Seed(context);

            registerController.CreateAccountDB(userName, password, confirmPassword, firstName, lastName, email);
            bool query = false;

            //Arrange



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

        //[Theory]
        //[InlineData("testUsername1", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        //[InlineData("", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        //[InlineData("testUsername123", "", "testFirstname", "testLastname", "testEmail", false)]
        //[InlineData("", "", "testFirstname", "testLastname", "testEmail", false)]
        //[InlineData("", "Password", "First Name", "Last Name", "Email", false)]
        //public void CreateAccount_UserShouldRegisterForm(string userName, string password, string firstName, string lastName, string email, bool expected)
        //{
          
        //    RegisterForm registerForm = new RegisterForm();

        //    registerForm.CreateAccount(userName, password, firstName, lastName, email);


           
        //    bool query = false;

        //    //Arrange


        //    //Act
        //    // bool actual = loginController.GetLoginDB("user1", "pass");

        //    //Assert
        //    Assert.Equal(expected, query);

          

        //    //bool expected = true;

        //    ////Act
        //    //bool actual = true;

        //    ////Assert
        //    //Assert.Equal(expected, actual);
        //}

        [Theory]
        [InlineData("testUsername1", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("testUsername123", "", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "", "testFirstname", "testLastname", "testEmail", false)]
        [InlineData("", "Password", "First Name", "Last Name", "Email", false)]
        public void CheckUsername_UsernameShouldBeUnique(string userName, string password, string firstName, string lastName, string email, bool expected)
        {

            RegisterForm registerForm = new RegisterForm();

            bool query = registerForm.CheckUsername();
                    registerForm.CheckTextBoxValues();
            registerForm.CreateAccount(userName, password, firstName, lastName, email);

            //bool query = false;

            //Arrange


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
                 new Users { UserName = "testUsername1", Password = "testPassword123" ,FirstName = "testFirstname" , LastName = "testLastname" , Email = "testEmail"},
                   new Users { UserName = "", Password = "testPassword123" ,FirstName = "testFirstname Name" , LastName = "testLastname Name" , Email = "testEmail"},
                   new Users { UserName = "testUsername1", Password = "" ,FirstName = "testFirstname Name" , LastName = "testLastname Name" , Email = "testEmail"},
                   new Users { UserName = "", Password = "" ,FirstName = "testFirstname Name" , LastName = "testLastname Name" , Email = "testEmail"},
                     new Users { UserName = "", Password = "Password" ,FirstName = "First Name" , LastName = "Last Name" , Email = "Email"},

             };

            context.User.AddRange(customers);
            context.SaveChanges();
        }

        //[Theory]
        //[InlineData("testUsername", "testPassword", "testPassword123", "testFirstname", "testLastname", "testEmail", false)]
        //[InlineData("", "", "", "", "", "", false)]
        //public void CreateAccount_UserShouldCheckIfAlreadyCreated(string userName, string password, string confirmPassword, string firstName, string lastName, string email,bool expected)
        //{
        //    RegisterController registerController = new RegisterController(null);



        //    DBAPI db = new DBAPI();
        //    //MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`, `firstname`, `lastname`, `email`) VALUES (@usn, @pass, @fn, @ln, @email)", db.GetConnection());



        //    //Arrange
        //   var actual2 = registerController.CreateAccount(userName, password, confirmPassword, firstName, lastName, email);
        //    bool actual = true;
        //    //Act


        //    //Assert
        //    Assert.Equal(expected,actual);
        //}
    }
}
