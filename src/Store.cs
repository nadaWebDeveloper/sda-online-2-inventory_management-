using System.ComponentModel.DataAnnotations;
using ItemSpace;
namespace StoreSpace;

class Stores
{
    private List<Items> _ItemsInventory;
    private int _maximumCapacity;
    public int MaximumCapacity
    {
        get { return _maximumCapacity; }
    }
    public int CurrentCapacity
    {
        get { return _ItemsInventory.Count; }
    }

    public Stores(int maximumCapacity)
    {
        this._maximumCapacity = maximumCapacity;
        _ItemsInventory = new List<Items>();
    }
    public void AddItem(Items newItem)
    {
        bool isItemExist = _ItemsInventory.Any((item) => item.Name?.ToLower() == newItem.Name?.ToLower());
        if (isItemExist)
        {
            Console.WriteLine($"This Item '{newItem.Name}' Already Exists");
            return;
        }
        if (_ItemsInventory.Count < MaximumCapacity)
        {
            _ItemsInventory.Add(newItem);
            Console.WriteLine($"Item '{newItem.Name}' added to the inventory Successfully.");
        }
        else
        {
            Console.WriteLine("Inventory is full. Cannot add more items.");
        }
    }
    public void DeleteItem(string itemName)
    {
        Items? deletedItem = _ItemsInventory.FirstOrDefault((item) => item.Name?.ToLower() == itemName.ToLower());
        if (deletedItem != null)
        {
            _ItemsInventory.Remove(deletedItem);
            Console.WriteLine($"Deleted Item '{itemName}' Successfully");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' Not Founded on Store");
        }
    }
    public void PrintItems()
    {
        if (_ItemsInventory.Count > 0)
        {
            Console.WriteLine($"\t\t\tPrint All Items:");
            foreach (var newItem in _ItemsInventory)
            {
                Console.WriteLine($"{newItem}");
            }
            Console.WriteLine($"\t\t\t ----------");
        }
        else
        {
            Console.WriteLine($"Not Have List Of Item");
        }
    }
    public double GetCurrentVolume()
    {
        return _ItemsInventory.Sum(item => item.Quantity);
    }
    public Items FindItemByName(string itemName)
    {
        Items? foundItem = _ItemsInventory.FirstOrDefault(item => item.Name?.ToLower() == itemName?.ToLower());
        return foundItem ?? new Items();
    }
    public List<Items> SortByName(SortOrder sortOrder)
    {
        try
        {
            switch (sortOrder)
            {
                case SortOrder.ASC:
                    return _ItemsInventory.OrderBy(item => item.Name).ToList();
                case SortOrder.DESC:
                    return _ItemsInventory.OrderByDescending(item => item.Name).ToList();
                default:
                    throw new ArgumentException("Invalid sort order specified.");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"{error.Message}");
             return new List<Items>();

        }
    }
}