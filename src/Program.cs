using ItemSpace;
using StoreSpace;

class Programs
{

   public static void Main(string[] args)
   {


      BorderMainSpace.BorderMain border = new BorderMainSpace.BorderMain();
     border.MainBorder("Hello, world! ", ConsoleColor.Blue);
     
      

      ItemSpace.Item waterBottle = new ItemSpace.Item("Water Bottle", 7, new DateTime(2023, 2, 4));
      ItemSpace.Item coffee = new ItemSpace.Item("coffee", 8, new DateTime(2023, 1, 7));
      ItemSpace.Item coffee2 = new ItemSpace.Item("COFFEE", 4, new DateTime(2023, 2, 1));

      ItemSpace.Item sandwich = new ItemSpace.Item("sandwich", 3, new DateTime(2023, 9, 9));
      ItemSpace.Item batteries = new ItemSpace.Item("batteries", 23, new DateTime(2024, 8, 9));
      ItemSpace.Item umbrella = new ItemSpace.Item("umbrella", 109, new DateTime(2024, 8, 9));
      ItemSpace.Item sunscreen = new ItemSpace.Item("sunscreen", 5, new DateTime(2024, 1, 9));
      ItemSpace.Item computer = new ItemSpace.Item("computer", 5, new DateTime(2024, 8, 9));


      StoreSpace.Store store = new StoreSpace.Store(100);
      store.AddItem(coffee);
      store.AddItem(batteries);
      store.AddItem(waterBottle);
      store.AddItem(sandwich);
      store.AddItem(umbrella);
      store.AddItem(sunscreen);
      store.AddItem(coffee2);
        store.AddItem(computer);



      store.DeleteItem("Coffee");
      store.DeleteItem("glasses");

      double currentValue = store.GetCurrentVolume();
      string resultSum = currentValue == 0 ? "Not Have Any Quantity On Store" : store.GetCurrentVolume().ToString();
      Console.WriteLine($"Sum of Quantity: {resultSum}");
   
      Item? resultSearch = store.FindItemByName("sandwich");
      Console.WriteLine($"\t\t\tResult Of Search:\n {resultSearch}\n\t\t\t ----------");

      var collectionData = store.SortByName(SortOrder.ASC);
      Console.WriteLine($"\t\t    Sort Order By Name:");
      foreach (var item in collectionData)
      {
         Console.WriteLine($"{item}");
      }
      Console.WriteLine($"\t\t\t ----------");

     store.GroupByDate();


     store.PrintItems();
   }
}