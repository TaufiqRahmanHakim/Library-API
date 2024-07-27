using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Helper;
using api.Interface;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AplicationDBContext _context;

        public BookRepository(AplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Book> Delete(Book book)
        {
            _context.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllBookAsync(QueryObject query)
        {
            var book = _context.books.AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.title)){
                book = book.Where(s=> s.title.Contains(query.title));
            }
            if(!string.IsNullOrWhiteSpace(query.author)){
                book = book.Where(s=> s.author.Contains(query.author));
            }
            if(!string.IsNullOrWhiteSpace(query.publisher)){
                book = book.Where(s=> s.publisher.Contains(query.publisher));
            }
            if(!string.IsNullOrWhiteSpace(query.language)){
                book = book.Where(s=> s.language.Contains(query.language));
            }
            var skipNumber = (query.pageNumber - 1)*query.pageSize; 

            return await book.Skip(skipNumber).Take(query.pageSize).ToListAsync();
        }

        // public async Task<List<Book>> GetBookByAuthor(string author)
        // {
        //     return await _context.books.Where(s => s.author.Contains(author)).ToListAsync();
        // }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.books.FindAsync(id);
        }

        // public async Task<List<Book>> GetBookByPublisher(string publisher)
        // {
        //     return await _context.books.Where(s => s.publisher.Contains(publisher)).ToListAsync();
        // }

        // public async Task<List<Book>> GetBookByTitle(string title)
        // {
        //     return await _context.books.Where(s => s.title.Contains(title)).ToListAsync();
        // }

        public async Task<Book> Post(Book book)
        {
            await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Put(int id, UpdateBookDto updateBookDto)
        {
            var book = await _context.books.FirstOrDefaultAsync(x => x.id == id);

            if(book == null){
                return null;
            }
            book.title = updateBookDto.title;
            book.author = updateBookDto.author;
            book.publisher = updateBookDto.publisher;
            book.publishedDate = updateBookDto.publishedDate;
            book.language = updateBookDto.language;

            await _context.SaveChangesAsync();
            return book;
        }
    }
}