using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IN3TFVB\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public Form2()
        {
            InitializeComponent();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            conn.Open();
            //REMPLISSAGE DU COMBOBOX DES PRODUITS
            SqlCommand cmd2 = conn.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select ProductID,ProductName from Products";
            cmd2.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd2);
            da.Fill(dataTable);
            ComboBox.DataSource = dataTable;
            ComboBox.DisplayMember = "ProductName";
            ComboBox.ValueMember = "ProductID";
            ComboBox.Text = "   --Choisir un Produit--";
            conn.Close();

            //REMPLISSAGE DU COMBOBOX DES CLIENTS
            conn.Open();
            SqlCommand cmd3 = conn.CreateCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.CommandText = "select CustomerID,ContactName from Customers";
            cmd3.ExecuteNonQuery();
            DataTable dataTabl = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
            da1.Fill(dataTabl);
            comboBox1.DataSource = dataTabl;
            comboBox1.DisplayMember = "ContactName";
            comboBox1.ValueMember = "CustomerID";
            comboBox1.Text = "   --Choisir un Client--";

            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd= conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Orders(CustomerID,EmployeeID,OrderDate,ShipRegion) values('"+comboBox1.SelectedValue.ToString()+"','" + textBox2.Text + "','" +dateTimePicker1.Value+ "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();

            SqlCommand cmde = conn.CreateCommand();
            cmde.CommandType = CommandType.Text;
            
            cmde.CommandText = "Select OrderID from Orders where OrderDate='"+dateTimePicker1.Value+"'";
            cmde.ExecuteNonQuery();
           
            SqlCommand cmd1 = conn.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            int OrdID = cmde.ExecuteNonQuery();
           
            //cmd1.CommandText = "insert into [Order Details](OrderID,ProductID,Quantity) values('"+OrdID+"','"+ComboBox.SelectedValue.ToString()+ "','" + textBox4.Text + "')";
            //cmd1.ExecuteNonQuery();


            conn.Close();
            textBox2.Text = "";
            textBox3.Text = "";
            



            MessageBox.Show("La commande a été ajoutée avec succés");
        }

        
        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

   
}
