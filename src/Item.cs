
namespace inventory_management.src
{
    public class Item
    {
        private readonly string _name;
        private readonly int _quantity;
        private readonly DateTime _createdDate;

        public Item(string name, int quantity)
        {
            _name = name;
            if (quantity >= 0) { _quantity = quantity; }
            else { _quantity = 0; }
            _createdDate = DateTime.Now;
        }
        public Item(string name, int quantity, DateTime createdDate)
        {
            _name = name;
            if (quantity >= 0) { _quantity = quantity; }
            else { _quantity = 0; }
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