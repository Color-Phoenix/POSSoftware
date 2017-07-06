using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MenuPanel1
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Font myFont = new Font(textBox1.Font, FontStyle.Underline);
            textBox1.Font = myFont;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString.mysqlConnection);
                MySqlCommand command = new MySqlCommand("select * from section", conn);
                conn.Open();

                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.HasRows)
                    {
                        textBox4.Text = dr[2].ToString();
                    }
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
