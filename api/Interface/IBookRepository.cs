using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Helper;
using api.Model;

namespace api.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBookAsync(QueryObject query);
        Task<Book> GetBookById(int id);
        // Task<List<Book>> GetBookByTitle(string title);
        // Task<List<Book>> GetBookByAuthor(string author);
        // Task<List<Book>> GetBookByPublisher(string publisher);
        Task<Book> Post(Book book);
        Task<Book> Delete(Book book);
        Task<Book> Put(int id, UpdateBookDto updateBookDto);


    }
}