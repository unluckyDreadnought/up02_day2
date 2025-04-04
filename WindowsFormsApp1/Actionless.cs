using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Actionless
    {
        Timer _timer = null;
        Form _activeForm = null;
        
        public void RestartTimer()
        {
            _timer.Stop();
            _timer.Start();
        }

        public Actionless()
        {
            _timer = new Timer();
            _timer.Enabled = true;
            _timer.Interval = 30000;
            _timer.Start();
            
        }

        private void StartObserve()
        {
            _activeForm = GetActiveForm();
        }

        private Form GetActiveForm()
        {
            Form[] forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form f in  forms)
            {
                if (f.Focused)
                {
                    return f;
                }
            }
            return null;
        }

        public void ChangeForm()
        {
            
        }

        private void action_happend(object sender, EventArgs e)
        {
            RestartTimer();
        }
    }
}
