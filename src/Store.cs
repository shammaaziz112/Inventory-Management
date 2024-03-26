using System.Runtime.CompilerServices;

namespace inventory_management.src
{
    public class Store<T> where T : Base, IBase
    {
        private readonly string _name;
        private readonly int _capacity;
        private readonly List<T> _items;

        public Store(string name, int capacity)
        {
            _name = name;
            _capacity = capacity;
            _items = [];
        }

        //* Get Method
        public string GetName()
        {
            return _name;
        }
        public void GetItems()
        {
            foreach (T item in _items)
            {
                Console.WriteLine($"Name = {item.GetName()},\nQuantity = {item.GetQuantity()},\nCreated Date = {item.GetCreatedDate()}");
                Console.WriteLine("---------------------------------------");
            }

        }
        public string GetCapacity()
        {
            return $"Capacity: {GetCurrentVolume()}/{_capacity} inventory";
        }

        //* Add Item
        public bool AddItem(T newItem)
        {
            var findItem = _items.Find(item => item.GetName() == newItem.GetName());

            if (findItem is not null)
            {
                Console.WriteLine($"{newItem.GetName()} item already added");
                return false;
            }

            if (GetCurrentVolume() + newItem.GetQuantity() >= _capacity)
            {
                Console.WriteLine($"There no space to add {newItem.GetName()} item");
                return false;
            }

            _items.Add(newItem);
            Console.WriteLine($"Added {newItem.GetName()} item successful");
            return true;
        }

        //* Remove Item
        public bool RemoveItems(T item)
        {
            _items.Remove(item);
            Console.WriteLine($"Removed {item.GetName()} item successful");
            return true;
        }

        //* Get Current Amount of the Items
        public int GetCurrentVolume()
        {
            return _items.Sum(item => item.GetQuantity());
        }

        //* Find Item By Name
        public bool FindItemByName(string itemName)
        {
            var findItem = _items.Find(item => item.GetName() == itemName);

            if (findItem is not null)
            {
                Console.WriteLine($"{itemName} Item founded: Quantity = {findItem.GetQuantity()}, Created Date = {findItem.GetCreatedDate()}");
                return true;
            }

            Console.WriteLine($"{itemName} Item not founded");
            return false;
        }

        //* Sort By Name Asc.
        public List<T> SortByNameAsc(SortOrder order)
        {
            if (order == SortOrder.ASC)
            {
                return _items.OrderBy(item => item.GetName()).ToList();
            }
            if (order == SortOrder.DESC)
            {
                return _items.OrderByDescending(item => item.GetName()).ToList();
            }
            return _items;
        }

        //*Sort By Date
        public List<T> SortByDate(SortOrder order)
        {
            if (order is SortOrder.DESC)
        {
            var descSort = from item in _items
                           orderby item.GetCreatedDate() descending
                           select item;
            return descSort.ToList();
        }
        else
        {
            var ascSort = from item in _items
                          orderby item.GetCreatedDate()
                          select item;
            return ascSort.ToList();
        }

        }

        //* Display the List
        public void DisplayList(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"Name = {item.GetName()},\nQuantity = {item.GetQuantity()}\nCreated Date = {item.GetCreatedDate()}");
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}