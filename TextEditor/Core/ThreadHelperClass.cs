using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Core
{
    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        delegate void SetEnabledCallback(Form f, Control ctrl, bool enabled);
        delegate void SetFocusCallback(Form f, Control ctrl);

        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }

        public static void SetEnabled(Form form, Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                var d = new SetEnabledCallback(SetEnabled);
                form.Invoke(d, new object[] { form, control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }

        public static void Focus(Form form, Control control)
        {
            if (control.InvokeRequired)
            {
                var d = new SetFocusCallback(Focus);
                form.Invoke(d, new object[] { form, control});
            }
            else
            {
                control.Focus();
            }
        }
    }
}
