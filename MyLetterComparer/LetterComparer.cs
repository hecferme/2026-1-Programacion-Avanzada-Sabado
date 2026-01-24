namespace MyLetterComparer;

public class LetterComparer
{
    /// <summary>
    /// Validates that both characters are either letters or digits,
    /// and that they are the same type (both letters or both digits).
    /// </summary>
    /// <param name="char1">The first character</param>
    /// <param name="char2">The second character</param>
    /// <exception cref="ArgumentException">Thrown when validation fails</exception>
    public void ArgumentValidation(char char1, char char2)
    {
        bool isChar1Letter = char.IsLetter(char1);
        bool isChar2Letter = char.IsLetter(char2);
        bool isChar1Digit = char.IsDigit(char1);
        bool isChar2Digit = char.IsDigit(char2);

        if ((isChar1Letter && isChar2Digit) || (isChar1Digit && isChar2Letter))
        {
            throw new ArgumentException(
                $"Error: Cannot compare a letter with a number! '{char1}' is a {(isChar1Letter ? "letter" : "number")}, " +
                $"'{char2}' is a {(isChar2Letter ? "letter" : "number")}");
        }

        if (!isChar1Letter && !isChar1Digit)
        {
            throw new ArgumentException($"Error: '{char1}' is neither a letter nor a digit!");
        }

        if (!isChar2Letter && !isChar2Digit)
        {
            throw new ArgumentException($"Error: '{char2}' is neither a letter nor a digit!");
        }
    }

    /// <summary>
    /// Compares two letters alphabetically.
    /// </summary>
    /// <param name="letter1">The first letter</param>
    /// <param name="letter2">The second letter</param>
    /// <returns>
    /// 0 if the letters are the same
    /// -1 if the first letter is alphabetically before the second
    /// 1 if the first letter is alphabetically after the second
    /// </returns>
    public int CompareLetter(char letter1, char letter2)
    {
        ArgumentValidation(letter1, letter2);

        // Convert to lowercase for case-insensitive comparison
        char l1 = char.ToLower(letter1);
        char l2 = char.ToLower(letter2);

        if (l1 == l2)
            return 0;
        else if (l1 < l2)
            return -1;
        else
            return 1;
    }
}
