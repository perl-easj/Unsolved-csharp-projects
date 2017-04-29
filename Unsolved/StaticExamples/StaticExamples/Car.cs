namespace StaticExamples
{
    public class Car
    {
        private string _licensePlate;
        private int _price;

        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Car(string licensePlate, int price)
        {
            _licensePlate = licensePlate;
            _price = price;
        }
    }
}