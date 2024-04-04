public class ReadFile
{
    public void ReadFiles(string pathFile)
    {
        string filePath = pathFile;
        try
        {
            // Open the file for reading using StreamReader
            using (StreamReader reader = new StreamReader(filePath))
            {
                string? text;
                while ((text = reader.ReadLine()) != null)
                {
                    int boxWidth = Math.Max(text.Length + 6, 152);
                    int padding = (boxWidth - text.Length - 4) / 2;
                    string paddedMessage = new string(' ', padding) + text + new string(' ', padding + (text.Length % 2 == 0 ? 0 : 1));
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"\t\t{paddedMessage}");
                    Console.ResetColor();
                }
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"An error occurred while reading the file: {error.Message}");
        }
    }
}