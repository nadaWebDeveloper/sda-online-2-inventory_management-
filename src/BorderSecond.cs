
namespace BorderSecondSpace;
class BorderSecond
{
    public void SecondBorder(string message, ConsoleColor colorBorder, ConsoleColor colorMessage)
    {
        string text = message;
        int boxWidth = Math.Max(text.Length + 6, 150);

        Console.ForegroundColor = colorBorder;
        Console.WriteLine("\t\t┌" + new string('─', boxWidth - 2) + "┐");


        Console.ForegroundColor = colorMessage;
        int padding = (boxWidth - text.Length - 4) / 2;
        string paddedMessage = new string(' ', padding) + text + new string(' ', padding + (text.Length % 2 == 0 ? 0 : 1));

        // Print message line
        Console.WriteLine("\t\t│ " + paddedMessage + " │");

        Console.ForegroundColor = colorBorder;
        // Print bottom border with rounded corners
        Console.WriteLine("\t\t└" + new string('─', boxWidth - 2) + "┘");
        Console.ResetColor();
    }
}