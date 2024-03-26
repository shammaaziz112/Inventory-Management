
namespace inventory_management.src
{
    public class Item : Base, IBase
    {
        private readonly string _name;
        private readonly int _quantity;

        public Item(string name, int quantity, DateTime createdDate) : base(createdDate)
        {
            if (quantity < 0) throw new ArgumentException("Quantity cannot be negative.");
            _name = name;
            _quantity = quantity;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetQuantity()
        {
            return _quantity;
        }
    }
}