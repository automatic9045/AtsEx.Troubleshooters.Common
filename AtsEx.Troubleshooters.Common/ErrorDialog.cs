using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AtsEx.PluginHost;

namespace AtsEx.Troubleshooters.Common
{
    internal static class ErrorDialog
    {
        public static void Show(string reason, string approach)
        {
            MessageBox.Show($"{reason}\n\n対処方法:\n{approach}", $"{App.Instance.ProductShortName} コモン トラブルシューティング", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
