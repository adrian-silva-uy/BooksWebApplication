﻿using BooksWebApplication.Domain.Entities;
using BooksWebApplication.Infrastructure.Interfaces;

namespace BooksWebApplication.Infrastructure.ServiceLayer

{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        // Avoid dependencies on IBookService in the constructor
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            await _bookRepository.AddBookAsync(book);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _bookRepository.UpdateBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }
    }
}
