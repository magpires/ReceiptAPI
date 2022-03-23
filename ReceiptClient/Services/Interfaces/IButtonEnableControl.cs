using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReceiptClient.Services.Interfaces
{
    public interface IButtonEnableControl
    {
        bool CheckTexBoxtFilled(Control.ControlCollection controls);
    }
}
