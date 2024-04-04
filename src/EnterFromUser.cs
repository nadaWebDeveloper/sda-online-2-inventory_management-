using BorderSecondSpace;
using System.Text.RegularExpressions;
using ItemSpace;
using StoreSpace;
namespace EnterFromUserSpace;

class EnterFromUser
{
    static Store? store;
    static List<Item>? resultSearch;
    static int boxWidth = 150;
    static void AddNewItemToStore()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        string text = "Adding New Item:";
        BorderSecond.SecondBorder(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);
        Console.ResetColor();

        string nameItem = GetNewNameFromUser();
        int quantity = GetNewQuantityFromUser();
        DateTime dateCreated = GetNewDateCreatedFromUser();
        var newItem = new Item(nameItem, quantity, dateCreated);
        store?.AddItem(newItem);
    }

    static string GetNewNameFromUser()
    {
        string? input, inputCharacters, result;
        int text;
        do
        {
            BorderSecond.BorderWithCursor("Enter Name Item:", 70);
            input = Console.ReadLine();
            result = Regex.Replace(input ?? " ", @"[^a-zA-Z0-9\s]", " ");


            string? loweInput = input?.ToLower();
            char[] charsToTrim = { 'a', 'b', 'c', 'd', 'e', 'f', 'j', 'h', 'i', 'g', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'v', 't', 'u', 'y', 'x', 'z', ' ' };
            inputCharacters = loweInput?.Trim(charsToTrim);
            Console.WriteLine();
            if (inputCharacters?.Length != 0)
            {
                BorderSecond.SecondBorder($"✘ Item Name with out non-alphanumeric", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (string.IsNullOrEmpty(result))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is Required", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (int.TryParse(result, out text))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is Only String", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (result?.Length < 3)
            {
                BorderSecond.SecondBorder($"✘ Item Length Name Is More 3 characters", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
        } while (string.IsNullOrEmpty(result) || int.TryParse(result, out text) || result.Length < 3 || inputCharacters?.Length != 0);
        return result;
    }
    static int GetNewQuantityFromUser()
    {
        int quantity;
        string? input;
        do
        {
            BorderSecond.BorderWithCursor("Enter Quantity Item:", 68);
            input = Console.ReadLine();
            Console.WriteLine();
            if (!int.TryParse(input, out quantity))
            {
                BorderSecond.SecondBorder($"✘ Item Quantity Number Is Required", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            else if (quantity < 0)
            {
                BorderSecond.SecondBorder($"✘ Item Quantity Is Positive Number", ConsoleColor.DarkRed, ConsoleColor.Red);
            }

        } while (!int.TryParse(input, out quantity) || quantity < 0);
        return quantity;
    }
    static DateTime GetNewDateCreatedFromUser()
    {
        DateTime createdDate;
        string? input;

        do
        {
            BorderSecond.BorderWithCursor("\x1b[92mTip:\x1b[97m Format Date (MM/DD/YYYY) Or Press Enter To Created,\x1b[1m\x1b[90m Enter Created Date Of Item:", 8);
            input = Console.ReadLine();
            Console.WriteLine();
            if (string.IsNullOrEmpty(input))
            {
                createdDate = DateTime.Now;
                return createdDate;
            }
            else if (!DateTime.TryParse(input, out createdDate))
            {
                BorderSecond.SecondBorder($"✘ Format Date Is Invalid, Format Date (MM/DD/YYYY)", ConsoleColor.DarkRed, ConsoleColor.Red);
            }

        } while (!DateTime.TryParse(input, out createdDate) || string.IsNullOrEmpty(input));

        return createdDate;
    }

    //AddNewItemToStore();

    static void DeleteItemFromStore()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        string text = "Deleting Item:";
        BorderSecond.SecondBorder(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);
        Console.ResetColor();

        string nameItem = GetNameToDeletedFromUser();
        store?.DeleteItem(nameItem);
    }
    static string GetNameToDeletedFromUser()
    {
        string? input, inputCharacters, result;
        int text;

        do
        {
            BorderSecond.BorderWithCursor("Enter Name Item To Deleted:", 65);
            input = Console.ReadLine();
            result = Regex.Replace(input ?? " ", @"[^a-zA-Z0-9\s]", " ");


            string? loweInput = input?.ToLower();
            char[] charsToTrim = { 'a', 'b', 'c', 'd', 'e', 'f', 'j', 'h', 'i', 'g', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'v', 't', 'u', 'y', 'x', 'z', ' ' };
            inputCharacters = loweInput?.Trim(charsToTrim);

            Console.WriteLine();
            if (inputCharacters?.Length != 0)
            {
                BorderSecond.SecondBorder($"✘ Item Name with out non-alphanumeric", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (string.IsNullOrEmpty(result))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is Required", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (int.TryParse(result, out text))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is String", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (result?.Length < 3)
            {
                BorderSecond.SecondBorder($"✘ Item Length Name Is More 3 characters", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
        } while (string.IsNullOrEmpty(result) || int.TryParse(result, out text) || result.Length < 3 || inputCharacters?.Length != 0);
        return result;
    }
    //DeleteItemFromStore();


   

     static void FormatResultSearch()
    {
        try
        {
            if (resultSearch != null && resultSearch.Any())
            {
                Console.WriteLine($"\t\t\x1b[1m\x1b[91m𐧿  \x1b[97mResult Of Search:");
                Console.WriteLine("\t\t\x1b[1m╭" + new string('─', boxWidth - 2) + "╮");
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                foreach (var item in resultSearch)
                {
                    Console.WriteLine($"{item}");
                }
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
            }
            else
            {
                throw new Exception($"\x1b[3;97mThere Are No Results For Search");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"\t\t\x1b[1;91m⚠︎  {error.Message}");
        }
    }

    public static void SearchItemFromStore()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        string text = "🔎 Searching Item:";
        BorderSecond.SecondBorder(text, ConsoleColor.Blue, ConsoleColor.DarkBlue);
        Console.ResetColor();

        string nameItem = GetNameToSearchesFromUser();
        resultSearch = store?.FindItemsByName(nameItem);
        Console.WriteLine($"{resultSearch}");
        

          try
        {
            if (resultSearch != null && resultSearch.Any())
            {
                Console.WriteLine($"\t\t\x1b[1m\x1b[91m𐧿  \x1b[97mResult Of Search:");
                Console.WriteLine("\t\t\x1b[1m╭" + new string('─', boxWidth - 2) + "╮");
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                foreach (var item in resultSearch)
                {
                    Console.WriteLine($"{item}");
                }
                Console.WriteLine("\t\t\x1b[1m│" + new string(' ', boxWidth - 2) + "│");
                Console.WriteLine("\t\t╰" + new string('─', boxWidth - 2) + "╯");
            }
            else
            {
                throw new Exception($"\x1b[3;97mThere Are No Results For Search");
            }
        }
        catch (Exception error)
        {
            Console.WriteLine($"\t\t\x1b[1;91m⚠︎  {error.Message}");
        }
    }

     static string GetNameToSearchesFromUser()
    {
        string? input, inputCharacters, result;
        int text;

        do
        {
            BorderSecond.BorderWithCursor("Enter Name Item To Search: 🔎", 65);
            input = Console.ReadLine();
            result = Regex.Replace(input ?? " ", @"[^a-zA-Z0-9\s]", " ");


            string? loweInput = input?.ToLower();
            char[] charsToTrim = { 'a', 'b', 'c', 'd', 'e', 'f', 'j', 'h', 'i', 'g', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 'v', 't', 'u', 'y', 'x', 'z', ' ' };
            inputCharacters = loweInput?.Trim(charsToTrim);

            Console.WriteLine();
            if (inputCharacters?.Length != 0)
            {
                BorderSecond.SecondBorder($"✘ Item Name with out non-alphanumeric", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (string.IsNullOrEmpty(result))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is Required", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (int.TryParse(result, out text))
            {
                BorderSecond.SecondBorder($"✘ Item Name Is String", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            if (result?.Length < 3)
            {
                BorderSecond.SecondBorder($"✘ Item Length Name Is More 3 characters", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
        } while (string.IsNullOrEmpty(result) || int.TryParse(result, out text) || result.Length < 3 || inputCharacters?.Length != 0);
        return result;
    }
   
    // SearchItemFromStore();

    public static void CapacityFromUser(){
    store = new Store(GetCapacity());
      static int GetCapacity()
      {
         int number;
         string input;
         do
         {
            BorderSecond.BorderWithCursor("Enter Limit To Capacity Of Store:", 62);
            input = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (!int.TryParse(input, out number))
            {
               BorderSecond.SecondBorder($"✘ Invalid Input , Enter a Valid Number", ConsoleColor.DarkRed, ConsoleColor.Red);
            }
            else if (number <= 0)
            {
               BorderSecond.SecondBorder($"✘ Invalid Input , Enter Positive Number", ConsoleColor.DarkRed, ConsoleColor.Red);
            }

         } while (!int.TryParse(input, out number) || number <= 0);
         Console.WriteLine();
         return number;
      }
    }
}