using MyLibrary.DbModel.Entities;
using MyLibrary.JsonRepositoryModel.Context;
using MyLibrary.JsonRepositoryModel.Repositories.Interfaces;

namespace MyLibrary.JsonRepositoryModel.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(JsonDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
    {
        var bookIds = _context.Bookauthors
            .Where(ba => ba.AuthorId == authorId)
            .Select(ba => ba.BookId)
            .ToList();

        return _context.Books
            .Where(b => bookIds.Contains(b.Id))
            .ToList();
    }

    public async Task<IEnumerable<Book>> GetBooksByThemeAsync(int themeId)
    {
        var bookIds = _context.Bookthemes
            .Where(bt => bt.ThemeId == themeId)
            .Select(bt => bt.BookId)
            .ToList();

        return _context.Books
            .Where(b => bookIds.Contains(b.Id))
            .ToList();
    }

    public async Task<IEnumerable<Book>> FindBooksAsync(string title, string description, string publisher)
    {
        return _context.Books
            .Where(b => (string.IsNullOrEmpty(title) || (b.Title != null && b.Title.Contains(title))) &&
                        (string.IsNullOrEmpty(description) || (b.Description != null && b.Description.Contains(description))) &&
                        (string.IsNullOrEmpty(publisher) || (b.Publisher != null && b.Publisher.Contains(publisher))))
            .ToList();
    }

    public async Task<Book?> GetBookByIsbnAsync(string isbn)
    {
        return _context.Books
            .FirstOrDefault(b => b.Isbn == isbn);
    }
}
