using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp5;

namespace ChestAuto
{
    public partial class Form1 : Form
    {
        public static string logUser;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser = textBox1.Text;
            String passwordUser = textBox2.Text;
            int a;
            int role;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT id_staff, Roles_id_roles from `staff` WHERE `login` = @uL AND `password` =@uP", db.GetConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passwordUser;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            
            if (table.Rows.Count > 0)
            {

                a = table.Rows[0].Field<int>("id_staff");
                role = table.Rows[0].Field<int>("Roles_id_roles");
                logUser = a.ToString();
                if (role == 1)
                {
                    this.Hide();
                    Login directorForm = new Login();
                    directorForm.Show();
                }
                if (role == 2)
                {
                    this.Hide();
                    Form3 managerForm = new Form3();
                    managerForm.Show();
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный!");

        }
    }
}
