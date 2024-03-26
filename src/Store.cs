using System.ComponentModel.DataAnnotations;
using ItemSpace;
namespace StoreSpace;

class Store
{
    private List<Item> _itemsInventory;
    private int _maximumCapacity;
    public int MaximumCapacity
    {
        get { return _maximumCapacity; }
    }
    public int CurrentCapacity
    {
        get { return _itemsInventory.Count; }
    }
    public Store(int maximumCapacity)
    {
        this._maximumCapacity = maximumCapacity;
        _itemsInventory = new List<Item>();
    }
    public void AddItem(Item newItem)
    {
        bool isItemExist = _itemsInventory.Any((item) => item.Name?.ToLower() == newItem.Name?.ToLower());
        if (isItemExist)
        {
            Console.WriteLine($"This Item '{newItem.Name}' Already Exists");
            return;
        }
        if (_itemsInventory.Sum(item => item.Quantity) + newItem.Quantity <= MaximumCapacity)
        {
            _itemsInventory.Add(newItem);
            Console.WriteLine($"Item '{newItem.Name}' added to the inventory Successfully.");
        }
        else
        {
            Console.WriteLine("Inventory is full. Cannot add more items.");
        }
    }
    public void DeleteItem(string itemName)
    {
        Item? deletedItem = _itemsInventory.FirstOrDefault((item) => item.Name?.ToLower() == itemName.ToLower());
        if (deletedItem != null)
        {
            _itemsInventory.Remove(deletedItem);
            Console.WriteLine($"Deleted Item '{itemName}' Successfully");
        }
        else
        {
            Console.WriteLine($"Item '{itemName}' Not Founded on Store");
        }
    }
    public void PrintItems()
    {
        if (_itemsInventory.Count > 0)
        {
            Console.WriteLine($"\t\t\tPrint All Items:");
            foreach (var newItem in _itemsInventory)
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
        return _itemsInventory.Sum(item => item.Quantity);
    }
    public Item? FindItemByName(string itemName)
    {
        Item? foundItem = _itemsInventory.FirstOrDefault(item => item.Name?.ToLower() == itemName?.ToLower());
        return foundItem ;
    }
    public List<Item> SortByName(SortOrder sortOrder)
    {
        try
        {
            switch (sortOrder)
            {
                case SortOrder.ASC:
                    return _itemsInventory.OrderBy(item => item.Name).ToList();
                case SortOrder.DESC:
                    return _itemsInventory.OrderByDescending(item => item.Name).ToList();
                default:
                    throw new ArgumentException("Invalid sort order specified.");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"{error.Message}");
            return new List<Item>();
        }
    }public Dictionary<string, List<Item>> GroupByDate()
    {
        DateTime currentDate = DateTime.Now;
        int currentMonth = currentDate.Month;
        int currentYear = currentDate.Year;

        DateTime cutoffDate = currentDate.AddMonths(-3);

        Dictionary<string, List<Item>> categorizedItems = new Dictionary<string, List<Item>>();
        categorizedItems.Add("New Arrival Items", new List<Item>());
        categorizedItems.Add("Old Items", new List<Item>());

        foreach (Item item in _itemsInventory)
        {
            if (item.CreatedDate.Year == currentYear && item.CreatedDate.Month >= currentMonth - 2)
            {
                // categorizedItems["New Arrival Items"].Add(item);
                                categorizedItems["Old Items"].Add(item);

            }
            else
            {
                // categorizedItems["Old Items"].Add(item);
                 categorizedItems["New Arrival Items"].Add(item);

            }
        }

        return categorizedItems;
    }
}