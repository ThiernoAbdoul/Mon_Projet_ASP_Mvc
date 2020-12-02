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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        Form1 f1;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-IN3TFVB\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public Form3(Form1 frm)
        {
            InitializeComponent();
            this.f1 = frm;
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Orders set CustomerID='" + comboBox1.SelectedValue.ToString() + "',EmployeeID='" + textBox2.Text + "',OrderDate='" + dateTimePicker1.Value + "',ShipRegion='" + textBox3.Text + "'  where OrderID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("La commande a été modifiée avec succés");
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
               
           

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            textBox1.Text = f1.textBox1.Text;

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
    }
}
