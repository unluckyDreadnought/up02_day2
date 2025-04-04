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
    public partial class ViewClient : Form
    {
        string[] clientInfo = null;

        public ViewClient(string clientId)
        {
            InitializeComponent();
            clientInfo = Db.GetClient(clientId);
        }

        private void ViewClient_Load(object sender, EventArgs e)
        {
            if (clientInfo == null)
            {
                MessageBox.Show("Не удалось загрузить информацию о клиенте");
                return;
            }
            nameLbl.Text = clientInfo[1];
            phoneLbl.Text = $"Контактный телефон: {clientInfo[2]}";
            mailLbl.Text = clientInfo[3];
            addrLbl.Text = clientInfo[4];
        }
    }
}
