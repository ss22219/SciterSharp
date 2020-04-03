using SciterAppResource;
using SciterSharp;
using SciterSharp.Interop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class App
    {
        public static void Run()
        {
            PInvokeWindows.OleInitialize(IntPtr.Zero);
            var window = new SciterWindow();
            window.CreateMainWindow(500, 500);
            window.CenterTopLevelWindow();
            var host = new AppHost(window);
            window.LoadPage("archive://app/acrylic-window/acrylic-window-sketch.htm");
            window.Show();
            PInvokeUtils.RunMsgLoop();
        }
    }

    public class AppHost : SciterHost
    {
        static SciterX.ISciterAPI _api = SciterX.API;
        SciterArchive _archive = new SciterArchive();
        SciterWindow _window;

        public AppHost(SciterWindow window)
        {
            _archive.Open(ArchiveResource.resources);
            _window = window;
            SetupWindow(_window);
            window.Show();
#if DEBUG
            DebugInspect();
#endif
        }

        protected override SciterXDef.LoadResult OnLoadData(SciterXDef.SCN_LOAD_DATA sld)
        {
            if (sld.uri.StartsWith("archive://app/"))
            {
                // load resource from SciterArchive
                string path = sld.uri.Substring(14);
                byte[] data = _archive.Get(path);
                if (data != null)
                    _api.SciterDataReady(_window._hwnd, sld.uri, data, (uint)data.Length);
            }
            return base.OnLoadData(sld);
        }
    }
}
