using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Linq;

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

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void buttonNigiri1_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri1.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);
        }

        private void buttonDeleteOrder_Click(object sender, EventArgs e)
        {
            if (listBoxOrder.SelectedIndex == -1)
            {
                MessageBox.Show("You have not ordered anything. Try again");
            }

            if (listBoxOrder.SelectedIndex > -1)
            {
                //listBoxOrder.Items.RemoveAt(listBoxOrder.SelectedIndex);
                //foodDeleteNumber++;            
                //foodDeleted = true;
                ////   foodAmount--;

            }
            listBoxOrder.Items.Clear();
            foodList.Clear();

            foodDeleted = false;
        }

        private void buttonNigiri2_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri2.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);
        }

        private void buttonNigiri3_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri3.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);
        }

        private void buttonNigiri4_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri4.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);
        }

        private void buttonNigiri5_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri5.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);
        }

        private void buttonNigiri6_Click(object sender, EventArgs e)
        {

            catagory = buttonNigiri.Text;
            orderName = labelNameNigiri6.Text;

            listBoxOrder.Items.Add(catagory + " " + orderName);

        }

        private void buttonMakimono1_Click(object sender, EventArgs e)
        {
            try
            {
                catagory = buttonMakimono.Text;
                orderName = labelNameMakimono1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxMakimo1.Text);

                price = decimal.Parse(labelPriceMakimono1.Text) * foodAmount;
                food makimo1 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(makimo1.Fullname);
                    }

                    foodList.Add(makimo1);
                }
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
                catagory = buttonMakimono.Text;
                orderName = labelNameMakimono1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxMakimo2.Text);

                price = decimal.Parse(labelPriceMakimono2.Text) * foodAmount;
                food makimo2 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(makimo2.Fullname);
                    }

                    foodList.Add(makimo2);
                }
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
                catagory = buttonMakimono.Text;
                orderName = labelNameMakimono1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxMakimo3.Text);

                price = decimal.Parse(labelPriceMakimono4.Text) * foodAmount;
                food makimo3 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(makimo3.Fullname);
                    }

                    foodList.Add(makimo3);
                }
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

                catagory = buttonMakimono.Text;
                orderName = labelNameMakimono1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxMakimo4.Text);

                price = decimal.Parse(labelPriceMakimono4.Text) * foodAmount;
                food makimo4 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(makimo4.Fullname);
                    }

                    foodList.Add(makimo4);
                }
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

                catagory = buttonMakimono.Text;
                orderName = labelNameMakimono1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxMakimo5.Text);

                price = decimal.Parse(labelPriceMakimono5.Text) * foodAmount;
                food makimo5 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(makimo5.Fullname);
                    }

                    foodList.Add(makimo5);
                }
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
                catagory = buttonGunkan.Text;
                orderName = labelNameGunkan1.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxGunkan1.Text);

                price = decimal.Parse(labelPriceGunkan1.Text) * foodAmount;
                food gunkan1 = new food(fullname, foodAmount, price);

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(gunkan1.Fullname);
                    }

                    foodList.Add(gunkan1);
                }
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
                catagory = buttonGunkan.Text;
                orderName = labelNameGunkan2.Text;
                fullname = catagory + " " + orderName;
                foodAmount = int.Parse(textBoxGunkan2.Text);

                price = decimal.Parse(labelPriceGunkan2.Text) * foodAmount;
                food gunkan2 = new food(fullname, foodAmount, price);
                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    for (int i = 0; i < foodAmount; i++)
                    {
                        listBoxOrder.Items.Add(gunkan2.Fullname);
                    }

                    foodList.Add(gunkan2);
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Please insert food amount");
            }

        }

        private void buttonGunkan3_Click(object sender, EventArgs e)
        {
            AddFood(buttonGunkan.Text, labelNameGunkan3.Text, int.Parse(textBoxGunkan3.Text), decimal.Parse(labelPriceGunkan3.Text));
        }
        //Parameters are buttonName.text, LabelName.text, textbox.text
        private void AddFood(string catagory,string orderName, int foodAmount, decimal price)
        {
            try
            {
                //catagory = buttonGunkan.Text;
                //orderName = labelNameGunkan3.Text;
                fullname = catagory + " " + orderName;
                //foodAmount = int.Parse(textBoxGunkan3.Text);

                price = price  * foodAmount;

                if (foodAmount <= 0)
                {
                    MessageBox.Show("Please insert correct food amount");
                }
                else
                {
                    if (bGunkan3 == true)
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

                    if (bGunkan3 == false)
                    {
                        food gunkan3 = new food(fullname, foodAmount, price);

                        for (int i = 0; i < foodAmount; i++)
                        {
                            listBoxOrder.Items.Add(gunkan3.Fullname);
                        }

                        foodList.Add(gunkan3);
                        bGunkan3 = true;
                    }
                }
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

            MinusFood(buttonGunkan.Text, labelNameGunkan3.Text, int.Parse(textBoxGunkan3.Text), decimal.Parse(labelPriceGunkan3.Text));
        }

        public void MinusFood(string catagory, string orderName, int foodAmount, decimal price)
        {
            try
            {

                fullname = catagory + " " + orderName;
                price = price * foodAmount;
                foodDeleteCost = price * -1;

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

                                item.FoodAmount -= foodAmount;
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
                    AddToListView(item.Fullname, item.FoodAmount - foodDeleteNumber, item.Price + foodDeleteCost);
                }
            }

            bGunkan3 = false;
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

        }

        private void flowLayoutPanelGunkan_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
