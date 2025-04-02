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
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 settings = new Form1();
            settings.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = Db.IsUserExists(login.Text, pass.Text);
            if (data == null) {
                MessageBox.Show("Ошибка", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (data.Length > 0)
            {
                MessageBox.Show($"Успешная авторизация. Ваш ID: {0}", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Такой пользователь не обнаружен", "Неверные учётные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
