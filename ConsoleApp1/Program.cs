using SciterSharp;
using SciterSharp.Interop;
using System;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            PInvokeWindows.OleInitialize(IntPtr.Zero);
            var window = new SciterWindow();

            window.CreateMainWindow(1500, 800);
            window.CenterTopLevelWindow();
            window.Title = "Test";

            var host = new SciterHost();
            host.SetupWindow(window);
            window.Show();

            PInvokeUtils.RunMsgLoop();
        }
    }
}
