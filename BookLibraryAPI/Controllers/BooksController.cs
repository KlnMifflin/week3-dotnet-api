using Microsoft.AspNetCore.Mvc;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> books = new List<Book> { }; //hold books in library

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id); //find book with matching id

            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = books.Count == 0 ? 1 : books.Max(x => x.Id) + 1; //autoincrement id
            books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook(int id, Book newBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound();

            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Year = newBook.Year;
            book.Description = newBook.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound();

            books.Remove(book); //remove book from list
            return NoContent();
        }
    }
}
