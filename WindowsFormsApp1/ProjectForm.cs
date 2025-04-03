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

            //if (pagesCount > 5)
            //{
            //    Label page = new Label();
            //    page.AutoSize = true;
            //    page.Text = "...";
            //    page.Dock = DockStyle.Left;
            //    page.Click += page_Clicked;
            //    if (page.Text == curPage.ToString())
            //    {
            //        page.BackColor = Color.CadetBlue;
            //        page.ForeColor = Color.White;
            //    }
            //    panel1.Controls.Add(page);
            //    pagesCount = 5;
            //}

            int n = pagesCount - 1;
            do
            {
                Label page = new Label();
                page.AutoSize = true;
                page.Text = (n  >= 0) ? $"{n + 1}" : $"{n+2}";
                page.Dock = DockStyle.Left;
                page.Click += page_Clicked;
                if (page.Text == curPage.ToString())
                {
                    page.BackColor = Color.CadetBlue;
                    page.ForeColor = Color.White;
                }
                panel1.Controls.Add(page);
                n--;
            }
            while (n >= 0);
        }

        private void UpdateTable(int offset = 1) {
            (DataTable dt, int total) = Db.GetProjects(searchLine.Text, offset);
            if (dt == null)
            {
                MessageBox.Show("Ошибка получения данных");
                dt = new DataTable();
            }
            projTable.DataSource = dt;
            int currentCount = (20 * (offset-1)) + dt.Rows.Count;
            int pagesCount = Convert.ToInt32(Math.Ceiling((double)total / 20));
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

        private void page_Clicked(object sender, EventArgs e)
        {
            int page = 1;
            int.TryParse(((Label)sender).Text, out page);
            UpdateTable(page);
        }

        private void arrow_KeyDown(object sender, KeyEventArgs e)
        {
            int pageCount = panel1.Controls.Count;
            int lbIndx = 0;

            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {

                while (lbIndx < panel1.Controls.Count)
                {
                    if (panel1.Controls[lbIndx].ForeColor == Color.White) break;
                    lbIndx++;
                }
            }

            if (e.KeyCode == Keys.Right)
            {
                if (lbIndx - 1 >= 0) 
                {
                    lbIndx--;
                    UpdateTable(Convert.ToInt32(panel1.Controls[lbIndx].Text));
                    return;
                }
                else return;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (lbIndx + 1 < pageCount)
                {
                    lbIndx++;
                    UpdateTable(Convert.ToInt32(panel1.Controls[lbIndx].Text));
                    return;
                }
                else return;
            }
            else e.Handled = true;
        }

    }
}
