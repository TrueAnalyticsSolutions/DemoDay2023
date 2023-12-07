using MtconnectTranspiler.Contracts;
using MtconnectTranspiler.Sinks;
using MtconnectTranspiler.Xmi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transpiler
{
    internal class MyTranspiler : ITranspilerSink
    {
        private string _outputPath;

        public MyTranspiler(string outputPath)
        {
            _outputPath = outputPath;
        }

        public void Transpile(XmiDocument model, CancellationToken cancellationToken = default)
        {
            StringBuilder textBuilder = new StringBuilder();

            // Find Observation Types
            string[] categories = new string[] { "Sample", "Event", "Condition" };

            foreach (string category in categories)
            {
                var typesPackage = MTConnectHelper
                    .JumpToPackage(model!, MTConnectHelper.PackageNavigationTree.ObservationInformationModel.ObservationTypes)?
                    .Packages
                    .FirstOrDefault(o => o.Name == $"{category} Types")
                    ?? throw new NullReferenceException();

                foreach (var type in typesPackage.Classes)
                {
                    textBuilder.AppendLine($"{category}, {type.Name}");
                }
            }

            File.WriteAllText(_outputPath, textBuilder.ToString());
        }
    }
}
