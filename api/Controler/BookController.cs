using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Mappers;
using api.Data;
using api.Interface;
using Microsoft.AspNetCore.Mvc;
using api.Model;
using api.Helper;
using Microsoft.AspNetCore.Authorization;

namespace api.Controler
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly AplicationDBContext _context;
        private readonly IBookRepository _BookRepo;

        public BookController(AplicationDBContext context, IBookRepository bookRepository){
            _context = context;
            _BookRepo = bookRepository;
        }


        [HttpGet("get all books"), Authorize]
        public async Task<IActionResult> GetALL([FromQuery] QueryObject query){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var book = await _BookRepo.GetAllBookAsync(query);
            var bookDtos = book.Select(s => s.ToBookDto());
            return Ok(bookDtos);
        }
        [HttpGet("search id/{id:int}"), Authorize]
        public async Task<IActionResult> GetById([FromRoute]int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var book = await _BookRepo.GetBookById(id);

            if(book == null){
                NotFound();
            }
            return Ok(book.ToBookDto());
        }
        
        // [HttpGet("search title")]
        // public async Task<IActionResult> GetFromTitle([FromQuery] string title){
        //     if(!ModelState.IsValid){
        //         return BadRequest(ModelState);
        //     }
        //     var books = await _BookRepo.GetBookByTitle(title);

        //     if(books == null){
        //         NotFound();
        //     }
        //     var bookDtos = books.Select(s=>s.ToBookDto());
        //     return Ok(bookDtos);
        // }
        // [HttpGet("search author")]
        // public async Task<IActionResult> GetFromAuthor([FromQuery] string author){
        //     if(!ModelState.IsValid){
        //         return BadRequest(ModelState);
        //     }
        //     var books = await _BookRepo.GetBookByAuthor(author);

        //     if(books == null){
        //         NotFound();
        //     }
        //     var bookDtos = books.Select(s=>s.ToBookDto());
        //     return Ok(bookDtos);
        // }
        // [HttpGet("search publisher")]
        // public async Task<IActionResult> GetFromPublisher([FromQuery] string publisher){
        //     if(!ModelState.IsValid){
        //         return BadRequest(ModelState);
        //     }
        //     var books = await _BookRepo.GetBookByPublisher(publisher);

        //     if(books == null){
        //         NotFound();
        //     }
        //     var bookDtos = books.Select(s=>s.ToBookDto());
        //     return Ok(bookDtos);
        // }
        [HttpPost("insert book"), Authorize]
        public async Task<IActionResult> Post([FromBody] PostBookDto postBookDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (_context.books.Any(s => s.title == postBookDto.title))
            {
                return BadRequest("Symbol or name already exists.");
            }
            var bookModel = postBookDto.ToPostDto();
            await _BookRepo.Post(bookModel);
            return CreatedAtAction(nameof(GetById), new {id = bookModel.id }, bookModel.ToBookDto());

        }
        [HttpDelete("delete by id/{id:int}"), Authorize]
        public async Task<IActionResult> Delete([FromRoute]int id){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var books = await _BookRepo.GetBookById(id);
            if(books == null){
                return null;
            }
            await _BookRepo.Delete(books);
            return Ok(books);
        }
        [HttpPut("update book/{id:int}"), Authorize]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateBookDto updateBookDto ){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var book = await _BookRepo.Put(id, updateBookDto);
            if(book == null){
                return new NotFoundResult();
            }
            return Ok(book.ToBookDto());
        }
    }
}