
using MtconnectTranspiler;
using Transpiler;

namespace DemoDay2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Goals:
             *      - Add MtconnectTranspiler NuGet package
             *      - Implement ITranspilerSink
             *          - Navigate to and iterate thru observation types
             *          - Write text file with list of observation types
             */

            const string SysML_FilePath = $@"{Constants.FOLDER}\MTConnect SysML Model.xml";
            const string GeneratedFilePath = $@"{Constants.FOLDER}\output.txt";

            var dispatchOptions = new FromFileOptions() {  Filepath = SysML_FilePath };
            using (var dispatcher = new TranspilerDispatcher(dispatchOptions))
            {
                dispatcher.AddSink(new MyTranspiler(GeneratedFilePath));

                dispatcher.TranspileAsync().Wait();

                Console.WriteLine("Done!");
                Console.ReadLine();
            }
        }
    }
}
