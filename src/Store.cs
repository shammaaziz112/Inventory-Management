using System.Runtime.CompilerServices;

namespace inventory_management.src
{
    public class Store
    {
        private readonly string _name;
        private readonly List<Item> _items;

        public Store(string name)
        {
            _name = name;
            _items = [];
        }

        public List<Item> GetItems()
        {
            return _items;

        }
        public bool AddItem(Item newItem)
        {
            bool findItem = _items.Contains(newItem);

            if (findItem)
            {
                Console.WriteLine($"{newItem.GetName()} item already added");

                return false;
            }

            _items.Add(newItem);
            Console.WriteLine($"Added {newItem.GetName()} item successful");
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
            var findItem = _items.Find(item => item.GetName()==itemName);

                if (findItem is not null)
                {
                    Console.WriteLine($"{itemName} Item founded: Quantity = {findItem.GetQuantity()}, CreatedDate = {findItem.GetCreatedDate()}");
                    return true;
                }
            
            Console.WriteLine($"{itemName} Item not founded");
            return false;
        }

        public List<Item> SortByNameAsc(){
            _items.Sort((item1, item2) => item1.GetName().CompareTo(item2.GetName()));
            return _items;

        }
    }
}