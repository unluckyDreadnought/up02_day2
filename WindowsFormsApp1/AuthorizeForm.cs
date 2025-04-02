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

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 settings = new Form1();
            settings.ShowDialog();
        }

        private void BlockInput()
        {
            timer1.Start();
            statusStrip1.Visible = true;
            if (!panel2.Visible)
            {
                ChangeVisbilityOfCapcha();
            }
            else UpdateCaptcha();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible)
            {
                if (captcha.Text != captchaTxt)
                {
                    MessageBox.Show("Введённое значение Captcha не соответствует заданному", "");
                    return;
                }
            }
            string[] data = Db.IsUserExists(login.Text, pass.Text);
            if (data == null) {
                MessageBox.Show("Ошибка", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BlockInput();
                return;
            }
            else if (data.Length > 0)
            {
                MessageBox.Show($"Успешная авторизация. Ваш ID: {0}", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (panel2.Visible) ChangeVisbilityOfCapcha();
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
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateCaptcha();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (seconds > 0)
            {
                seconds -= 1;
                progress.Value = progress.Maximum * (1 - 1 * 10 / seconds);
                
                remainSeconds.Text = $"Осталось {seconds} с.";
            }
            else if (seconds == 0)
            {
                timer1.Stop();
                seconds = 10;
                statusStrip1.Visible = false;
            }
            
        }
    }
}
