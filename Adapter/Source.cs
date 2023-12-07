using Mtconnect.AdapterSdk;
using Mtconnect.AdapterSdk.DataItemValues;

namespace Adapter
{
    public class Source : IAdapterSource
    {
        #region IAdapterSource Implementations
        public string DeviceUuid => throw new NotImplementedException();

        public string DeviceName => throw new NotImplementedException();

        public string StationId => throw new NotImplementedException();

        public string SerialNumber => throw new NotImplementedException();

        public string Manufacturer => throw new NotImplementedException();

        public event DataReceivedHandler OnDataReceived;
        public event AdapterSourceStartedHandler OnAdapterSourceStarted;
        public event AdapterSourceStoppedHandler OnAdapterSourceStopped;

        public void Start(CancellationToken token = default)
        {
            TIMER.Elapsed += TIMER_Elapsed;
            TIMER.Interval = 500;
            TIMER.Start();
        }
        public void Stop(Exception ex = null)
        {
            TIMER.Stop();
        }
        #endregion

        private System.Timers.Timer TIMER = new System.Timers.Timer();

        public DemoModel Model { get; set; } = new DemoModel();

        private void TIMER_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Model.Availability = RandomDataHelper.GetRandomString(AvailabilityValues.AVAILABLE.ToString(), AvailabilityValues.UNAVAILABLE.ToString());

            Model.Random_X = RandomDataHelper.GetRandomFloat();
            Model.Random_Y = RandomDataHelper.GetRandomFloat();

            OnDataReceived?.Invoke(this, new DataReceivedEventArgs(Model));
        }

    }
}
