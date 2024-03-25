namespace ItemSpace;

public class Items
{
    public string? Name { get; }
    private double Quantity { get; set; }
    private DateTime CreatedDate { get; set; }
    public Items(string name, double quantity = 0, DateTime createdDate = default)
    {
        try
        {
            if (quantity < 0)
            {
                throw new Exception("Quantity can not be negative");
            }
            Name = name;
            Quantity = quantity;
            CreatedDate = createdDate == default ? DateTime.Now : createdDate ;
        }
        catch (Exception error)
        {
          Console.WriteLine("Error: " + error.Message);
        }
    }
    public override string ToString()
    {
        return $"Item Name: {Name},Quantity: {Quantity},Created Date: {CreatedDate}";
    }
}
