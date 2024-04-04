using ItemSpace;
using BorderSecondSpace;
using StoreSpace;
using MenuItemSpace;
using EnterFromUserSpace;
using ReadKeySpace;

class Programs
{
   static Store? store;
   //static List<Item>? resultSearch;
   static int boxWidth = 150;
   static List<Item>? collectionData;
   public static void Main(string[] args)
   {
      ReadFile read = new ReadFile();
      read.ReadFiles("Hero.txt");

      MenuItem.ListMenu();

      store = new Store(900);

      Item waterBottle = new Item("Water Bottle", 7, new DateTime(2023, 2, 4));
      Item coffee = new Item("coffee", 8, new DateTime(2023, 1, 7));
      Item coffee2 = new Item("COFFEE top", 4, new DateTime(2023, 2, 1));
      Item sandwich = new Item("sandwich", 3, new DateTime(2023, 9, 9));
      Item batteries = new Item("batteries", 23, new DateTime(2024, 8, 9));
      Item umbrella = new Item("umbrella", 109, new DateTime(2024, 8, 9));
      Item sunscreen = new Item("sunscreen", 5, new DateTime(2024, 1, 9));
      Item computer = new Item("computer", 5, new DateTime(2024, 8, 9));


      store.AddItem(coffee2);
      store.AddItem(coffee);
      store.AddItem(batteries);
      store.AddItem(waterBottle);
      store.AddItem(sandwich);
      store.AddItem(umbrella);
      store.AddItem(sunscreen);
      store.AddItem(computer);

//ReadKey.Test();

      // store.DeleteItem("Coffee");
      // store.DeleteItem("glasses");


      //EnterFromUser.SearchItemFromStore();

      // string[] listKey2 = {"Group By Date", "Group By Quantity","Exit"};
      // ReadKey.PressKey(listKey2);

      static void selectChooseFromUser()
      {
         Console.BackgroundColor = ConsoleColor.Black;
         string text = "Sort Data:";
         BorderSecond.SecondBorder(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);
         Console.ResetColor();

         SortOrder selectedOrder = GetSelectedSortFromUser();
         SortOrderSpecific selectedOrderSpecific = GetSelectedSortSpecificFromUser();

         collectionData = store?.SortData(selectedOrder, selectedOrderSpecific);
      }

      static SortOrder GetSelectedSortFromUser()
      {
      string text = "Select Sort Order By:";
      BorderSecond.SecondBorder(text, ConsoleColor.White, ConsoleColor.DarkGray); 
       int x = 0;
        int y = 0;

        while (true)
        {
            // Display the current position
            Console.Clear(); // Clear the console before redrawing
            Console.SetCursorPosition(x, y);
       string[] listKey = {"Descending", "Ascending"};
           string result =  ReadKey.PressKey(listKey);
           Console.Clear();
             if (result == "Ascending")
         {
            return SortOrder.ASC;
         }
         else if (result == "Descending")
         {
            return SortOrder.DESC;
         }
  
         return SortOrder.ASC;}
      }

      static SortOrderSpecific GetSelectedSortSpecificFromUser()
      {
         string text = "Select Specific Column:";
         BorderSecond.SecondBorder(text, ConsoleColor.White, ConsoleColor.DarkGray);
         string[] listKey1 = { "Sort By Created Date", "Sort By Name", "Sort By Quantity" };
         string result = ReadKey.PressKey(listKey1);
         Console.Clear();
         if (result == "Sort By Created Date")
         {
            return SortOrderSpecific.CreatedDate;
         }
         else if (result == "Sort By Name")
         {
            return SortOrderSpecific.Name;
         }
         else if (result == "Sort By Quantity")
         {
            return SortOrderSpecific.Quantity;
         }
         return SortOrderSpecific.Name;
      }

//selectChooseFromUser();

      try
      {
         if (collectionData!= null &&collectionData.Any())
         {
            Console.WriteLine($"\t\t\x1b[1m\x1b[91m𐪞 \x1b[97mSort Order:");
            Console.WriteLine("\t\t\x1b[1m\x1b[97m╭" + new string('─', boxWidth - 2) + "╮");
            Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
            foreach (var item in collectionData)
            {
               Console.WriteLine($"{item}");
            }
            Console.WriteLine("\t\t\x1b[1m\x1b[94m│" + new string(' ', boxWidth - 2) + "│");
            Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
         }
         else
         {
            throw new Exception($"\x1b[3;97mNot Have Items To Sorted");
         }
      }
      catch (Exception error)
      {
         Console.WriteLine($"\t\t\x1b[1;91m⚠︎  {error.Message}");
      }

      double currentValue = store.GetCurrentVolume();
      string resultSum = currentValue == 0
     ? "\t\t\x1b[1;91m⚠︎ \x1b[3;97m Not Have Any Quantity On Store"
      : $"\t\t\x1b[1m\x1b[91mᛊ \x1b[3;97mSum of Quantity: \x1b[2m\x1b[92m{store.GetCurrentVolume().ToString()}\x1b[0m";
      BorderSecond.SecondBorder(resultSum, ConsoleColor.DarkRed, ConsoleColor.Red);


      store.GroupByDate();
      store.GroupByQuantity();
      store.PrintItems();
   }
}