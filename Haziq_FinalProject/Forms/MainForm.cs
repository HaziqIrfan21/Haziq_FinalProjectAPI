using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySqlX.XDevAPI.Relational;

namespace Haziq_FinalProject
{
    public partial class MainForm : Form
    {

        int autoID = 1;
        string catagory;
        string orderName;
        string fullname;
        int foodAmount;
        decimal price;

        int foodDeleteNumber = 0;
        decimal foodDeleteCost;
        bool foodDeleted = false;

        public List<food> foodList = new List<food>();

        bool bGunkan3 = false;
        bool bGunkan2 = false;
        bool bGunkan1 = false;

        bool bMakimono5 = false;
        bool bMakimono4 = false;
        bool bMakimono3 = false;
        bool bMakimono2 = false;
        bool bMakimono1 = false;

        bool bNigiri6 = false;
        bool bNigiri5 = false;
        bool bNigiri4 = false;
        bool bNigiri3 = false;
        bool bNigiri2 = false;
        bool bNigiri1 = false;





        public MainForm()
        {
            InitializeComponent();

            //MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=finalproject_users_db;SSL Mode=None");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Black;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanelNigiri.Hide();
            flowLayoutPanelGunkan.Hide();
            flowLayoutPanelMakimono.Hide();
            panelBill.Hide();

        }

        private void buttonNigiri_Click(object sender, EventArgs e)
        {
            flowLayoutPanelNigiri.Show();
            flowLayoutPanelGunkan.Hide();
            flowLayoutPanelMakimono.Hide();
        }

        private void buttonGunkan_Click(object sender, EventArgs e)
        {
            flowLayoutPanelNigiri.Hide();
            flowLayoutPanelGunkan.Show();
            flowLayoutPanelMakimono.Hide();

        }

        private void buttonMakimono_Click(object sender, EventArgs e)
        {
            flowLayoutPanelNigiri.Hide();
            flowLayoutPanelGunkan.Hide();
            flowLayoutPanelMakimono.Show();
        }





        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void DeleteOrder()
        {

            listBoxOrder.Items.Clear();
            foodList.Clear();

            foodDeleted = false;
        }
        private void buttonNigiri1_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri1.Text, int.Parse(textBoxNigiri1.Text), decimal.Parse(labelPriceNigiri1.Text), new food(fullname, foodAmount, price), bNigiri1);

