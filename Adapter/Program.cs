using ConsoulLibrary;
using Mtconnect;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Goals:
             *      - Create "Device Model"
             *      - Create Adapter Source
             *          - Randomly change observations
             *      - Start Adapter
             */

            var tcpOptions = new TcpAdapterOptions(port: 7878);

            using(var adapter = new TcpAdapter(tcpOptions))
            {
                // Start the adapter, providing our IAdapterSource
                adapter.Start(new Source());

                Consoul.Write($"Adapter running @ http://*:{adapter.Port}");

                if (File.Exists(PUTTY_EXE) && Consoul.Ask("Would you like to run PuTTY?"))
                    StartPuTTY(adapter.Port);

                // Wait for user input
                Consoul.Wait();

                adapter.Stop();
            }
        }








        private const string PUTTY_EXE = @"C:\Program Files\PuTTY\putty.exe";
        private const string CMD_EXE = @"C:\windows\system32\cmd.exe";
        private static void StartPuTTY(int port)
        {
            using (var cmd = new System.Diagnostics.Process())
            {
                cmd.StartInfo.FileName = CMD_EXE;
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;

                cmd.Start();

                cmd.StandardInput.WriteLine($"\"{PUTTY_EXE}\" -raw -P {port} localhost");
            }
        }
    }
}
