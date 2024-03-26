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
    private DateTime _createdDate;
    public DateTime CreatedDate
    {
        get { return _createdDate; }
        set { _createdDate = default; }
    }
    public Item(string name, double quantity, DateTime createdDate = default)
    {
        try
        {
            if (quantity < 0)
            {
                throw new Exception("Quantity can not be negative");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name field is Required");
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
        // if (!string.IsNullOrEmpty(Name) && Quantity >= 0 && CreatedDate != null)
        // {
            return $"Item Name: {Name}, Quantity: {Quantity}, Created Date: {CreatedDate}";
        // }
        // else
        // {
        //     return "Not Have Any Items";
        // }
    }
}