                bNigiri1 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonNigiri2_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri2.Text, int.Parse(textBoxNigiri2.Text), decimal.Parse(labelPriceNigiri2.Text), new food(fullname, foodAmount, price), bNigiri2);

                bNigiri2 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonNigiri3_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri3.Text, int.Parse(textBoxNigiri3.Text), decimal.Parse(labelPriceNigiri3.Text), new food(fullname, foodAmount, price), bNigiri3);

                bNigiri3 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonNigiri4_Click(object sender, EventArgs e)
        {


            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri4.Text, int.Parse(textBoxNigiri4.Text), decimal.Parse(labelPriceNigiri4.Text), new food(fullname, foodAmount, price), bNigiri4);

                bNigiri4 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonNigiri5_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri5.Text, int.Parse(textBoxNigiri5.Text), decimal.Parse(labelPriceNigiri5.Text), new food(fullname, foodAmount, price), bNigiri5);

                bNigiri5 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonNigiri6_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonNigiri.Text, labelNameNigiri6.Text, int.Parse(textBoxNigiri6.Text), decimal.Parse(labelPriceNigiri6.Text), new food(fullname, foodAmount, price), bNigiri6);

                bNigiri6 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonMakimono1_Click(object sender, EventArgs e)
        {
            try
            {
                AddFood(buttonMakimono.Text, labelNameMakimono1.Text, int.Parse(textBoxMakimono1.Text), decimal.Parse(labelPriceMakimono1.Text), new food(fullname, foodAmount, price), bMakimono1);

                bMakimono1 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMakimono2_Click(object sender, EventArgs e)
        {
            try
            {
                AddFood(buttonMakimono.Text, labelNameMakimono2.Text, int.Parse(textBoxMakimono2.Text), decimal.Parse(labelPriceMakimono2.Text), new food(fullname, foodAmount, price), bMakimono2);

                bMakimono2 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMakimono3_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonMakimono.Text, labelNameMakimono3.Text, int.Parse(textBoxMakimono3.Text), decimal.Parse(labelPriceMakimono3.Text), new food(fullname, foodAmount, price), bMakimono3);

                bMakimono3 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMakimono4_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonMakimono.Text, labelNameMakimono4.Text, int.Parse(textBoxMakimono4.Text), decimal.Parse(labelPriceMakimono4.Text), new food(fullname, foodAmount, price), bMakimono4);

                bMakimono4 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonMakimono5_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonMakimono.Text, labelNameMakimono5.Text, int.Parse(textBoxMakimono5.Text), decimal.Parse(labelPriceMakimono5.Text), new food(fullname, foodAmount, price), bMakimono5);

                bMakimono5 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonGunkan1_Click(object sender, EventArgs e)
        {


            try
            {
                AddFood(buttonGunkan.Text, labelNameGunkan1.Text, int.Parse(textBoxGunkan1.Text), decimal.Parse(labelPriceGunkan1.Text), new food(fullname, foodAmount, price), bGunkan1);

                bGunkan1 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonGunkan2_Click(object sender, EventArgs e)
        {

            try
            {
                AddFood(buttonGunkan.Text, labelNameGunkan2.Text, int.Parse(textBoxGunkan2.Text), decimal.Parse(labelPriceGunkan2.Text), new food(fullname, foodAmount, price), bGunkan2);

                bGunkan2 = true;
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonGunkan3_Click(object sender, EventArgs e)
        {
            try
            {

                AddFood(buttonGunkan.Text, labelNameGunkan3.Text, int.Parse(textBoxGunkan3.Text), decimal.Parse(labelPriceGunkan3.Text), new food(fullname, foodAmount, price), bGunkan3);

                bGunkan3 = true;




            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }
        //Parameters are buttonName.text, LabelName.text, textbox.text
        private void AddFood(string catagory, string orderName, int foodAmount, decimal price, food foodType, bool isFoodActive)
        {
            try
            {
                //catagory = buttonGunkan.Text;
                //orderName = labelNameGunkan3.Text;
                fullname = catagory + " " + orderName;
                //foodAmount = int.Parse(textBoxGunkan3.Text);

                price = price * foodAmount;

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    if (isFoodActive == true)
                    {
                        foreach (var item in foodList)
                        {
                            if (item.Fullname == fullname)
                            {
                                for (int i = 0; i < foodAmount; i++)
                                {
                                    listBoxOrder.Items.Add(item.Fullname);
                                }

                                item.FoodAmount += foodAmount;
                                item.Price += price;
                            }
                        }


                    }

                    if (isFoodActive == false)
                    {
                        foodType = new food(fullname, foodAmount, price);

                        for (int i = 0; i < foodAmount; i++)
                        {
                            listBoxOrder.Items.Add(foodType.Fullname);
                        }

                        foodList.Add(foodType);
                        isFoodActive = true;
                    }
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }
        private void buttonMinusNigiri6_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri6.Text, int.Parse(textBoxNigiri6.Text), decimal.Parse(labelPriceNigiri6.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusNigiri5_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri5.Text, int.Parse(textBoxNigiri5.Text), decimal.Parse(labelPriceNigiri5.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusNigiri4_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri4.Text, int.Parse(textBoxNigiri4.Text), decimal.Parse(labelPriceNigiri4.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusNigiri3_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri3.Text, int.Parse(textBoxNigiri3.Text), decimal.Parse(labelPriceNigiri3.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusNigiri2_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri2.Text, int.Parse(textBoxNigiri2.Text), decimal.Parse(labelPriceNigiri2.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusNigiri1_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonNigiri.Text, labelNameNigiri1.Text, int.Parse(textBoxNigiri1.Text), decimal.Parse(labelPriceNigiri1.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }
        private void buttonMinusMakimono5_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonMakimono.Text, labelNameMakimono5.Text, int.Parse(textBoxMakimono5.Text), decimal.Parse(labelPriceMakimono5.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusMakimono4_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonMakimono.Text, labelNameMakimono4.Text, int.Parse(textBoxMakimono4.Text), decimal.Parse(labelPriceMakimono4.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusMakimono3_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonMakimono.Text, labelNameMakimono3.Text, int.Parse(textBoxMakimono3.Text), decimal.Parse(labelPriceMakimono3.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusMakimono2_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonMakimono.Text, labelNameMakimono2.Text, int.Parse(textBoxMakimono2.Text), decimal.Parse(labelPriceMakimono2.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusMakimono1_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonMakimono.Text, labelNameMakimono1.Text, int.Parse(textBoxMakimono1.Text), decimal.Parse(labelPriceMakimono1.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusGunkan1_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonGunkan.Text, labelNameGunkan1.Text, int.Parse(textBoxGunkan1.Text), decimal.Parse(labelPriceGunkan1.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusGunkan2_Click(object sender, EventArgs e)
        {
            try
            {
                MinusFood(buttonGunkan.Text, labelNameGunkan2.Text, int.Parse(textBoxGunkan2.Text), decimal.Parse(labelPriceGunkan2.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }

        private void buttonMinusGunkan3_Click(object sender, EventArgs e)
        {

            //    catagory = buttonGunkan.Text;
            //    orderName = labelNameGunkan3.Text;
            //    fullname = catagory + " " + orderName;
            //    foodAmount = int.Parse(textBoxGunkan3.Text);

            try
            {
                MinusFood(buttonGunkan.Text, labelNameGunkan3.Text, int.Parse(textBoxGunkan3.Text), decimal.Parse(labelPriceGunkan3.Text));
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }


        }

        public void MinusFood(string catagory, string orderName, int foodAmount, decimal price)
        {
            try
            {

                fullname = catagory + " " + orderName;



                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    if (foodDeleted == false)
                    {
                        foreach (var item in foodList.ToList())
                        {
                            if (item.Fullname == fullname)
                            {
                                for (int i = foodAmount; i > 0; i--)
                                {
                                    listBoxOrder.Items.Remove(item.Fullname);

                                }

                                //foodDeleteCost = item.Price;
                                item.FoodAmount -= foodAmount;

                                if (item.FoodAmount < 0)
                                {
                                    item.FoodAmount = 0;
                                    foodDeleteCost = 0;
                                    foodList.Remove(item);
                                   

                                }

                                item.Price -= price * foodAmount;

                            }

                        }

                    }
                }


            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }
        }



        private void buttonBill_Click(object sender, EventArgs e)
        {
            panelBill.Show();
        }

        private void labelBillExit_Click(object sender, EventArgs e)
        {
            panelBill.Hide();
        }

        private void labelBillExit_MouseEnter(object sender, EventArgs e)
        {
            labelBillExit.ForeColor = Color.White;
        }

        private void labelBillExit_MouseLeave(object sender, EventArgs e)
        {
            labelBillExit.ForeColor = Color.Black;
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            Order();
        }

        public void Order()
        {
            String.Format("{0:0.00}", labelCostAmount.Text);

            listBoxOrder.Items.Clear();

            foreach (var item in foodList)
            {
                {
                    //Item.price is already the final price
                    if(item.FoodAmount>0)
                    AddToListView(item.Fullname, item.FoodAmount - foodDeleteNumber, item.Price - foodDeleteCost);
                }
            }


            bGunkan3 = false;
            bGunkan2 = false;
            bGunkan1 = false;

            bMakimono5 = false;
            bMakimono4 = false;
            bMakimono3 = false;
            bMakimono2 = false;
            bMakimono1 = false;

            bNigiri6 = false;
            bNigiri5 = false;
            bNigiri4 = false;
            bNigiri3 = false;
            bNigiri2 = false;
            bNigiri1 = false;

            foodAmount = 0;
            foodDeleteNumber = 0;
            foodDeleteCost = 0;
            foodList.Clear();
        }

        private void AddToListView(string name, int qty, decimal price)
        {

            ListViewItem eachrow = new ListViewItem("" + autoID);
            ListViewItem.ListViewSubItem rowName = new ListViewItem.ListViewSubItem(eachrow, name);
            ListViewItem.ListViewSubItem rowQty = new ListViewItem.ListViewSubItem(eachrow, qty.ToString());
            ListViewItem.ListViewSubItem rowPrice = new ListViewItem.ListViewSubItem(eachrow, price.ToString());

            eachrow.SubItems.Add(rowName);
            eachrow.SubItems.Add(rowQty);
            eachrow.SubItems.Add(rowPrice);

            decimal temp;
            temp = decimal.Parse(rowPrice.Text);

            decimal temp2;
            temp2 = decimal.Parse(labelCostAmount.Text);

            decimal total;
            total = temp + temp2;

            labelCostAmount.Text = total.ToString();

            listViewBill.Items.Add(eachrow);

            autoID += 1;

            //---------//

            //Add new user
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `orders` (`ItemName`, `Qty`, `Price`, `TotalPrice`) VALUES (@itn, @qty, @price, @total_price)", db.GetConnection());

            //command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = textBoxUsername.Text;
            //command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPassword.Text;
            //command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = textBoxFirstName.Text;
            //command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = textBoxLastName.Text;
            //command.Parameters.Add("@email", MySqlDbType.VarChar).Value = textBoxEmail.Text;


            // command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = GetUser();
            command.Parameters.Add("@itn", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@qty", MySqlDbType.Int32).Value = qty;
            command.Parameters.Add("@price", MySqlDbType.Decimal).Value = price;
            command.Parameters.Add("@total_price", MySqlDbType.Decimal).Value = total;

            //adapter.SelectCommand = command;


            //adapter.Fill(table);

            //Open the connection
            db.OpenConnection();
            command.ExecuteNonQuery();

            //close the connection
            db.CloseConnection();

            //========//

        }
    }
}
