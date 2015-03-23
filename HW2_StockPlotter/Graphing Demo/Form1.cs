using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphing_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GraphForm gForm = new GraphForm();
            gForm.MdiParent = this; 

            GraphControlForm gcForm = new GraphControlForm();
            gcForm.MdiParent = this;

            gForm.graphControlForm = gcForm;
            gcForm.graphForm = gForm;

            gForm.Show();
            gcForm.Show();
        }
    }
}
