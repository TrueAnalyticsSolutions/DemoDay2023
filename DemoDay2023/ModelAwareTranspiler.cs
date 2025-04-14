using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Transpiler
{
    public static class ModelAwareTranspiler
    {
        public static void ExportTypes(string outputPath)
        {
            StringBuilder textBuilder = new StringBuilder();

            var observationTypes = Mtconnect.MtconnectModel.ObservationInformationModelPackage.ObservationTypesPackage.Packages.SelectMany(o => o.Classes);
            foreach (var observationType in observationTypes)
            {
                textBuilder.AppendLine($"{observationType.Name}");
            }

            File.WriteAllText(outputPath, textBuilder.ToString());
        }
    }
}
