using ItemSpace;
using StoreSpace;
class Programs
{
   public static void Main(string[] args)
   {
      ItemSpace.Items waterBottle = new ItemSpace.Items("Water Bottle", 7, new DateTime(2023, 1, 1));
      ItemSpace.Items coffee = new ItemSpace.Items("coffee", 8, new DateTime(2023, 1, 1));
      ItemSpace.Items coffee2 = new ItemSpace.Items("COFFEE", 4, new DateTime(2023, 1, 1));

      ItemSpace.Items sandwich = new ItemSpace.Items("sandwich", 3, new DateTime(2023, 1, 1));
      ItemSpace.Items batteries = new ItemSpace.Items("batteries", 23, new DateTime(2023, 1, 1));
      ItemSpace.Items umbrella = new ItemSpace.Items("umbrella", 109);
      ItemSpace.Items sunscreen = new ItemSpace.Items("sunscreen", 5);

      StoreSpace.Stores store = new StoreSpace.Stores(4);
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
      Console.WriteLine($"Sum of Quantity: {resultSum}");

      Items resultSearch = store.FindItemByName("sandwiches");
      Console.WriteLine($"\t\t\tResult Of Search:\n {resultSearch}\n\t\t\t ----------");

      var collectionData = store.SortByName(SortOrder.DESC);
      Console.WriteLine($"\t\t    Sort Order By Name:");
      foreach (var item in collectionData)
      {
         Console.WriteLine($"{item}");
      }
      Console.WriteLine($"\t\t\t ----------");



      store.PrintItems();



   }
}