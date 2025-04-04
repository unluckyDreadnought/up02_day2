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
        string captchaTxt = null;
        int seconds = 10;

        private void UpdateCaptcha()
        {
            captchaTxt = Security.GenerateCaptchaString(4);
            pictureBox1.Image = Security.GenerateCaptchaImage(captchaTxt);
        }

        public AuthorizeForm()
        {
            InitializeComponent();
            ChangeVisbilityOfCapcha();
        }

        private void ChangeVisbilityOfCapcha()
        {
            if (panel2.Visible)
            {
                captchaTxt = null;
                HideCaptcha();
            }
            else
            {
                UpdateCaptcha();
                ShowCaptcha();
            }
        }

        private void HideCaptcha()
        {
            panel2.Hide();
            panel2.AutoSize = false;
            panel2.Width = 0;
        }

        private void ShowCaptcha()
        {
            panel2.Show();
            panel2.AutoSize = true;
        }

        private void EnterBtnEnabledChange()
        {
            bool enabled = true;
            if (panel2.Visible)
            {
                enabled = captcha.Text.Length > 0;
            }

            enterBtn.Enabled = enabled;
        }

        private void BlockInput()
        {
            if (!panel2.Visible)
            {
                ChangeVisbilityOfCapcha();
                ClearFields();
            }
            else
            {
                ClearFields();
                MessageBox.Show("Система блокируется на 10 секунд");
                progress.Value = 0;
                timer1.Start();
                statusStrip1.Visible = true;
            }
        }

        private void ClearFields()
        {
            login.Text = "";
            pass.Text = "";
            captcha.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                if (captcha.Text != captchaTxt)
                {
                    MessageBox.Show("Введённое значение Captcha не соответствует заданному", "");
                    BlockInput();
                    return;
                }
            }
            
            if (login.Text == Configs.localLogin && pass.Text == Configs.localPswd)
            {
                this.Visible = false;
                Form1 settings = new Form1();
                settings.ShowDialog();
                this.Visible = true;
                ClearFields();
                return;
            }

            string[] data = Db.IsUserExists(login.Text, pass.Text);
            if (data == null) {
                MessageBox.Show("Ошибка", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //BlockInput();
                return;
            }
            else if (data.Length > 0)
            {
                MessageBox.Show($"Успешная авторизация. Ваш ID: {0}", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Visible = false;
                Menu form = new Menu();
                form.ShowDialog();
                this.Visible = true;
                if (panel2.Visible) ChangeVisbilityOfCapcha();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Такой пользователь не обнаружен", "Неверные учётные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BlockInput();
                return;
            }
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            ChangeVisbilityOfCapcha();
            statusStrip1.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateCaptcha();
        }

        private void ChangeEnableOfControls(bool en)
        {
            if (Controls[0].Enabled != en)
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = en;
                }
            }
            else return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChangeEnableOfControls(false);
            if (seconds > 0)
            {
                seconds -= 1;
                int curr = Convert.ToInt32(progress.Maximum*(1-((double)seconds/(double)10)));
                progress.Value = curr;
                remainSeconds.Text = $"Осталось {seconds} с.";
            }
            else if (seconds == 0)
            {
                timer1.Stop();
                seconds = 10;
                statusStrip1.Visible = false;
                UpdateCaptcha();
                ChangeEnableOfControls(true);
            }
            
        }
    }
}
