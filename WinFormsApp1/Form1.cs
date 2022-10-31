using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Use a string to store the connection info
        string connstring = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=Universitate;Integrated Security=true";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Get query as JSON data
        private void button1_Click(object sender, EventArgs e)
        {  
            // Create a new SqlConnection object
            SqlConnection con = new SqlConnection(connstring);
            
            // Open a new connection
            con.Open();

            // Do the necessary queries

            string query1 = "SELECT * FROM Student WHERE Id=@Id FOR JSON PATH, ROOT('Student')";
            SqlCommand cmd = new SqlCommand(query1);
            cmd.Parameters.AddWithValue("@Id", idInput.Text);
            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();
            MessageBox.Show("Generated JSON file");
        }

        private void idInput_TextChanged(object sender, EventArgs e)
        {

        }

        // Calculate average on button press
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connstring);
            con.Open();

            string id = idInput.Text;
            string query1 = "SELECT SUM(Nota)/COUNT(Nota) FROM Note WHERE ID=" + id + ";";
            SqlCommand cmd = new SqlCommand(query1);
            SqlDataReader reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                MessageBox.Show(reader1.ToString());
            }
            else MessageBox.Show("No data found");

            con.Close();
        }
    }
}