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
    public partial class ClientsForm : Form
    {
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void UpdateClients()
        {
            clientsTable.Rows.Clear();
            DataTable dt = Db.GetClients();
            if (dt == null)
            {
                MessageBox.Show("Не удалось загрузить клиентов");
                return;
            }
            string[][] clients = Db.DataTableToMultyRowStrArray(dt);
            int lineIndx = 0;
            while (lineIndx < clients.Length)
            {
                string phone = Security.HidePhoneData(clients[lineIndx][2]);
                string name = clients[lineIndx][1];
                if (!name.Contains("'"))
                {
                    name = Security.GetSnp(name);
                }
                clientsTable.Rows.Add();
                clientsTable.Rows[lineIndx].Cells["idCol"].Value = clients[lineIndx][0];
                clientsTable.Rows[lineIndx].Cells["clientNameCol"].Value = name;
                clientsTable.Rows[lineIndx].Cells["phoneCol"].Value = phone;
                clientsTable.Rows[lineIndx].Cells["emailCol"].Value = clients[lineIndx][3];
                lineIndx++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clientsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            string clientId = clientsTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            ViewClient clientInfo = new ViewClient(clientId);
            clientInfo.ShowDialog();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            UpdateClients();
        }
    }
}
