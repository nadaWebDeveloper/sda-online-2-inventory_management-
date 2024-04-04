
namespace BorderMainSpace;
class BorderMain
{
    public static string MainBorder(string list)
    {
        string message = list;
        int boxWidth = Math.Max(message.Length + 6, 150);

        // Print sides with message
        int padding = (boxWidth - message.Length -4) / 2;
        string paddedMessage = new string(' ', padding + 5)+  message + new string(' ', padding + (message.Length % 2 == 0 ? 0 : 1));
        return $"\t\t" + paddedMessage + "";
    }
}