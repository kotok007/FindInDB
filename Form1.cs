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
    public partial class formStart : Form
    {

        //Работа с БД SQLite
        string connectionStr = @"Data Source=" + Application.StartupPath + @"\Base\base_bsmp.db;Version=3";
        string query = @"SELECT fnamber AS '№ истории', year_in AS 'Год обращения', date_in AS 'Дата поступления', section AS 'Поступил в', date_v AS 'Дата выписки', otdelenie AS 'Выписан из', fio AS 'ФИО', age AS 'Возраст', city AS 'Город', adr1 AS 'Адрес проживания',
phone AS 'Телефон', state_work AS 'Место работы', n_diagn AS 'Диагноз по МКБ'
FROM base_bsmp";

        string nowDate = DateTime.Now.ToString("dd MMMM yyyy | Время: HH:mm:ss");
        string patchBD = Application.StartupPath + @"\base\base_bsmp.db";

        SQLiteConnection connection = new SQLiteConnection();
        SQLiteCommand command = new SQLiteCommand();
        DataSet dataSet = new DataSet();


        public formStart()
        {
            Thread fon = new Thread(new ThreadStart(formFonShow));
            fon.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            fon.Abort();
        }

        public void formFonShow()
        {
            Application.Run(new fonStart());
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormStart_Load(object sender, EventArgs e)
        {
            this.Activate();
            this.Text = "Поиск пациентов по БД с 2004 года.Version 2.01";

            try
            {
                SQLiteDataAdapter sqlStacionar = new SQLiteDataAdapter(query, connectionStr);
                sqlStacionar.Fill(dataSet, "base_bsmp");
                dataGridView1.DataSource = dataSet.Tables["base_bsmp"].DefaultView;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[6].Width = 250;
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[10].Width = 80;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
                string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
                this.textBoxAdres.Text = adres;
                this.labeldateVipiski2.Text = dateVipiski;
                this.labelOtdel2.Text = otdelenie;

                int colRows = dataGridView1.RowCount - 1;
                this.statusStrip1.Items[0].Text = "Количество записей в таблице равна  " + colRows;
                this.statusStrip1.Items[1].Text = "| Путь к БД " + patchBD;
                this.statusStrip1.Items[2].Text = "| Сейчас: " + nowDate;
            }
            catch
            {
                MessageBox.Show("Произошел сбой при подключении к БД! Проверте существование файла БД или выберите его и подключите.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                settingForm settingForm = new settingForm();
                settingForm.ShowDialog();
                this.Visible = false;
            }

        }

        private void НастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingForm settingForm = new settingForm();
            settingForm.ShowDialog();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            if (textBoxFind.Text == "")
            {
                MessageBox.Show("Вы не заполнили поле для поиска!", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string textFindZagl = textBoxFind.Text.ToUpper();
                string comandFind = @"SELECT  fnamber AS '№ истории', year_in AS 'Год обращения', date_in AS 'Дата поступления', section AS 'Поступил в', date_v AS 'Дата выписки', otdelenie AS 'Выписан из', fio AS 'ФИО', age AS 'Возраст', city AS 'Город', adr1 AS 'Адрес проживания',
phone AS 'Телефон', state_work AS 'Место работы', n_diagn AS 'Диагноз по МКБ' 
FROM base_bsmp WHERE FIO =  '" + textBoxFind.Text + "%' or fio like '" + textFindZagl + "%'";

                /* Работа с БД SQLServer 2016
                SqlDataAdapter sqlStacionar = new SqlDataAdapter(comandFind, connectionStr);
                DataTable table = new DataTable();
                sqlStacionar.Fill(table);
                DataView search = new DataView(table);

                SqlDataAdapter sqlStacionar = new SqlDataAdapter(connectionStr, query);
                sqlStacionar.Fill(dataSet, "base_bsmp");
                */

                SQLiteDataAdapter sqlStacionar = new SQLiteDataAdapter(comandFind, connectionStr);
                DataTable table = new DataTable();
                sqlStacionar.Fill(table);
                DataView search = new DataView(table);
                dataGridView1.DataSource = search;

                if (dataGridView1.RowCount - 1 == 0)
                {
                    MessageBox.Show("Поиск не дал результатов.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLiteDataAdapter sqlStacionarAll = new SQLiteDataAdapter(query, connectionStr);
                    DataTable tableAll = new DataTable();
                    sqlStacionarAll.Fill(table);
                    DataView searchAll = new DataView(tableAll);
                    dataGridView1.DataSource = search;
                }

                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[6].Width = 250;
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[10].Width = 80;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridView1.Focus();
                string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
                string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
                this.textBoxAdres.Text = adres;
                this.labeldateVipiski2.Text = dateVipiski;
                this.labelOtdel2.Text = otdelenie;

            }

            int colRows = dataGridView1.RowCount - 1;
            this.statusStrip1.Items[0].Text = "Количество записей в таблице равна  " + colRows;
            this.statusStrip1.Items[1].Text = "| Путь к БД " + patchBD;
            this.statusStrip1.Items[2].Text = "| Сейчас: " + nowDate;


        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);

            this.textBoxAdres.Text = adres;
            this.labeldateVipiski2.Text = dateVipiski;
            this.labelOtdel2.Text = otdelenie;
        }

        private void TextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string textFindZagl = textBoxFind.Text.ToUpper();
                string comandFind = @"SELECT  fnamber AS '№ истории', year_in AS 'Год обращения', date_in AS 'Дата поступления', section AS 'Поступил в', date_v AS 'Дата выписки', otdelenie AS 'Выписан из', fio AS 'ФИО', age AS 'Возраст', city AS 'Город', adr1 AS 'Адрес проживания',
phone AS 'Телефон', state_work AS 'Место работы', n_diagn AS 'Диагноз по МКБ' 
FROM base_bsmp WHERE FIO =  '" + textBoxFind.Text + "%' or fio like '" + textFindZagl + "%'";

                SQLiteDataAdapter sqlStacionar = new SQLiteDataAdapter(comandFind, connectionStr);
                DataTable table = new DataTable();
                sqlStacionar.Fill(table);
                DataView search = new DataView(table);

                dataGridView1.DataSource = search;
                if (dataGridView1.RowCount - 1 == 0)
                {
                    MessageBox.Show("Поиск не дал результатов.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SQLiteDataAdapter sqlStacionarAll = new SQLiteDataAdapter(query, connectionStr);
                    DataTable tableAll = new DataTable();
                    sqlStacionarAll.Fill(table);
                    DataView searchAll = new DataView(tableAll);
                    dataGridView1.DataSource = search;
                }

                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[6].Width = 250;
                dataGridView1.Columns[8].Width = 70;
                dataGridView1.Columns[10].Width = 80;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                dataGridView1.Focus();
                string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
                string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
                this.textBoxAdres.Text = adres;
                this.labeldateVipiski2.Text = dateVipiski;
                this.labelOtdel2.Text = otdelenie;

                int colRows = dataGridView1.RowCount - 1;
                this.statusStrip1.Items[0].Text = "Количество записей в таблице равна  " + colRows;
                this.statusStrip1.Items[1].Text = "| Путь к БД " + patchBD;
                this.statusStrip1.Items[2].Text = "| Сейчас: " + nowDate;
            }

            }

        private void ButtonShowAll_Click(object sender, EventArgs e)
        {
                        /* Работа с БД SQLServer 2016
            SqlDataAdapter sqlStacionar = new SqlDataAdapter(comandFind, connectionStr);
            DataTable table = new DataTable();
            sqlStacionar.Fill(table);
            DataView search = new DataView(table);

            SqlDataAdapter sqlStacionar = new SqlDataAdapter(connectionStr, query);
            sqlStacionar.Fill(dataSet, "base_bsmp");
            */

            SQLiteDataAdapter sqlStacionar = new SQLiteDataAdapter(query, connectionStr);
            DataTable table = new DataTable();
            sqlStacionar.Fill(table);
            DataView search = new DataView(table);

            dataGridView1.DataSource = search;
            dataGridView1.Columns[0].Width = 70;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[6].Width = 250;
            dataGridView1.Columns[8].Width = 70;
            dataGridView1.Columns[10].Width = 80;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.ColumnHeadersDefaultCellStyle.Font.FontFamily, 10f, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
            this.textBoxAdres.Text = adres;
            this.labeldateVipiski2.Text = dateVipiski;
            this.labelOtdel2.Text = otdelenie;
            textBoxFind.Clear();

            int colRows = dataGridView1.RowCount - 1;
            this.statusStrip1.Items[0].Text = "Количество записей в таблице равна  " + colRows;
            this.statusStrip1.Items[1].Text = "| Путь к БД " + patchBD;
            this.statusStrip1.Items[2].Text = "| Сейчас: " + nowDate;
        }

        private void ВыйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formFind formFind = new formFind();
            formFind.Text = "Поиск эпикриза";
            formFind.textBoxFioFind.Enabled = false;
            formFind.listBox1.Items.Clear();
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            fio = fio.Substring(0,fio.IndexOf(' '));
            formFind.textBoxFioFind.Text = fio;
            formFind.radioButton1.Checked = true;
            formFind.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formAbout formAbout = new formAbout();
            formAbout.ShowDialog();
        }

        private void ПечатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            //formStart formStart = new formStart();
            string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
            string telefon = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value);
            string mkb = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value);
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            string nomer = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            string datePostupil = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);


            print.labelAdres2.Text = adres;
            print.labeldateVipiski2.Text = dateVipiski;
            print.labelOtdel2.Text = otdelenie;
            print.labelTel2.Text = telefon;
            print.labelMkb2.Text = mkb;
            print.labelFio2.Text = fio;                     
            print.labelNomer2.Text = nomer;
            print.labelPostupil2.Text = datePostupil.Substring(0, datePostupil.IndexOf(' ')); 
            print.Show();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            //formStart formStart = new formStart();
            string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
            string telefon = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value);
            string mkb = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value);
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            string nomer = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            string datePostupil = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);


            print.labelAdres2.Text = adres;
            print.labeldateVipiski2.Text = dateVipiski;
            print.labelOtdel2.Text = otdelenie;
            print.labelTel2.Text = telefon;
            print.labelMkb2.Text = mkb;
            print.labelFio2.Text = fio;
            print.labelNomer2.Text = nomer;
            print.labelPostupil2.Text = datePostupil.Substring(0, datePostupil.IndexOf(' '));
            print.Show();
        }

        private void ПечатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print print = new Print();
            //formStart formStart = new formStart();
            string adres = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value);
            string dateVipiski = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
            string otdelenie = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value);
            string telefon = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value);
            string mkb = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value);
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            string nomer = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            string datePostupil = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);


            print.labelAdres2.Text = adres;
            print.labeldateVipiski2.Text = dateVipiski;
            print.labelOtdel2.Text = otdelenie;
            print.labelTel2.Text = telefon;
            print.labelMkb2.Text = mkb;
            print.labelFio2.Text = fio;
            print.labelNomer2.Text = nomer;
            print.labelPostupil2.Text = datePostupil.Substring(0, datePostupil.IndexOf(' '));
            print.Show();
        }

        private void ПоискЭпикризаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFind formFind = new formFind();
            formFind.Text = "Поиск эпикриза";
            formFind.textBoxFioFind.Enabled = false;
            formFind.listBox1.Items.Clear();
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            fio = fio.Substring(0, fio.IndexOf(' '));
            formFind.textBoxFioFind.Text = fio;
            formFind.radioButton1.Checked = true;
            formFind.ShowDialog();
        }

        private void ПроизвольныйПоискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formFind formFind = new formFind();
            formFind.Text = "Поиск эпикриза";
            formFind.textBoxFioFind.Enabled = true;
            formFind.listBox1.Items.Clear();
            formFind.textBoxFioFind.Text = "";
            formFind.radioButton1.Checked = true;
            formFind.ShowDialog();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            formFind formFind = new formFind();
            formFind.Text = "Поиск эпикриза";
            formFind.textBoxFioFind.Enabled = false;
            formFind.listBox1.Items.Clear();
            string fio = Convert.ToString(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value);
            fio = fio.Substring(0, fio.IndexOf(' '));
            formFind.textBoxFioFind.Text = fio;
            formFind.radioButton1.Checked = true;
            formFind.ShowDialog();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ЖурналОтправкиЭпикризовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJournal sendJournal = new SendJournal();
            sendJournal.ShowDialog();
        }
    }
}
