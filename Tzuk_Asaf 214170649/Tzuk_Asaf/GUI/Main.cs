using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tzuk_Asaf.GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_students f = new frm_students(this);
            this.Hide();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_driving_teacher f = new frm_driving_teacher(this);
            this.Hide();
            f.Show();
        }
    }
}
