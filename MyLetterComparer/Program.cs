using MyLetterComparer;

if (args.Length < 2)
{
    Console.WriteLine("Usage: dotnet run <letter1> <letter2>");
    Console.WriteLine("Example: dotnet run a b");
    return;
}

char char1 = args[0][0];
char char2 = args[1][0];

// Validate that both are letters or both are numbers
bool isChar1Letter = char.IsLetter(char1);
bool isChar2Letter = char.IsLetter(char2);
bool isChar1Digit = char.IsDigit(char1);
bool isChar2Digit = char.IsDigit(char2);

if ((isChar1Letter && isChar2Digit) || (isChar1Digit && isChar2Letter))
{
    Console.WriteLine("Error: Cannot compare a letter with a number!");
    Console.WriteLine($"'{char1}' is a {(isChar1Letter ? "letter" : "number")}");
    Console.WriteLine($"'{char2}' is a {(isChar2Letter ? "letter" : "number")}");
    return;
}

if (!isChar1Letter && !isChar1Digit)
{
    Console.WriteLine($"Error: '{char1}' is neither a letter nor a digit!");
    return;
}

if (!isChar2Letter && !isChar2Digit)
{
    Console.WriteLine($"Error: '{char2}' is neither a letter nor a digit!");
    return;
}

var comparer = new LetterComparer();
int result = comparer.CompareLetter(char1, char2);

string typeLabel = isChar1Letter ? "Letters" : "Numbers";
Console.WriteLine($"=== {typeLabel} Comparer ===");
Console.WriteLine();
Console.WriteLine($"Comparing '{char1}' and '{char2}':");
Console.WriteLine();

if (result == 0)
    Console.WriteLine($"Result: {result} - The values are the same");
else if (result == -1)
    Console.WriteLine($"Result: {result} - '{char1}' comes before '{char2}'");
else
    Console.WriteLine($"Result: {result} - '{char1}' comes after '{char2}'");
