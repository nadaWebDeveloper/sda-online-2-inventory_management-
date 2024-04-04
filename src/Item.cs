namespace ItemSpace;

public class Item
{
    public string? Name { get; }
    private double _quantity;
    public double Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }
    public DateTime CreatedDate
    {
        get;
        set;
    }
    public Item(string name, double quantity, DateTime createdDate = default)
    {
            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate == default ? DateTime.Now : createdDate;
    }
    public override string ToString()
    {
        string text = $"\x1b[95m𐡛 \x1b[94mItem Name :   \x1b[90m{Name?.PadRight(25)?? "N/A"}\x1b[94m ,Quantity :   \x1b[90m{Quantity.ToString().PadRight(20)}\x1b[94m ,Created Date :   \x1b[90m{CreatedDate.ToString("MMMM/dd/yyyy")}\x1b[94m";
        int boxWidth = Math.Max(text.Length + 6, 182);
        int padding =(boxWidth - text.Length - 4) / 2;
        string paddedMessage = text + new string(' ', padding + (text.Length % 2 == 0 ? 0 : 1));
        return $"\t\t{paddedMessage}";
    }
}
