using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LAN_MOnitoring_Client
{
    class Shutdown_Restart_LogOff_Lock
    {
        [DllImport("user32")]
        internal static extern void LockWorkStation();
    
        [DllImport("user32")]
        internal static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        internal static void shutdownBtn_Click()
        {
            Process.Start("shutdown","/s /t 60");
        }

        internal static void restartBtn_Click()
        {
            Process.Start("shutdown", "/r /t 60");
        }
        internal static void shotShutdownBtn_Click()
        {
            Process.Start("shutdown", "/a");
        }

        internal static void logOffBtn_Click()
        {
            ExitWindowsEx(0, 0);
        }

        internal static void lockBtn_Click()
        {
            LockWorkStation();
        }
    }
}
