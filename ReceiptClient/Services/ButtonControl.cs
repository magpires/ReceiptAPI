using ReceiptClient.Services.Interfaces;
using System;
using System.Windows.Forms;

namespace ReceiptClient.Services
{
    public class ButtonEnableControl : IButtonEnableControl
    {
        public bool CheckTexBoxtFilled(Control.ControlCollection controls)
        {
            foreach (Control c in controls)
            {
                if (c is TextBox && c.Visible)
                {
                    if (String.IsNullOrEmpty(((TextBox)c).Text))
                        return false;
                }

                if (c.HasChildren)
                    return CheckTexBoxtFilled(c.Controls);
            }

            return true;
        }
    }
}
