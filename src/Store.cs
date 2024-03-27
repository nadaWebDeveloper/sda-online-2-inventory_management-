using System.ComponentModel.DataAnnotations;
using ItemSpace;
namespace StoreSpace;

class Store
{
    BorderSecondSpace.BorderSecond border = new BorderSecondSpace.BorderSecond();
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
        try
        {
            bool isItemExist = _itemsInventory.Any((item) => item.Name?.ToLower() == newItem.Name?.ToLower());
            if (isItemExist)
            {
                border.SecondBorder($"↺ This Item '{newItem.Name}' Already Exists", ConsoleColor.Gray, ConsoleColor.DarkGray);
            }
            if (_itemsInventory.Sum(item => item.Quantity) + newItem.Quantity <= MaximumCapacity)
            {
                _itemsInventory.Add(newItem);
                border.SecondBorder($"✔ Item '{newItem.Name}' added to the inventory Successfully.", ConsoleColor.DarkGreen, ConsoleColor.Green);
            }
            else
            {
                border.SecondBorder("✗ Inventory is full. Cannot add more items.", ConsoleColor.DarkRed, ConsoleColor.Red);
                throw new Exception();
            }
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
    }
    public void DeleteItem(string itemName)
    {
        try
        {
            Item? deletedItem = _itemsInventory.FirstOrDefault((item) => item.Name?.ToLower() == itemName.ToLower());
            if (deletedItem != null)
            {
                _itemsInventory.Remove(deletedItem);
                border.SecondBorder($"✔ Deleted Item '{itemName}' Successfully", ConsoleColor.DarkGreen, ConsoleColor.Green);
            }
            else
            {
                border.SecondBorder($"✗ Item '{itemName}' Not Founded on Store", ConsoleColor.DarkRed, ConsoleColor.Red);
                throw new Exception();
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"{error.Message}");
        }
    }
    public void PrintItems()
    {
        try
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
                Console.ForegroundColor = ConsoleColor.DarkRed;
                throw new Exception($"Not Have List Of Item");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"{error.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public double GetCurrentVolume()
    {
        return _itemsInventory.Sum(item => item.Quantity);
    }
    public Item? FindItemByName(string itemName)
    {
        Item? foundItem = _itemsInventory.FirstOrDefault(item => item.Name?.ToLower() == itemName?.ToLower());
        return foundItem;
    }
    public List<Item> SortByName(SortOrder sortOrder)
    {
        return sortOrder == SortOrder.ASC ?
             _itemsInventory.OrderBy(item => item.Name).ToList()
             : _itemsInventory.OrderByDescending(item => item.Name).ToList();
    }
    public Dictionary<string, List<Item>> GroupByDate()
    {
        var currentMonth = DateTime.Now.AddMonths(-3);

        var groupedItems = _itemsInventory.GroupBy(
            item => item.CreatedDate >= currentMonth ? "New Arrival Items" : "Old Items"
        ).ToDictionary(
            group => group.Key,
            group => group.ToList()
        );

        foreach (var group in groupedItems)
        {
            Console.WriteLine($"{group.Key}:");
            foreach (var item in group.Value)
            {
                Console.WriteLine($"- {item.Name} ({item.CreatedDate:MMMM yyyy})");
            }
            Console.WriteLine();
        }

        return groupedItems;
    }
}