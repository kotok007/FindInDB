using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace base_bsmp
{
    public partial class formFind : Form
    {
        public string Txt
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public formFind()
        {
            Program.f3 = this;
            InitializeComponent();
        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            string fio = textBoxFioFind.Text;
            this.listBox1.Items.Clear();
            if (this.textBoxFioFind.Text != "")
            {
                if (radioButton1.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        var result = Directory.GetFiles(@"O:\Отделения\", fio + "*", SearchOption.AllDirectories);
                        foreach (string file in result)
                        {
                            listBox1.Items.Add(file);
                            buttonOpen.Enabled = true;
                            openToolStripMenuItem.Enabled = true;
                        }
                        if (listBox1.Items.Count == 0)
                        {
                            MessageBox.Show("Эпикризов с именем  " + fio + "... не найдено!!!", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            buttonOpen.Enabled = false;
                            openToolStripMenuItem.Enabled = false;
                        }
                            
                    }
                    catch
                    {
                        MessageBox.Show(@"Ошибка! Каталога (O:\Отделения\) не существует или у Вас нет прав доступа к данному каталогу. Обратитесь к Администратору сети.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buttonOpen.Enabled = false;
                        openToolStripMenuItem.Enabled = false;
                    }
                    this.Cursor = Cursors.Default;
                }

                if (radioButton2.Checked)
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        var result = Directory.GetFiles(@"O:\Администрация\Диктофон\", fio + "*", SearchOption.AllDirectories);
                        foreach (string file in result)
                        {
                            listBox1.Items.Add(file);
                            buttonOpen.Enabled = true;
                            openToolStripMenuItem.Enabled = true;
                        }
                        if (listBox1.Items.Count == 0)
                        {
                            MessageBox.Show("Эпикризов с именем  " + fio + "... не найдено!!!", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            buttonOpen.Enabled = false;
                            openToolStripMenuItem.Enabled = false;
                        }
                            
                    }
                    catch
                    {
                        MessageBox.Show(@"Ошибка! Каталога (O:\Администрация\Диктофон\) не существует или у Вас нет прав доступа к данному каталогу. Обратитесь к Администратору сети.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        buttonOpen.Enabled = false;
                        openToolStripMenuItem.Enabled = false;
                    }
                    this.Cursor = Cursors.Default;
                }

            }
            else
            {
                MessageBox.Show("Введите фамилию для поиска.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonOpen.Enabled = false;
                openToolStripMenuItem.Enabled = false;
            }
            this.Activate();
        }


        public void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string selected = listBox1.Items[index].ToString();
            //MessageBox.Show(selected);
            try
            {
                Process.Start(selected);
            }
            catch
            {
                MessageBox.Show(@"Ошибка при открытии файла " +selected, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ОтправитьВЦПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Нет файлов для отправки. Произведите поиск.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sendIn sendIn = new sendIn();
                int index = listBox1.SelectedIndex;
                string selected = listBox1.Items[index].ToString();
                sendIn.selected = selected;
                sendIn.ShowDialog();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("Нет файлов для отправки. Произведите поиск.", "Информация.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                sendIn sendIn = new sendIn();
                int index = listBox1.SelectedIndex;
                string selected = listBox1.Items[index].ToString();
                sendIn.selected = selected;
                sendIn.ShowDialog();
            }
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) 
            {
                buttonOpen.Enabled = false;
                openToolStripMenuItem.Enabled = false;
            }
            else
            {
                buttonOpen.Enabled = true;
                openToolStripMenuItem.Enabled = true;
            }
            this.Activate();
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string selected = listBox1.Items[index].ToString();
            //MessageBox.Show(selected);
            try
            {
                Process.Start(selected);
            }
            catch
            {
                MessageBox.Show(@"Ошибка при открытии файла " + selected, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string selected = listBox1.Items[index].ToString();
            //MessageBox.Show(selected);
            try
            {
                Process.Start(selected);
            }
            catch
            {
                MessageBox.Show(@"Ошибка при открытии файла " + selected, "Ошибка.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
