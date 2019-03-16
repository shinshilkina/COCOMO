using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace COCOMO
{
    public partial class HELP : Form
    {
        public HELP()
        {
            InitializeComponent();
        }

        private void HELP_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("S:\\18201\\Ковалева\\COCOMO\\COCOMO\\bin\\Debug\\справка.pdf");
        }
    }
}
