using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Haziq_FinalProject
{
    public class food
    {
        string fullname;
        int foodAmount;
        decimal price;
       

        public food(string fullname, int foodAmount, decimal price)
        {
            this.fullname = fullname;
            this.foodAmount = foodAmount;
            this.price = price;
        }

        public string Fullname { get => fullname; set => fullname = value; }
        public int FoodAmount { get => foodAmount; set => foodAmount = value; }
        public decimal Price { get => price; set => price = value; }
    }
}
