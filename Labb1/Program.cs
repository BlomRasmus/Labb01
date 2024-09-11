

using System;

static string GetSubString(string userInput, int searchFrom)
{
    string userSubstring = null;

    for (int i = searchFrom; i < userInput.Length; i++)
    {
        if (userInput[i] == userInput[searchFrom] && searchFrom != i)
        {
            int substringFrom;
            int substringTo;

            substringFrom = searchFrom;
            substringTo = i - searchFrom + 1;
            userSubstring = userInput.Substring(substringFrom, substringTo);
            break;

        }
        else if (searchFrom == i)
        {
            continue;
        }
    }

    return userSubstring;
}

static bool SearchForLetter(string substring)
{
    bool test = true;

    foreach (char c in substring)
    {
        if (Char.IsLetter(c))
        {
            test = false;
            break;
        }
        else
        {
            test = true;
        }
    }
    return test;
}

static void PrintChars(string userInput, int substringBeginning, int substringEnd)
{
    for (int i = 0; i < substringBeginning; i++)
    {
        Console.Write(userInput[i]);
    }
    for (int i = substringBeginning; i <= substringEnd; i++)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(userInput[i]);
    }
    for (int i = substringEnd + 1; i < userInput.Length; i++)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(userInput[i]);
    }
}


Console.Write("Skriv in en string: ");
string userInput = Console.ReadLine();

long sum = 0;
int searchFrom = 0;

while (searchFrom < userInput.Length)
{
    string substring = null;
    substring = GetSubString(userInput, searchFrom);

    bool keepGoing = true;
    if (substring != null)
    {
        keepGoing = SearchForLetter(substring);
    }

    long addBy = 0;
    keepGoing = long.TryParse(substring, out addBy);   
    sum += addBy;

    if (keepGoing == true)
    {
        int index = searchFrom + substring.Length - 1;
        PrintChars(userInput, searchFrom, index);
    }
    else
    {
        searchFrom++;
        continue;
    }

    searchFrom++;
    Console.WriteLine();
}

Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine();
Console.WriteLine(sum);