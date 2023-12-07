using Mtconnect.AdapterSdk;
using Mtconnect.AdapterSdk.Attributes;
using Mtconnect.AdapterSdk.DataItemValues;

namespace Adapter
{
    public class DemoModel : IAdapterDataModel
    {
        [Event("a", "The availability of the 'device'")]
        public Availability Availability { get; set; }

        [Sample("x", "Some random x value")]
        public float? Random_X {  get; set; }

        [Sample("y", "Some random y value")]
        public float? Random_Y { get; set; }
    }
}
