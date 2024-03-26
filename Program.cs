using inventory_management.src;
internal class Program
{
    private static void Main(string[] args)
    {
        Store<Item> store = new("Tamimi", 500);
        Console.WriteLine(store.GetCapacity());


        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
        var coffee = new Item("Coffee", 20, default);
        var sandwich = new Item("Sandwich", 15, default);
        var batteries = new Item("Batteries", 10, default);
        var umbrella = new Item("Umbrella", 5, default);

        Console.WriteLine("=======================================");

        store.AddItem(new Item("Sunscreen", 8, default));
        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(tissuePack);
        store.AddItem(notebook);
        store.AddItem(pen);
        store.AddItem(coffee);
        store.AddItem(coffee);

        Console.WriteLine("=======================================");
        Console.WriteLine("=======================================");

        Console.WriteLine(store.GetCapacity());

        Console.WriteLine("=======================================");

        store.RemoveItems(waterBottle);

        Console.WriteLine("=======================================");

        Console.WriteLine($"The total amount of items in the {store.GetName()} store {store.GetCurrentVolume()}");

        Console.WriteLine("=======================================");

        store.FindItemByName("Coffee");
        store.FindItemByName("Coff");

        Console.WriteLine("=======================================");
        Console.WriteLine("=======================================");

        store.GetItems();

        List<Item> sortedItem = store.SortByNameAsc();

        foreach (var item in sortedItem)
        {
            Console.WriteLine($"Name = {item.GetName()},\nQuantity = {item.GetQuantity()}\nCreated Date = {item.GetCreatedDate()}");
        }
        Console.WriteLine("=======================================");
    }
}