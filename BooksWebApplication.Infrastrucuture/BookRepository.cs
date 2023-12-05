using BooksWebApplication.Domain.Interfaces;
using BooksWebApplication.Domain.Entities;
using System.Data.SqlClient;

namespace BooksWebApplication.Domain
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString = "Data Source=LENOVO_R3;Database=Ballast_Lane_Books;Integrated Security=sspi;"; //connection string to sql database
        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddBookAsync(Book book)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("INSERT INTO Books (Title, Author) VALUES (@Title, @Author)", connection);
                    command.Parameters.AddWithValue("Title", book.Title);
                    command.Parameters.AddWithValue("Author", book.Author);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to add Book Id: {book.Id} Message: {ex.Message}");
                throw;
            }

        }

        public async Task DeleteBookAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var command = new SqlCommand("DELETE FROM Books WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error trying to delete Book Id: {id} Message: {ex.Message}");
                throw;
            }

        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = new List<Book>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT * FROM Books", connection);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var book = new Book
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Author = reader.GetString(reader.GetOrdinal("Author"))
                            };
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving books: {ex.Message}");
                throw;
            }

            return books;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT * FROM Books WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Book
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Author = reader.GetString(reader.GetOrdinal("Author"))
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving book Id: {id} Message: {ex.Message}");
                throw;
            }

            return null;
        }

        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("UPDATE Books SET Title = @Title WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", book.Id);
                    command.Parameters.AddWithValue("@Title", book.Title);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book Id: {book.Id} Message: {ex.Message}");
                throw;
            }

        }
    }
}
