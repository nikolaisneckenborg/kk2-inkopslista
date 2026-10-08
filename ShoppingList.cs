// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int budget = 0;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public bool Add(Item item)
    {
        if(Total() + item.Price > budget)
        {
            return false;
        }
        items.Add(item);
        return true;
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
        Console.WriteLine($"Du har {RemainingBudget()} kr kvar i din budget.");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
            Console.WriteLine("Listan är sparad.");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine($"Kunde inte spara: du har inte behörighet att skriva till filen: {e.Message}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Kunde inte spara: {e.Message}");
        }
    }

    // Reads the file back into the list.
    public void Load()
    {
        try{
        string text = File.ReadAllText(path);
        string[] lines = text.Trim().Split('\n');
        foreach (string line in lines)
        {
            string[] parts = line.Trim().Split(';');
            items.Add(new Item(parts[1], int.Parse(parts[0])));
        }
        }
        catch(FileNotFoundException e)
        {
            Console.WriteLine($"Filen kunde inte hittas:{e.Message}");
        }
    }
    public int Count()
    {
        return items.Count;
    }
    public void SetBudget(int budgetInput)
    {
        if (budgetInput < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(budgetInput), "Budgeten får inte vara negativ");
        }
        budget = budgetInput;
    }
    public int RemainingBudget()
    {
        return budget - Total();
    }
}
