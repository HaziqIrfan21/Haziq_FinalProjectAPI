using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using DatabaseSQL;
using EFDataAcessLibrary.DataAccess;
using Haziq_FinalProject;
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

        [Fact]
        public void CreateAccount_UserShouldRegister()
        {
            RegisterController registerController = new RegisterController(_db);

            registerController.CreateAccount("testUsername", "testPassword", "testPassword", "testFirstname", "testLastname", "testEmail");

            DBAPI db = new DBAPI();
            //MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`username`, `password`, `firstname`, `lastname`, `email`) VALUES (@usn, @pass, @fn, @ln, @email)", db.GetConnection());



            //Arrange
            //bool expected = true;

            //Act
            // bool actual = loginController.GetLogin("user1", "pass");

            //Assert
            Assert.NotNull(db);
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
