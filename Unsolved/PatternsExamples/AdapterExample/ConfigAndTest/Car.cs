namespace AdapterExample.ConfigAndTest
{
    public class Car
    {
        private string _licensePlate;
        private int _price;

        public Car(string licensePlate, int price)
        {
            _licensePlate = licensePlate;
            _price = price;
        }

        public string LicensePlate
        {
            get { return _licensePlate; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public override string ToString()
        {
            return $"{_licensePlate} costs {_price} EUR";
        }
    }
}