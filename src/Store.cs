using System.Runtime.CompilerServices;

namespace inventory_management.src
{
    public class Store
    {
        private readonly string _name;
        private readonly int _capacity;
        private int _amount;
        private readonly List<Item> _items;

        public Store(string name, int capacity)
        {
            _name = name;
            _capacity = capacity;
            _amount = 0;
            _items = [];
        }

        public List<Item> GetItems()
        {
            return _items;
        }
        public string GetCapacity()
        {
            return $"Capacity: {_amount}/{_capacity} inventory";
        }
        public bool AddItem(Item newItem)
        {
            bool findItem = _items.Contains(newItem);
            // int capacity = ;

            if (findItem)
            {
                Console.WriteLine($"{newItem.GetName()} item already added");

                return false;
            }

            if (_amount + newItem.GetQuantity() > _capacity)
            {
                Console.WriteLine($"There no space to add {newItem.GetName()} item");
                return false;
            }

            _items.Add(newItem);
            Console.WriteLine($"Added {newItem.GetName()} item successful");
            _amount = _amount + newItem.GetQuantity();
            return true;
        }
        public bool RemoveItems(Item item)
        {
            _items.Remove(item);
            Console.WriteLine($"Removed {item.GetName()} item successful");
            return true;
        }
        public string GetCurrentVolume()
        {

            return $"The total amount of items in the {_name} store {_items.Count}";
        }

        public bool FindItemByName(string itemName)
        {
            var findItem = _items.Find(item => item.GetName() == itemName);

            if (findItem is not null)
            {
                Console.WriteLine($"{itemName} Item founded: Quantity = {findItem.GetQuantity()}, CreatedDate = {findItem.GetCreatedDate()}");
                return true;
            }

            Console.WriteLine($"{itemName} Item not founded");
            return false;
        }

        public List<Item> SortByNameAsc()
        {
            _items.Sort((item1, item2) => item1.GetName().CompareTo(item2.GetName()));
            return _items;

        }
    }
}