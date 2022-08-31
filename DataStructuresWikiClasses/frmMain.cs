using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataStructuresWikiClasses
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        bool linear = false;

        List<DataStructures> dataStructures = new List<DataStructures>();

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbLinear.Checked)
            {
                linear = true;
            }
            else
            {
                linear = false;
            }
            dataStructures.Add(new DataStructures(tbxName.Text, cbCategory.Text, linear, tbxDefinition.Text));
        }
    }
}
