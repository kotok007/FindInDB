using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Threading;
using System.Net.Mail;
using System.Net;


namespace base_bsmp
{
    public partial class sendIn : Form
    {
        public string selected;

        string connectionStr = @"Data Source=" + Application.StartupPath + @"\Base\base_bsmp.db;Version=3";
        string query = @"SELECT id AS 'Номер', nazvanie AS 'Название', email AS 'E-mail' from hospital";

        string nowDate = DateTime.Now.ToString("dd MMMM yyyy | Время: HH:mm:ss");
        string patchBD = Application.StartupPath + @"\base\base_bsmp.db";

        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();
        DataSet dataSet = new DataSet();

        public sendIn()
        {
            
            InitializeComponent();
        }

        private void SendIn_Load(object sender, EventArgs e)
        {
            formFind formFind = new formFind();
            //string selected1 = formFind.selected;
            try
            {
                SQLiteDataAdapter sqlStacionar = new SQLiteDataAdapter(query, connectionStr);
                sqlStacionar.Fill(dataSet, "hospital");
                dataGridView1.DataSource = dataSet.Tables["hospital"].DefaultView;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 250;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            }
            catch
            {
                MessageBox.Show("Произошел сбой при подключении к БД! Проверте существование файла БД или выберите его и подключите.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            formFind formFind = new formFind();

            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToShortDateString();
            string time = dateTime.ToShortTimeString();
            string tema = "";
            string Email = "";
            string Smtp = "";
            string Port = "";
            string Pass = "";
            string Ssl = "";

            string querySet = @"SELECT * FROM settings";
            SQLiteConnection connectionSet = new SQLiteConnection(connectionStr);
            SQLiteCommand commandSet = new SQLiteCommand(querySet, connectionSet);
            DataSet dataSet = new DataSet();

            connectionSet.Open();
            SQLiteDataReader reader = commandSet.ExecuteReader();

            while (reader.Read())
            {

                Email = reader[1].ToString();
                Smtp = reader[2].ToString();
                Port = reader[3].ToString();
                Pass = reader[5].ToString();
                Ssl = reader[4].ToString();
            }
            if (Ssl == "True")
            {

            }
            else
            {

            }

            reader.Close();
            connectionSet.Close();

            string email = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
            //MessageBox.Show(email, "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                using (MailMessage mm = new MailMessage("Отправка эпикриза "+Email, email))
                {
                    if (textTema.Text.Length != 0)
                    {
                        tema = textTema.Text;
                        mm.Subject = tema;
                    }
                    else
                    {
                        tema = "Отправка эпикриза";
                        mm.Subject = tema;
                    }
                    
                    mm.Body = "Это письмо было сформировано автоматически и не требует ответа или подтверждения. ";
                    mm.IsBodyHtml = false;
                    mm.Attachments.Add(new Attachment(selected));

                    using (SmtpClient sc = new SmtpClient(Smtp, Convert.ToInt16(Port)))
                    {
                        sc.EnableSsl = true;
                        sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                        sc.UseDefaultCredentials = false;
                        sc.Credentials = new NetworkCredential(Email, Pass);
                        sc.Send(mm);
                    }
                }
                MessageBox.Show("Сообщение успешно отправлено", "Выполнено!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Добавляем код добавления записи в журнал отправки
                try
                {
                    SQLiteConnection connection = new SQLiteConnection(connectionStr);
                    connection.Open();

                    string sql = @"INSERT INTO sendlogs (date, time, whom, ot, tema, file) VALUES ('" + date + "','" + time + "', '" + email + "'," +
                        "'bolnica-smp@mail.ru', '" + tema + "', '" + selected + "')";

                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка добавление информации о письме в журнал.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при отправке почты!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string id = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);

            if (MessageBox.Show("Вы действительно хотите удалить данную запись?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SQLiteConnection connection = new SQLiteConnection(connectionStr);
                connection.Open();

                string sql = "DELETE FROM hospital WHERE id=" + id + "";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connectionStr);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataView search = new DataView(table);
                dataGridView1.DataSource = search;
            }
            else
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textNazvanie.Text == "" || textEmail.Text == "" )
            {
                MessageBox.Show("Вы заполнили не все поля!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SQLiteConnection connection = new SQLiteConnection(connectionStr);
                connection.Open();

                string sql = "INSERT INTO hospital (nazvanie, email) VALUES ('" + textNazvanie.Text + "','" + textEmail.Text + "')";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connectionStr);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataView search = new DataView(table);
                dataGridView1.DataSource = search;
                textEmail.Text = "";
                textNazvanie.Text = "";
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            SendJournal sendJournal = new SendJournal();
            sendJournal.ShowDialog();
        }
    }
}
