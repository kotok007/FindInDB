namespace base_bsmp
{
    partial class formFind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formFind));
            this.labelFio = new System.Windows.Forms.Label();
            this.textBoxFioFind = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.отправитьВЦПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxPatch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonFind = new System.Windows.Forms.Button();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBoxPatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelFio
            // 
            this.labelFio.AutoSize = true;
            this.labelFio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFio.Location = new System.Drawing.Point(7, 27);
            this.labelFio.Name = "labelFio";
            this.labelFio.Size = new System.Drawing.Size(221, 25);
            this.labelFio.TabIndex = 14;
            this.labelFio.Text = "Фамилия для поиска";
            // 
            // textBoxFioFind
            // 
            this.textBoxFioFind.Enabled = false;
            this.textBoxFioFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFioFind.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBoxFioFind.Location = new System.Drawing.Point(239, 21);
            this.textBoxFioFind.Name = "textBoxFioFind";
            this.textBoxFioFind.Size = new System.Drawing.Size(782, 31);
            this.textBoxFioFind.TabIndex = 15;
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(1009, 308);
            this.listBox1.TabIndex = 16;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.ListBox1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отправитьВЦПToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(185, 48);
            // 
            // отправитьВЦПToolStripMenuItem
            // 
            this.отправитьВЦПToolStripMenuItem.Image = global::base_bsmp.Properties.Resources.globe;
            this.отправитьВЦПToolStripMenuItem.Name = "отправитьВЦПToolStripMenuItem";
            this.отправитьВЦПToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.отправитьВЦПToolStripMenuItem.Text = "Отправить по почте";
            this.отправитьВЦПToolStripMenuItem.Click += new System.EventHandler(this.ОтправитьВЦПToolStripMenuItem_Click);
            // 
            // groupBoxPatch
            // 
            this.groupBoxPatch.Controls.Add(this.label1);
            this.groupBoxPatch.Controls.Add(this.radioButton2);
            this.groupBoxPatch.Controls.Add(this.radioButton1);
            this.groupBoxPatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPatch.Location = new System.Drawing.Point(12, 383);
            this.groupBoxPatch.Name = "groupBoxPatch";
            this.groupBoxPatch.Size = new System.Drawing.Size(537, 112);
            this.groupBoxPatch.TabIndex = 20;
            this.groupBoxPatch.TabStop = false;
            this.groupBoxPatch.Text = "Место для поиска";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Для поиска в диктовоне и везде, нужны соответствующие права.";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton2.Location = new System.Drawing.Point(201, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(264, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Искать в диктофонном центре";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButton1.Location = new System.Drawing.Point(6, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(189, 24);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Искать в отделениях";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // buttonSend
            // 
            this.buttonSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSend.Image = global::base_bsmp.Properties.Resources.globe;
            this.buttonSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSend.Location = new System.Drawing.Point(767, 395);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(254, 47);
            this.buttonSend.TabIndex = 22;
            this.buttonSend.Text = "Отправить по почте";
            this.buttonSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonExit.Location = new System.Drawing.Point(767, 448);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonExit.Size = new System.Drawing.Size(254, 47);
            this.buttonExit.TabIndex = 19;
            this.buttonExit.Text = "Закрыть поиск";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            // 
            // buttonFind
            // 
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonFind.Image = ((System.Drawing.Image)(resources.GetObject("buttonFind.Image")));
            this.buttonFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFind.Location = new System.Drawing.Point(565, 448);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(183, 47);
            this.buttonFind.TabIndex = 17;
            this.buttonFind.Text = "Начать поиск";
            this.buttonFind.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.ОткрытьToolStripMenuItem_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOpen.Image = ((System.Drawing.Image)(resources.GetObject("buttonOpen.Image")));
            this.buttonOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOpen.Location = new System.Drawing.Point(565, 395);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(183, 47);
            this.buttonOpen.TabIndex = 23;
            this.buttonOpen.Text = "Открыть";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.Button2_Click);
            // 
            // formFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1033, 507);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.groupBoxPatch);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxFioFind);
            this.Controls.Add(this.labelFio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formFind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск эпикриза ";
            this.Load += new System.EventHandler(this.FormFind_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBoxPatch.ResumeLayout(false);
            this.groupBoxPatch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFio;
        public System.Windows.Forms.TextBox textBoxFioFind;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.GroupBox groupBoxPatch;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem отправитьВЦПToolStripMenuItem;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Button buttonOpen;
    }
}