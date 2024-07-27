using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Model;

namespace api.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book book){
            return new BookDto{
                id = book.id,
                title = book.title,
                author = book.author,
                publisher = book.publisher,
                publishedDate = book.publishedDate,
                language = book.language
            };
        }
        public static Book ToPostDto(this PostBookDto postBookDto){
            return new Book{
                title = postBookDto.title,
                author = postBookDto.author,
                publisher = postBookDto.publisher,
                publishedDate = postBookDto.publishedDate,
                language = postBookDto.language
            };
        }
    }
}