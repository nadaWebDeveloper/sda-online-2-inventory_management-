
namespace BorderMainSpace;
class BorderMain
{
    public  void MainBorder(string text, ConsoleColor color)
    {
        string message = text;
        // int width = message.Length + 134; 
        int boxWidth = Math.Max(message.Length + 6, 150);// Add 4 for left and right borders
        int height = 5; // Height of the box


        Console.ForegroundColor = color;
        // Print top border
        Console.WriteLine("\t\t╭" + new string('─', boxWidth - 2) + "╮");
         Console.WriteLine("\t\t│" + new string(' ', boxWidth - 2) + "│");


         int padding = (boxWidth - message.Length - 4) / 2;
        string paddedMessage = new string(' ', padding) + message + new string(' ', padding + (message.Length % 2 == 0 ? 0 : 1));

Console.ForegroundColor = ConsoleColor.DarkBlue;

        // Print sides with message
        for (int i = 0; i < height - 1; i++)
        {
            Console.WriteLine("\t\t│ "+ paddedMessage + " │");
        }

Console.ForegroundColor = color;

        Console.WriteLine("\t\t│" + new string(' ', boxWidth - 2) + "│");

        // Print bottom border
        Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
        Console.ResetColor();
    }


  


   
}