using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadTablesCombo()
        {
            string[] tblNames = Db.GetTableNames();
            if (tblNames == null) return;
            tables.Items.AddRange(tblNames);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTablesCombo();
        }

        private void import_Click(object sender, EventArgs e)
        {
            if (tables.SelectedIndex == -1) return;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void repair_Click(object sender, EventArgs e)
        {

        }
    }
}
