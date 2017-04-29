namespace WeatherStationV10
{
    public class Barometer
    {
        private double _pressureInMmHg;

        public double Pressure
        {
            get { return _pressureInMmHg; }
            set { _pressureInMmHg = value; }
        }

        public string WeatherDescription
        {
            get { return "All weather is nice!"; }
        }
    }
}