using System.IO;
using System.Windows.Forms;

namespace Lotus.AutoUpdate
{
    public class Log
    {
        private static readonly string fileName = Application.StartupPath + "\\upgrade.txt";

        public static void Write(string s)
        {
            using (var w = File.AppendText(fileName))
            {
                w.WriteLine(s);
            }
        }

        public static void Clear()
        {
            File.WriteAllText(fileName, string.Empty);
        }
    }
}