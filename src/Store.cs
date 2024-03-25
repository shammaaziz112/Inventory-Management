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
            return true;
        }
    }
}