ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        
        Console.Write("Namn: ");
        string nameInput = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(nameInput))
        {
            Console.Write("Skriv ett giltigt Namn: ");
            nameInput = Console.ReadLine();
        }
        Console.Write("Pris: ");
        string priceInput = Console.ReadLine()!;
        int number;
        while(!(int.TryParse(priceInput, out number)) | number<1)
        {
            Console.Write("Ange ett positivt heltal: ");
            priceInput = Console.ReadLine()!;
        }
        
        list.Add(new Item(nameInput, number));
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        int number = int.Parse(Console.ReadLine());
        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
