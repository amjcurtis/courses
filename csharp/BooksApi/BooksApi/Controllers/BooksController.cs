using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BooksApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly BookService _bookService;

		public BooksController(BookService bookService)
		{
			_bookService = bookService;
		}

		[HttpGet]
		public ActionResult<List<Book>> Get() => _bookService.GetBooks();

		[HttpGet("{id:length(24)}", Name = "GetBook")]
		public ActionResult<Book> GetById(string id)
		{
			var book = _bookService.GetBookById(id);

			if (book == null)
			{
				return NotFound();
			}

			return book;
		}

		[HttpPost]
		public ActionResult<Book> Create(Book book)
		{
			_bookService.CreateBook(book);

			// Returns HTTP 201 status code (standard response for a POST)
			// CreatedAtRoute also adds a Location header to response specifying URI of newly created resource
			return CreatedAtRoute("GetBook", new { id = book.Id.ToString() }, book); 
		}

		[HttpPut("{id:length(24)}")]
		public IActionResult Update(string id, Book bookIn)
		{
			var book = _bookService.GetBookById(id);

			if (book == null)
			{
				return NotFound();
			}

			_bookService.UpdateBook(id, bookIn);

			return NoContent();
		}

		[HttpDelete("{id:length(24)}")]
		public IActionResult Delete(string id)
		{
			var book = _bookService.GetBookById(id);

			if (book == null)
			{
				return NotFound();
			}

			_bookService.RemoveBookById(book.Id); // book.Id rather than id (as extra validation layer)

			return NoContent();
		}
	}
}
