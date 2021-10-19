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


namespace base_bsmp
{
    public partial class SendJournal : Form
    {
        static string connectionStr = @"Data Source=" + Application.StartupPath + @"\Base\base_bsmp.db;Version=3";
        //static string sqlJournal = "SELECT id, ot AS 'От', whom AS 'Кому', tema AS 'Тема', date AS 'Дата отправления', file AS 'Файл',FROM sendlogs";
        static string sqlJournal = "SELECT id, ot AS 'От', whom AS 'Кому', tema AS 'Тема', date AS 'Дата отправления', time AS 'Время', file AS 'Файл' FROM sendlogs";
        static string email;
        static string patchFile;

        static SQLiteConnection connection = new SQLiteConnection(connectionStr);
        SQLiteCommand command = new SQLiteCommand(sqlJournal, connection);
        DataSet dataSet = new DataSet();

        public SendJournal()
        {
            InitializeComponent();
            dataGridView1.Cursor = Cursors.Hand;
            dataGridView1.ReadOnly = true;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SendJournal_Load(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataJournal = new SQLiteDataAdapter(sqlJournal, connectionStr);
            dataJournal.Fill(dataSet, "sendlogs");
            dataGridView1.DataSource = dataSet.Tables["sendlogs"].DefaultView;

            dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 70;
            dataGridView1.Columns[6].Width = 270;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12f, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы  действительно хотите очистить журнал?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                SQLiteConnection connection = new SQLiteConnection(connectionStr);
                connection.Open();

                string sql = "DELETE FROM sendlogs";

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlJournal, connectionStr);
                DataTable table = new DataTable();
                adapter.Fill(table);
                DataView search = new DataView(table);
                dataGridView1.DataSource = search;

                dataGridView1.Columns[0].Visible = false;
                //dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[1].Width = 150;
                dataGridView1.Columns[2].Width = 150;
                dataGridView1.Columns[3].Width = 200;
                dataGridView1.Columns[4].Width = 90;
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[6].Width = 270;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.DefaultCellStyle.Font = new Font("Arial", 14F, GraphicsUnit.Pixel);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 12f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }

            }
        }
}
