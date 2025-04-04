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
        DataTable source = new DataTable();

        public ProjectForm()
        {
            InitializeComponent();
        }

        private void UpdateSource()
        {
            source = Db.GetProjects(searchLine.Text);
            if (source == null)
            {
                MessageBox.Show("Ошибка получения данных");
                source = new DataTable();
            }
        }

        private void UpdatePages(int pagesCount, int curPage, string range = null)
        {
            panel1.Controls.Clear();

            int n = pagesCount - 1;
            int space = -1;
            do
            {
                Label page = new Label();
                page.AutoSize = true;
                page.Text = (n >= 0) ? $"{n + 1}" : $"{n + 2}";
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

        private void UpdateTable(int offset = 1, string range = null)
        {
            DataTable dt = source.Clone();

            int indx = 0;
            while (indx < 20)
            {
                if (indx + (offset - 1) * 20 >= source.Rows.Count) break;
                DataRow row = dt.NewRow();
                row.ItemArray = source.Rows[indx + (offset - 1) * 20].ItemArray;
                dt.Rows.Add(row);
                indx++;
            }

            projTable.DataSource = dt;
            int total = source.Rows.Count;
            int currentCount = (20 * (offset - 1)) + dt.Rows.Count;
            int pagesCount = Convert.ToInt32(Math.Ceiling((double)total / 20));
            linesCount.Text = $"Количество записей: {currentCount} из {total}";
            if (range == null) UpdatePages(pagesCount, offset);
            else UpdatePages(pagesCount, offset, range);
        }

        //private void UpdateTable(int offset = 1)
        //{
        //    (DataTable dt, int total) = Db.GetProjects(searchLine.Text, offset);
        //    if (dt == null)
        //    {
        //        MessageBox.Show("Ошибка получения данных");
        //        dt = new DataTable();
        //    }
        //    projTable.DataSource = dt;
        //    int currentCount = (20 * (offset - 1)) + dt.Rows.Count;
        //    int pagesCount = Convert.ToInt32(Math.Ceiling((double)total / 20));
        //    linesCount.Text = $"Количество записей: {currentCount} из {total}";
        //    UpdatePages(pagesCount, offset);
        //}


        private void searchLine_TextChanged(object sender, EventArgs e)
        {
            UpdateSource();
            UpdateTable();
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            UpdateSource();
            UpdateTable();
        }

        private void page_Clicked(object sender, EventArgs e)
        {
            int page = 1;
            int cntrIndx = panel1.Controls.IndexOf((Label)sender);
            if (!int.TryParse(((Label)sender).Text, out page))
            {
                int previuos = Convert.ToInt32(panel1.Controls[cntrIndx + 1].Text);
                int next = Convert.ToInt32(panel1.Controls[cntrIndx - 1].Text);
                string range = $"{previuos+1}-{next-1}";
                page = previuos + 1;
                UpdateTable(page, range);
                return;
            }
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
