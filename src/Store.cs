namespace inventory_management.src
{
    public class Store
    {
        private readonly string _name;
        private readonly int _capacity;
        private readonly List<Item> _items;

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
            foreach (Item item in _items)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"- Name = {item.GetName()},\n  Quantity = {item.GetQuantity()},\n  Created Date = {item.GetCreatedDate()}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->");
            }

        }
        public string GetCapacity()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return $"Capacity: {GetCurrentVolume()} out of {_capacity} units in inventory.";
        }


        //* Add Item
        public bool AddItem(Item newItem)
        {
            var existingItem = _items.Find(item => item.GetName() == newItem.GetName());

            if (existingItem != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The item '{newItem.GetName()}' is already in the inventory.");
                return false;
            }

            if (GetCurrentVolume() + newItem.GetQuantity() > _capacity)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Unable to add '{newItem.GetName()}' due to insufficient space.");
                return false;
            }

            _items.Add(newItem);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The item '{newItem.GetName()}' has been successfully added to the inventory.");
            return true;
        }

        //* Remove Item
        public bool RemoveItem(Item item)
        {
            if (_items.Remove(item))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The item '{item.GetName()}' has been successfully removed from the inventory.");
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The item '{item.GetName()}' was not found in the inventory.");
            return false;
        }

        //* Get Current Amount of the Items
        public int GetCurrentVolume()
        {
            return _items.Sum(item => item.GetQuantity());
        }

        //* Find Item By Name
        public bool FindItemByName(string itemName)
        {
            var foundItem = _items.Find(item => item.GetName() == itemName);

            if (foundItem != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The item '{itemName}' was found: Quantity = {foundItem.GetQuantity()}, Created Date = {foundItem.GetCreatedDate()}");
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The item '{itemName}' was not found in the inventory.");
            return false;
        }

        //* Sort By Name Asc.
        public List<Item> SortByNameAsc(SortOrder order)
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
        public List<Item> SortByDate(SortOrder order)
        {
            if (order is SortOrder.DESC)
            {
                var descSort = from item in _items
                               orderby item.GetCreatedDate() descending
                               select item;
                return descSort.ToList();
            }
            if (order is SortOrder.ASC)
            {
                var ascSort = from item in _items
                              orderby item.GetCreatedDate()
                              select item;
                return ascSort.ToList();
            }
            return _items;
        }
        public void GroupByDate()
        {
            var groupByMonth = from item in _items
                               let category = (DateTime.Now - item.GetCreatedDate()).TotalDays <= 90 ? "New Arrival" : "Old"
                               group item by category into newGroup
                               orderby newGroup.Key
                               select newGroup;

            foreach (var monthGroup in groupByMonth)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine($"{monthGroup.Key} Items: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->");
                foreach (var item in monthGroup)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($" - {item.GetName()}, Created: {item.GetCreatedDate().ToShortDateString()}");
                }
            }
        }

        //* Display the List
        public void DisplayList(List<Item> list)
        {
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"- Name = {item.GetName()},\n  Quantity = {item.GetQuantity()}\n  Created Date = {item.GetCreatedDate()}");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("->->->->->->->->->->->->->->->->->->->->->->->->->->->->->->");
            }
        }
    }
}