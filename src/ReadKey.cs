namespace ReadKeySpace;
public class ReadKey
{
   public static string PressKey(string[] List)
    {
        string[] options = List;
        int selectedIndex = 0;

        ShowOptions(options, selectedIndex);

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex == 0) ? options.Length - 1 : selectedIndex - 1;
                    ShowOptions(options, selectedIndex);
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex == options.Length - 1) ? 0 : selectedIndex + 1;
                    ShowOptions(options, selectedIndex);
                    break;
                case ConsoleKey.Enter:
                    if (selectedIndex == options.Length - 1)
                    {
                        Console.WriteLine("\nExiting...");
                         break;
                    }
                    else
                    {
                        //Console.WriteLine($"\nSelected ... {options[selectedIndex]}");
                    }
                    break;
            }
        } while (keyInfo.Key != ConsoleKey.Enter);
         return $"{options[selectedIndex]}";   
    }

    static void ShowOptions(string[] options, int selectedIndex)
    {
        Console.Clear();
        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.WriteLine($"\t\t\x1b[1m\x1b[94m> {options[i]}\x1b[0m");
            }
            else
            {
                Console.WriteLine($"\t\t\x1b[1m\x1b[98m{options[i]}\x1b[0m");
            }
        }
    }

    public static void Test(){
        
        int x = 0;
        int y = 0;

        while (true)
        {
            // Display the current position
            Console.Clear(); // Clear the console before redrawing
            Console.SetCursorPosition(x, y);
            Console.Write("X");
          Console.WriteLine("Use arrow keys to move. Press 'Q' to quit.");


            // Read and process keyboard input
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (y > 0) y--;
                    break;
                case ConsoleKey.DownArrow:
                    if (y < Console.WindowHeight - 1) y++;
                    break;
                case ConsoleKey.LeftArrow:
                    if (x > 0) x--;
                    break;
                case ConsoleKey.RightArrow:
                    if (x < Console.WindowWidth - 1) x++;
                    break;
                case ConsoleKey.Q:
                    return; // Exit the program if 'Q' is pressed
            }
        }
    }
}