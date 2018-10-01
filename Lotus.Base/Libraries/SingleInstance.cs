using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Lotus.Libraries
{
    public static class SingleInstance
    {
        public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}",
            AssemblyGuid);

        private static Mutex mutex;

        public static string AssemblyGuid
        {
            get
            {
                var attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof (GuidAttribute), false);
                if (attributes.Length == 0)
                {
                    return string.Empty;
                }
                return ((GuidAttribute) attributes[0]).Value;
            }
        }

        public static bool Start()
        {
            var onlyInstance = false;
            var mutexName = string.Format("Local\\{0}", AssemblyGuid);

            // if you want your app to be limited to a single instance
            // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
            // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }

        public static void ShowFirstInstance()
        {
            WinApi.PostMessage(
                (IntPtr) WinApi.HWND_BROADCAST,
                WM_SHOWFIRSTINSTANCE,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        public static void Stop()
        {
            try
            {
                mutex.ReleaseMutex();
            }
            catch
            {
            }
        }
    }

    public static class WinApi
    {
        public const int HWND_BROADCAST = 0xffff;
        public const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        public static int RegisterWindowMessage(string format, params object[] args)
        {
            var message = string.Format(format, args);
            return RegisterWindowMessage(message);
        }

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void ShowToFront(IntPtr window)
        {
            ShowWindow(window, SW_SHOWNORMAL);
            SetForegroundWindow(window);
        }
    }
}