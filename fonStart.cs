using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace base_bsmp
{
    public partial class fonStart : Form
    {
        public fonStart()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
                timer1.Stop();
                Close();
        }
    }
}
