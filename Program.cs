ShoppingList list = new ShoppingList("items.txt");
list.Load();
list.SetBudget(Budget());

int Budget()
{
    Console.Write("Ange din budget för shoppinglistan: ");
    string input = Console.ReadLine();
    int budget;
    while (!int.TryParse(input, out budget) || budget < 0)
    {
        Console.Write("Ange ett positivt heltal för budgetten: ");
        input = Console.ReadLine();
    }
    return budget;
}

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

    string menuchoice = Console.ReadLine();
    int choice;
    while (!int.TryParse(menuchoice, out choice) | choice < 1 | choice > 5)
    {
        Console.Write("Ange ett giltigt menyval: ");
        menuchoice = Console.ReadLine()!;
    }

    if (choice == 1)
    {

        Console.Write("Namn: ");
        string nameInput = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(nameInput))
        {
            Console.Write("Skriv ett giltigt Namn: ");
            nameInput = Console.ReadLine();
        }
        if (list.Find(nameInput) != null)
        {
            Console.WriteLine("Varan finns redan i listan.");
        }
        else
        {
            Console.Write("Pris: ");
            string priceInput = Console.ReadLine()!;
            int number;
            while (!int.TryParse(priceInput, out number) | number < 1)
            {
                Console.Write("Ange ett positivt heltal:");
                priceInput = Console.ReadLine()!;
            }
            try
            {
                Item item = new Item(nameInput, number);
                if (list.Add(item))
                {
                    Console.WriteLine($"{item.Name} lades till.");
                }
                else
                {
                    Console.WriteLine($"{item.Name} kostar {item.Price} kr men du har bara {list.RemainingBudget()} kr kvar. Varan lades inte till.");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ogiltig vara: {e.Message}");
            }
        }
    }
    else if (choice == 2)
    {
        if (list.Count() == 0)
        {
            Console.WriteLine("Listan är tom, det finns inget att ta bort.");
        }
        else
        {
            Console.Write("Nummer: ");
            string input = Console.ReadLine();
            int number;
            while (!int.TryParse(input, out number) | number < 1 | number > list.Count())
            {
                Console.Write("Ange en giltig vara: ");
                input = Console.ReadLine()!;
            }
            list.RemoveAt(number);
        }
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
