using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp1
{

    public static class Actionless
    {
        private static Timer _timer;
        public static Form LastForm;

        public static void StartTimer(Form form)
        {
            if (form != null)
            {
                LastForm = form;
            }
            _timer = new Timer();
            _timer.Enabled = true;
            _timer.Interval = Configs.timeout*1000;
            _timer.Tick += timer_Ticked;
            _timer.Start();
        }

        public static void SetTimerTime(int seconts)
        {
            Configs.timeout = seconts;
            _timer.Stop();
            _timer.Interval = Configs.timeout * 1000;
            _timer.Start();
        }

        //public void AddHandler(EventHandler h)
        //{
        //    handlers.Add(h);
        //    RestartTimer();
        //    h.DynamicInvoke();
        //}
        
        public static void RestartTimer(Form form = null)
        {
            if (form != null)
            {
                LastForm = form;
            }
            _timer.Stop();
            _timer.Start();
        }

        private static void timer_Ticked(object sender, EventArgs e)
        {
            if (LastForm is AuthorizeForm == false) Security.LogOut();
        }
    }
}