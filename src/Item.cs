namespace ItemSpace;

public class Item
{
     BorderSecondSpace.BorderSecond border = new BorderSecondSpace.BorderSecond();

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
        try
        {
            if (quantity < 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new Exception("✗ Quantity can not be negative");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new Exception("✗ Name field is Required");
            }
            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate == default ? DateTime.Now : createdDate;
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public override string ToString()
    {
          border.SecondBorder($"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate.ToString("MMMM/dd/yyyy")}", ConsoleColor.Cyan, ConsoleColor.DarkCyan);
      return $"-";
    }
}
