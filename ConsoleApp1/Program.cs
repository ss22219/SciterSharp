using SciterSharp;
using SciterSharp.Interop;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                App.Run();
            }
            catch (Exception ex)
            {
                File.WriteAllText("Error.txt", ex.ToString());
            }
        }
    }
}
