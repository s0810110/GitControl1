using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneDiarySystem
{
    public partial class Main : Form
    {
        //private int childFormNumber = 0;

        public Main()
        {
            InitializeComponent();
        }


        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void vIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fORM1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Phone ph = new Phone();
            //ph.MdiParent = this;
            ph.Show();
        }

        private void session1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            //To display form2 in the MDI;
            //here Panel2 is used to Display created form in the MDI
            splitContainer1.Panel2.Controls.Add(f2);
            f2.Dock = DockStyle.Fill;
            f2.Show();
        }
    }
}
