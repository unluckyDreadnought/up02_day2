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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void projbtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ProjectForm form = new ProjectForm();
            form.ShowDialog();
            this.Visible = true;
        }

        private void clientbtn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClientForm form = new ClientForm();
            form.ShowDialog();
            this.Visible = true;
        }

        private void leavebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
