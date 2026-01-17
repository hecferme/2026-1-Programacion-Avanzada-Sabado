namespace MyLetterComparer;

public class LetterComparer
{
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
