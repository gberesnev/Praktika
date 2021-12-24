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
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {

                DB db = new DB();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT staff.id_staff AS ID, staff.fam_staff AS Фамилия, staff.name_staff AS Имя, staff.pat_staff AS Отчество, staff.prava_staff AS Права, staff.data_start_staff AS Дата_принятия_на_работу, staff.data_end_staff AS Дата_окончания_работы, staff.inn_staff AS ИНН, staff.snils_staff AS СНИЛС, staff.passport_staff AS Паспорт, staff.number_staff AS Номер, staff.worknumber_staff AS Рабочий_номер, staff.email_staff AS Email, staff.contract_staff AS Договор, roles.name_roles AS Должность, staff.login AS Логин, staff.password AS Пароль, staff.zarplata AS Зарплата FROM staff, roles WHERE staff.Roles_id_roles = roles.id_roles", db.GetConnection());
                adapter.SelectCommand = command;
                MySqlDataAdapter adapterP = new MySqlDataAdapter();
                MySqlCommand commandP = new MySqlCommand("SELECT `name_roles` FROM `roles`", db.GetConnection());
                adapterP.SelectCommand = commandP;
                MySqlDataAdapter adapterR = new MySqlDataAdapter();
                MySqlCommand commandR = new MySqlCommand("SELECT roles.name_roles FROM staff, roles WHERE staff.Roles_id_roles = roles.id_roles", db.GetConnection());
                adapterR.SelectCommand = commandR;


                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "staff");
                DataSet dataSetP = new DataSet();
                adapterP.Fill(dataSetP, "roles");
                DataSet dataSetR = new DataSet();
                adapterR.Fill(dataSetR, "roles");
                
                dataGridView1.DataSource = dataSet.Tables["staff"];
                dataGridView1.AutoResizeColumns();
                

                DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
                combo.HeaderText = "Должность";
                for (int i = 0; i < dataSetP.Tables["roles"].Rows.Count; i++)
                {
                    combo.Items.Add(dataSetP.Tables["roles"].Rows[i]["name_roles"]);
                }
                for (int i = 0; i < dataSetR.Tables["staff"].Rows.Count; i++)
                {
                    combo.DataSource = dataSetR.Tables["staff"].Rows[i]["Roles_id_roles"];
                }
                dataGridView1.Columns.Add(combo);
                this.dataGridView1.Sort(this.dataGridView1.Columns[0], ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DB db = new DB();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT staff.id_staff AS ID, staff.fam_staff AS Фамилия, staff.name_staff AS Имя, staff.pat_staff AS Отчество, staff.prava_staff AS Права, staff.data_start_staff AS Дата_принятия_на_работу, staff.data_end_staff AS Дата_окончания_работы, staff.inn_staff AS ИНН, staff.snils_staff AS СНИЛС, staff.passport_staff AS Паспорт, staff.number_staff AS Номер, staff.worknumber_staff AS Рабочий_номер, staff.email_staff AS Email, staff.contract_staff AS Договор, roles.name_roles AS Должность, staff.login AS Логин, staff.password AS Пароль, staff.zarplata AS Зарплата FROM staff, roles WHERE staff.Roles_id_roles = roles.id_roles", db.GetConnection());

                adapter.SelectCommand = command;

                string id_staff = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string fam_staff = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string name_staff = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string pat_staff = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string prava_staff = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                string date_start = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                if (date_start != "")
                {
                    date_start = DateTime.Parse(date_start).ToString("yyyyMMdd");
                }
                else
                {
                    date_start = null;
                }

                string date_end = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                if (date_end != "")
                {
                    date_end = DateTime.Parse(date_end).ToString("yyyyMMdd");
                }
                else
                {
                    date_end = null;
                }

                string inn_staff = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string snils_staff = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                string passport_staff = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                string number_staff = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                string worknumber_staff = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                string email_staff = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                string contract_staff = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                //string roles = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                string login = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                string password = dataGridView1.CurrentRow.Cells[16].Value.ToString();
                string zarplata = dataGridView1.CurrentRow.Cells[17].Value.ToString();
                string role = dataGridView1.CurrentRow.Cells[18].Value.ToString();


                MySqlDataAdapter adapterC = new MySqlDataAdapter();
                MySqlCommand commandC = new MySqlCommand("SELECT `id_roles` FROM `roles` WHERE `name_roles` = @PR", db.GetConnection());
                commandC.Parameters.Add("@PR", MySqlDbType.VarChar).Value = role;
                adapterC.SelectCommand = commandC;
                DataTable dataTableR = new DataTable();
                adapterC.Fill(dataTableR);
                int idroles = dataTableR.Rows[0].Field<int>("id_roles");


                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("insert `staff` (`id_staff`, `fam_staff`, `name_staff`, `pat_staff`, `prava_staff`, `data_start_staff`, `data_end_staff`, `inn_staff`, `snils_staff`, `passport_staff`, `number_staff`, `worknumber_staff`, `email_staff`, `contract_staff`,`Roles_id_roles`, `login`, `password`, `zarplata`) VALUES (@0U, @1U, @2U, @3U, @4U, @5U, @6U, @7U, @8U, @9U, @10U, @11U, @12U, @13U, @14U, @15U, @16U, @17U)", db.GetConnection());
                command1.Parameters.Add("@0U", MySqlDbType.VarChar).Value = id_staff;
                command1.Parameters.Add("@1U", MySqlDbType.VarChar).Value = fam_staff;
                command1.Parameters.Add("@2U", MySqlDbType.VarChar).Value = name_staff;
                command1.Parameters.Add("@3U", MySqlDbType.VarChar).Value = pat_staff;
                command1.Parameters.Add("@4U", MySqlDbType.VarChar).Value = prava_staff;
                command1.Parameters.Add("@5U", MySqlDbType.VarChar).Value = date_start;
                command1.Parameters.Add("@6U", MySqlDbType.VarChar).Value = date_end;
                command1.Parameters.Add("@7U", MySqlDbType.VarChar).Value = inn_staff;
                command1.Parameters.Add("@8U", MySqlDbType.VarChar).Value = snils_staff;
                command1.Parameters.Add("@9U", MySqlDbType.VarChar).Value = passport_staff;
                command1.Parameters.Add("@10U", MySqlDbType.VarChar).Value = number_staff;
                command1.Parameters.Add("@11U", MySqlDbType.VarChar).Value = worknumber_staff;
                command1.Parameters.Add("@12U", MySqlDbType.VarChar).Value = email_staff;
                command1.Parameters.Add("@13U", MySqlDbType.VarChar).Value = contract_staff;
                command1.Parameters.Add("@14U", MySqlDbType.VarChar).Value = idroles;
                command1.Parameters.Add("@15U", MySqlDbType.VarChar).Value = login;
                command1.Parameters.Add("@16U", MySqlDbType.VarChar).Value = password;
                command1.Parameters.Add("@17U", MySqlDbType.VarChar).Value = zarplata;

                adapter1.SelectCommand = command1;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "staff");

                adapter1.Fill(dataSet, "staff");
                dataSet.Tables["staff"].Clear();
                adapter.Fill(dataSet, "staff");
                DataRow dr = dataSet.Tables[0].NewRow();
                dataSet.Tables[0].Rows.Add(dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dataSet.Tables["staff"];
                dataGridView1.AutoResizeColumns();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
