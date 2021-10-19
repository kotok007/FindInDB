using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net.Mail;
using System.Net;

namespace base_bsmp
{
    public partial class settingForm : Form
    {
        public string ssl;
        static public string connectionStr = @"Data Source=" + Application.StartupPath + @"\Base\base_bsmp.db;Version=3";
        static string query = @"SELECT * FROM settings";
        static SQLiteConnection connection = new SQLiteConnection(connectionStr);
        SQLiteCommand command = new SQLiteCommand(query, connection);
        DataSet dataSet = new DataSet();

        public static class AllVariables
        {
            public static string fileDB;
        }


        public settingForm()
        {
            InitializeComponent();
        }

        private void settingForm_Load(object sender, EventArgs e)
        {
            connection.Open();
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                textBox1.Text = reader[1].ToString();
                textBox2.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox3.Text = reader[5].ToString();
                ssl = reader[4].ToString();
            }
            if (ssl == "True")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля. Все поля обязательны к заполнению.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    ssl = "true";
                }
                else
                {
                    ssl = "False";
                }

                connection.Open();

                string sql = "UPDATE settings SET email='" + textBox1.Text + "', smtpserver='" + textBox2.Text + "', port='" + textBox4.Text + "', ssl='" + ssl + "', password = '" + textBox3.Text + "'";

                SQLiteCommand command1 = new SQLiteCommand(sql, connection);
                command1.ExecuteNonQuery();

                command1.ExecuteNonQuery();

                connection.Close();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Вы заполнили не все поля. Все поля обязательны к заполнению.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string email = textBox1.Text;
                string port = textBox4.Text;
                string smtp = textBox2.Text;
                string password = textBox3.Text;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    using (MailMessage mail = new MailMessage("Проврка <" + email + ">", "kot_ok007@mail.ru"))
                    {
                        mail.Subject = "Проверка";
                        mail.Body = "";
                        mail.IsBodyHtml = false;

                        using (SmtpClient sc = new SmtpClient(smtp, Convert.ToInt16(port)))
                        {
                            if (checkBox1.Checked == true)
                            {
                                sc.EnableSsl = true;
                            }
                            else
                            {
                                sc.EnableSsl = false;
                            }
                            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                            sc.UseDefaultCredentials = true;
                            sc.Credentials = new NetworkCredential(email, password);
                            sc.Send(mail);
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    MessageBox.Show("Соеденение с " + email + " успешно установлено.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception p)
                {
                    //MessageBox.Show("Ошибка. Возможно Вы ввели не корректные данные.", "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(p.Message, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
