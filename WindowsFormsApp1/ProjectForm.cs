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
    public partial class ProjectForm : Form
    {
        public ProjectForm()
        {
            InitializeComponent();
        }

        private void UpdatePages(int pagesCount, int curPage)
        {
            panel1.Controls.Clear();
            for (int n = pagesCount-1; n >= 0; n--)
            {
                Label page = new Label();
                page.AutoSize = true;
                page.Text = $"{n + 1}";
                page.Dock = DockStyle.Left;
                if (page.Text == curPage.ToString())
                {
                    page.BackColor = Color.CadetBlue;
                    page.ForeColor = Color.White;
                }
                panel1.Controls.Add(page);
            }
        }

        private void UpdateTable(int offset = 1) {
            (DataTable dt, int total) = Db.GetProjects(searchLine.Text, offset);
            if (dt == null)
            {
                MessageBox.Show("Ошибка получения данных");
                dt = new DataTable();
            }
            projTable.DataSource = dt;
            int currentCount = dt.Rows.Count;
            int pagesCount = total / 20;
            linesCount.Text = $"Количество записей: {currentCount} из {total}";
            UpdatePages(pagesCount, offset);
        }


        private void searchLine_TextChanged(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            UpdateTable();
        }



    }
}
