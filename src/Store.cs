using ItemSpace;
namespace StoreSpace;
using BorderSecondSpace;
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
            BorderSecond.SecondBorder($"↺ This Item '{newItem.Name}' Already Exists", ConsoleColor.Gray, ConsoleColor.DarkGray);
            return;
        }
        if (_itemsInventory.Sum(item => item.Quantity) + newItem.Quantity <= MaximumCapacity)
        {
            _itemsInventory.Add(newItem);
            BorderSecond.SecondBorder($"✔ Item '{newItem.Name}' added to the inventory Successfully.", ConsoleColor.DarkGreen, ConsoleColor.Green);
        }
        else
        {
            BorderSecond.SecondBorder("✘ Inventory is full. Cannot add more items.", ConsoleColor.DarkRed, ConsoleColor.Red);
            return;
        }

    }
    public void DeleteItem(string itemName)
    {
        Item? deletedItem = _itemsInventory.FirstOrDefault((item) => item.Name?.ToLower() == itemName.ToLower());
        if (deletedItem != null)
        {
            _itemsInventory.Remove(deletedItem);
            BorderSecond.SecondBorder($"✔ Deleted Item '{itemName}' Successfully", ConsoleColor.DarkGreen, ConsoleColor.Green);
        }
        else
        {
            BorderSecond.SecondBorder($"✘ Item '{itemName}' Not Founded on Store", ConsoleColor.DarkRed, ConsoleColor.Red);
            return;
        }
    }
    public void PrintItems()
    {
        try
        {
            if (_itemsInventory.Count > 0)
            {
                int boxWidth = 150;
                Console.WriteLine($"\t\t\x1b[1m\x1b[91m𐧿  \x1b[97mAll Items:");
                Console.WriteLine("\t\t\x1b[1m╭" + new string('─', boxWidth - 2) + "╮");
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                foreach (var newItem in _itemsInventory)
                {
                    Console.WriteLine($"{newItem}");
                }
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
            }
            else
            {
                throw new Exception($"\x1b[3;97mNot Have List Of Item");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"\t\t\x1b[1;91m⚠︎  {error.Message}");
        }
    }
    public double GetCurrentVolume()
    {
        return _itemsInventory.Sum(item => item.Quantity);
    }
    public List<Item> FindItemsByName(string itemName)
    {
        Item? foundItem = _itemsInventory.FirstOrDefault(item => item.Name?.ToLower() == itemName?.ToLower());

        List<Item> similarItems = new List<Item>();
        if (foundItem != null)
        {
            similarItems.Add(foundItem);

            var additionalItems = _itemsInventory
                .Where(item => item != foundItem && item.Name != null && item.Name.ToLower().Contains(itemName.ToLower()))
                .ToList();

            similarItems.AddRange(additionalItems);
        }
        return similarItems;
    }
    public List<Item> SortData(SortOrder sortOrder, SortOrderSpecific sortOrderSpecific)
    {
        Func<Item, IComparable> sortingKey = sortOrderSpecific switch
        {
            SortOrderSpecific.Name => item => item.Name ?? "",
            SortOrderSpecific.Quantity => item => item.Quantity,
            SortOrderSpecific.CreatedDate => item => item.CreatedDate,
            _ => throw new ArgumentException("Invalid sortOrderSpecific value")
        };

        return sortOrder == SortOrder.ASC ?
             _itemsInventory.OrderBy(sortingKey).ToList()
             : _itemsInventory.OrderByDescending(sortingKey).ToList();
    }
    public Dictionary<string, List<Item>> GroupByDate()
    {
        int currentMonth = DateTime.Now.Month;
        // Calculate the month range for new arrivals (last three months)
        int startMonth = currentMonth - 2;
        if (startMonth <= 0)
        {
            startMonth += 12; // Adjust for negative values
        }
        var groupedItems = _itemsInventory.GroupBy(
            item => item.CreatedDate.Month >= startMonth && item.CreatedDate.Month <= currentMonth ? "New Arrival Items" : "Old Items"
        ).ToDictionary(
            group => group.Key,
            group => group.ToList()
        );
        if (groupedItems.Any())
        {
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"\n\x1b[1m\x1b[91m\t\t𖼧 \x1b[97m{group.Key} :\x1b[2m\x1b[93m");
                foreach (var item in group.Value)
                {
                    Console.WriteLine($"\t\t𑣪 \x1b[92m{item.Name} \x1b[93m:{item.Quantity}");
                }
                Console.WriteLine("\x1b[0m");
            }
        }
        else
        {
            Console.WriteLine($"\t\t\x1b[1;91m⚠︎ \x1b[3;97m Not Have Items To Grouped By Date");
        }
        return groupedItems;
    }
    public Dictionary<string, List<Item>> GroupByQuantity()
    {
        var groupedItems = _itemsInventory.GroupBy(
            item => item.Quantity < 20 ? "Quantity Under 20" : item.Quantity < 50 ? "Quantity Between 20 - 50" : "Quantity Above 50"
        ).ToDictionary(
            group => group.Key,
            group => group.ToList()
        );
        if (groupedItems.Any())
        {
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"\n\x1b[1m\x1b[91m\t\t𖼧 \x1b[97m{group.Key} :\x1b[2m\x1b[93m");
                foreach (var item in group.Value)
                {
                    Console.WriteLine($"\t\t𑣪 \x1b[92m{item.Name} \x1b[93m:{item.Quantity}");
                }
                Console.WriteLine("\x1b[0m");
            }
        }
        else
        {
            Console.WriteLine($"\t\t\x1b[1;91m⚠︎ \x1b[3;97m Not Have Items To Grouped By Quantity");
        }
        return groupedItems;
    }
}