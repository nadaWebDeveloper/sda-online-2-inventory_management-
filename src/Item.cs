namespace ItemSpace;

public class Items
{
    public string? Name { get; }
    private double quantity;
    public double Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
    private DateTime? CreatedDate { get; set; }
    public Items() { }
    public Items(string name, double quantity, DateTime createdDate = default)
    {
        try
        {
            if (quantity < 0)
            {
                throw new Exception("Quantity can not be negative");
            }
            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate == default ? DateTime.Now : createdDate;
        }
        catch (Exception error)
        {
            Console.WriteLine("Error: " + error.Message);
        }
    }
    public override string ToString()
    {
        if (!string.IsNullOrEmpty(Name) && Quantity >= 0 && CreatedDate != null)
        {
            return $"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
        }
        else
        {
            return "Not Have Any Items";
        }
    }
}
