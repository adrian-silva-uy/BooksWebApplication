using BooksWebApplication.Domain.Entities;

namespace BooksWebApplication.Infrastructure.Interfaces
{
    //Interface for Book Repository
    public interface IBookRepository
    {
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}
