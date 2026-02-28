using System.Linq;

namespace MyLibrary.DbModel.Entities;

public partial class Book
{
    public string AllBookAuthorsFirstNameLastName =>
        string.Join(" - ", Bookauthors
            .Where(ba => ba.Author != null)
            .Select(ba => $"{ba.Author.First_Name} {ba.Author.Last_Name}"));

    public string AllBookAuthorsLastNameFirstName =>
        string.Join(" - ", Bookauthors
            .Where(ba => ba.Author != null)
            .Select(ba => $"{ba.Author.Last_Name} {ba.Author.First_Name}"));

    public string AllBookThemeNames =>
        string.Join(" - ", Bookthemes
            .Where(bt => bt.Theme != null)
            .Select(bt => bt.Theme.Name));
}
