// One item on the shopping list.
class Item
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Värdet får inte vara tomt", nameof(Name));
            }
            _name = value;
        }
    }

    private int _price;
    public int Price
    {
        get { return _price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Värdet får inte vara negativt");
            }
            _price = value;
        }
    }
    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
