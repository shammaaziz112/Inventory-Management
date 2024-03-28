using inventory_management.src;
internal class Program
{
    // ** PrintDivider **
    static void PrintDivider()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(">< >< >< >< >< >< >< >< >< >< >< >< >< >< >< >< >< >< >< ><");
    }
    private static void Main(string[] args)
    {
        Store store = new("Tamimi", 500);

        
        var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
        var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
        var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
        var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
        var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
        var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
        var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
        var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
        var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
        var toothbrush = new Item("Toothbrush", 50, new DateTime(2024, 1, 1));
        var coffee = new Item("Coffee", 20);
        var sandwich = new Item("Sandwich", 15);
        var batteries = new Item("Batteries", 10);
        var umbrella = new Item("Umbrella", 5);
        var sunscreen = new Item("Sunscreen", 8);

        PrintDivider();
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("* Add Item *");

        store.AddItem(sunscreen);
        store.AddItem(waterBottle);
        store.AddItem(chocolateBar);
        store.AddItem(tissuePack);
        store.AddItem(notebook);
        store.AddItem(pen);
        store.AddItem(coffee);
        store.AddItem(toothbrush);
        store.AddItem(chipsBag);
        store.AddItem(sodaCan);
        store.AddItem(soap);
        store.AddItem(shampoo);
        store.AddItem(sandwich);
        store.AddItem(batteries);
        store.AddItem(umbrella);

        PrintDivider();

        Console.WriteLine(store.GetCapacity());

        PrintDivider();

        store.RemoveItem(waterBottle);

        PrintDivider();

        // Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.WriteLine($"The total amount of items in the {store.GetName()} store {store.GetCurrentVolume()}");

        PrintDivider();

        // Console.ForegroundColor = ConsoleColor.Green;

        store.FindItemByName("Coffee");
        store.FindItemByName("Coff");

        PrintDivider();

        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("* Display Items *");

        store.GetItems();

        PrintDivider();

        List<Item> sortedItemByDate = store.SortByDate(SortOrder.DESC);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("* Sorted Item By Date *");

        store.DisplayList(sortedItemByDate);

        PrintDivider();
        
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("* Group By Date *");

        store.GroupByDate();
    }
}