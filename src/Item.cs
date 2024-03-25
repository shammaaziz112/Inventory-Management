
namespace inventory_management.src
{
    public class Item
    {
        private readonly string _name;
        private readonly int _quantity;
        private readonly DateTime _createdDate;

        public Item(string name, int quantity)
        {
            if (quantity < 0)throw new ArgumentException("Quantity cannot be negative.");
            _name = name;
            _quantity = quantity;
            _createdDate = DateTime.Now;
        }
        public Item(string name, int quantity, DateTime createdDate)
        {
            if (quantity <= 0)throw new ArgumentException("Quantity cannot be negative.");
            _name = name;
            _quantity = quantity;
            _createdDate = createdDate;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
        public DateTime GetCreatedDate()
        {
            return _createdDate;
        }
    }
}