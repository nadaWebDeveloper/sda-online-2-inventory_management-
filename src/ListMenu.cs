using BorderMainSpace;
namespace MenuItemSpace;

public class MenuItem
{
    public string Title { get; set; }
    public string Tip { get; set; } 

    public MenuItem(string title, string tip = "")
    {
        Title = title;
        Tip = tip;
    }

     //Record
     static MenuItem[] menuItems = new MenuItem[]
      {
            new MenuItem("MENU"),
            new MenuItem(""," "),
            new MenuItem("Add New Item"),
            new MenuItem("Delete Item"),
            new MenuItem("List Items"),
            new MenuItem("Find Item"),
            new MenuItem("Sort Data", "Sort ASC (A-Z) And DESC (Z-A)"),
            new MenuItem("Group Data", "Group Data By Date And Quantity"),
            new MenuItem("Exit")
      };
public static void ListMenu(){
          int boxWidth = 150;

      Console.WriteLine("\t\t\x1b[1m\x1b[97m╭" + new string('─', boxWidth - 2) + "╮");
      Console.WriteLine("\t\t│" + new string(' ', boxWidth - 2) + "│");
      foreach (MenuItem item in menuItems)
      {
         Console.ForegroundColor = ConsoleColor.DarkMagenta;
         string text = "\x1b[95m𐡛 \x1b[94m" + item.Title;
         string formatTitle = BorderMain.MainBorder(text);
         Console.WriteLine(formatTitle);
         if (!string.IsNullOrEmpty(item.Tip))
         {
            string tip = "\x1b[92mTip: \x1b[97m" + item.Tip;
            string formatTip = BorderMain.MainBorder(tip);
            Console.WriteLine(formatTip);
         }
      }
      Console.WriteLine("\t\t│" + new string(' ', boxWidth - 2) + "│");
      Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
      Console.ResetColor();
}

}




