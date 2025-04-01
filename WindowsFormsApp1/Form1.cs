using System;
using System.IO;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

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
            string[][] tblDesc = Db.GetTableDescription(tables.SelectedItem.ToString());
            ;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void repair_Click(object sender, EventArgs e)
        {
            string res = Db.RepairDb();
            if (res == null) {
                MessageBox.Show("Не удалось подключиться к БД", "Ошибка подкючения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (res.Length == 0)
            {
                LoadTablesCombo();
            }
            else
            {
                MessageBox.Show(res, "Ошибка выполнения запроса", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
