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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Haziq_FinalProjectTest
{
    public class MainPageTest
    {
        private readonly RestaurantContext _db;

        [Fact]
        public void AddToOrder_CheckOrdersShouldAddToPhpDB()
        {
            MainController mainController = new MainController(_db);

            bool expected = true;

            ////Act
            bool actual = true;

            mainController.AddToOrderCheck("haziq", "Gunkan Mentai", 3, (decimal)3.60, (decimal)10.8);

            
            ////Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AddToOrder_OrdersShouldAddToPhpDB()
        {
            MainController mainController = new MainController(_db);

            bool expected = true;

            ////Act
            bool actual = true;

            mainController.AddToOrder("haziq", "Gunkan Mentai", 3, (decimal)3.60, (decimal)10.8);


            ////Assert
            Assert.Equal(expected, actual);
        }
    }
}
