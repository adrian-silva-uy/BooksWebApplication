using BooksWebApplication.Domain.Entities;

namespace BooksWebApplication.Domain.Interfaces
{
    public interface IBookService
    {

        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
    }
}