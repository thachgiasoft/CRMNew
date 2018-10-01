using System;

namespace Lotus.AutoUpdate
{
    internal static class Program
    {
        public static string XmlLocation = string.Empty; //"http://www.insieutoc.com/downloads/inhoadon/info.xml";

        [STAThread]
        private static void Main(string[] args)
        {
            Log.Clear();

            // debug
            //args = new string[] { "CRM.Care", "1.0.0.0", @"http://localhost/VSDReport193Update/info.xml" };

            if (args.Length == 3)
                XmlLocation = args[2];
            else
            {
                Log.Write("args không chính xác");
                return;
            }

            Repository.Initalize(args);

            //string[] xxx = { "Lotus.InHoaDon", "1.0.0.0" };
            //Repository.Initalize(xxx);
        }
    }
}