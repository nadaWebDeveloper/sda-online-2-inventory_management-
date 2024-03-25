using ItemSpace;
namespace StoreSpace;

class Stores
{
    private List<Items> items = new List<Items>();
    public void AddItem(Items newItem)
    {
        bool isItemExist = items.Any((item) => item.Name?.ToLower() == newItem.Name?.ToLower());
        if (isItemExist)
        {
            Console.WriteLine($"This Item '{newItem.Name}' Already Exists");
            return;
        }
        items.Add(newItem);
        Console.WriteLine($"Added Item '{newItem.Name}' Successfully");
    }
    public void DeleteItem(string itemName)
    {
        Items? deletedItem = items.FirstOrDefault((item) => item.Name?.ToLower() == itemName.ToLower());
        if (deletedItem != null)
        {
            items.Remove(deletedItem);
            Console.WriteLine($"Deleted Item '{itemName}' Successfully");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' Not Founded on Store");
        }
    }
    public void PrintItems()
    {
        Console.WriteLine($"\t\t\tPrint All Items:");
        foreach (var newItem in items)
        {
            Console.WriteLine($"{newItem}");
        }
        Console.WriteLine($"\t\t\t ----------");
        
    }
    public double GetCurrentVolume()
    {
        return items.Sum(item => item.Quantity);
    }
    public Items FindItemByName(string itemName)
    {
        Items? foundItem = items.FirstOrDefault(item => item.Name?.ToLower() == itemName?.ToLower());
        return foundItem ?? new Items();
    }
    public List<Items> SortByNameAsc()
    {
        return items.OrderBy(item => item.Name).ToList();
    }
}