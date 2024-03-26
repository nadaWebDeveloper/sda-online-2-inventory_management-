using ItemSpace;
using StoreSpace;
class Programs
{
   public static void Main(string[] args)
   {
      ItemSpace.Item waterBottle = new ItemSpace.Item("Water Bottle", 7, new DateTime(2023, 6, 1));
      ItemSpace.Item coffee = new ItemSpace.Item("coffee", 8, new DateTime(2023, 1, 1));
      ItemSpace.Item coffee2 = new ItemSpace.Item("COFFEE", 4, new DateTime(2023, 1, 1));

      ItemSpace.Item sandwich = new ItemSpace.Item("sandwich", 3, new DateTime(2023, 1, 1));
      ItemSpace.Item batteries = new ItemSpace.Item("batteries", 23, new DateTime(2023, 8, 9));
      ItemSpace.Item umbrella = new ItemSpace.Item("umbrella", 109);
      ItemSpace.Item sunscreen = new ItemSpace.Item("sunscreen", 5);

      StoreSpace.Store store = new StoreSpace.Store(100);
      store.AddItem(coffee);
      store.AddItem(batteries);
      store.AddItem(waterBottle);
      store.AddItem(sandwich);
      store.AddItem(umbrella);
      store.AddItem(sunscreen);
      store.AddItem(coffee2);



      store.DeleteItem("Coffee");
      store.DeleteItem("glasses");

      double currentValue = store.GetCurrentVolume();
      string resultSum = currentValue == 0 ? "Not Have Any Quantity On Store" : store.GetCurrentVolume().ToString();
      Console.ForegroundColor = ConsoleColor.DarkGreen;
      Console.WriteLine($"Sum of Quantity: {resultSum}");
            Console.ForegroundColor = ConsoleColor.White;
     Console.WriteLine();



      Item resultSearch = store.FindItemByName("sandwiches");
      Console.WriteLine($"\t\t\tResult Of Search:\n {resultSearch}\n\t\t\t ----------");

      var collectionData = store.SortByName(SortOrder.DESC);
      Console.WriteLine($"\t\t    Sort Order By Name:");
      foreach (var item in collectionData)
      {
         Console.WriteLine($"{item}");
      }
      Console.WriteLine($"\t\t\t ----------");

      Dictionary<string, List<Item>> categorizedItems = store.GroupByDate();

  foreach (KeyValuePair<string, List<Item>> category in categorizedItems)
        {
            Console.WriteLine($"{category.Key}:");
            foreach (Item item in category.Value)
            {
                Console.WriteLine($"- {item.Name.PadRight(7)} (Created: {item.CreatedDate})");
            }
        }
  
     

      // store.PrintItems();



   }
}