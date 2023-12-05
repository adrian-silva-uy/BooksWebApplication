using BooksWebApplication.Domain.Entities;
using BooksWebApplication.Domain.Interfaces;
using BooksWebApplication.Domain.ServiceLayer;
using Moq;

namespace Testing.ServiceTests
{
    [TestClass]
    public class BookServiceTests
    {
        //[TestMethod]
        //public async Task GetAllBooks_ShouldReturnAllBooks()
        //{
        //    //Arrange
        //    var mockBookRepository = new Mock<IBookRepository>();
        //    mockBookRepository.Setup(service => service.GetAllBooksAsync()).ReturnsAsync(GetMockBooks());
        //    var bookService = new BookService(mockBookRepository.Object);

        //    //Act
        //    var books = await bookService.GetAllBooksAsync();

        //    //Assert
        //    Assert.AreEqual(2, books.Count());
        //}

        [TestMethod]
        public async Task AddBook_ShouldAddNewBook()
        {
            //Arrange
            var mockBookService = new Mock<IBookService>();
            var bookService = new BookService(mockBookService.Object);
            var newBook = new Book { Id = 3, Title = "Title 3", Author = "Author 3" };

            //Act
            await bookService.AddBookAsync(newBook);

            //Assert
            mockBookService.Verify(repo => repo.AddBookAsync(newBook), Times.Once());
        }

        public IEnumerable<Book> GetMockBooks()
        {
            return new List<Book>()
            {
                new Book() { Id = 1, Title = "Design Patterns", Author = "Erich Gamma"},
                new Book() { Id = 2, Title = "Clean Code", Author = "Robert C Martins"}
            };
        }
    }
}