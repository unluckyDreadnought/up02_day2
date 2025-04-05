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
            Actionless.RestartTimer();
            this.Visible = false;
            ProjectForm form = new ProjectForm();
            Actionless.RestartTimer(form);
            form.ShowDialog();
            this.Visible = true;
            Actionless.RestartTimer(this);
        }

        private void clientbtn_Click(object sender, EventArgs e)
        {
            Actionless.RestartTimer();
            this.Visible = false;
            ClientsForm form = new ClientsForm();
            Actionless.RestartTimer(form);
            form.ShowDialog();
            this.Visible = true;
            Actionless.RestartTimer(this);
        }

        private void leavebtn_Click(object sender, EventArgs e)
        {
            Actionless.RestartTimer();
            this.Close();
        }

        private void action_happened(object sender, EventArgs e)
        {
            Actionless.RestartTimer();
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            Actionless.RestartTimer();
        }
    }
}
