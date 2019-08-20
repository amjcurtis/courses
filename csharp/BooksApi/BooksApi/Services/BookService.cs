using BooksApi.Models;
using BooksApi.Models.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Services
{
	public class BookService
	{
		private readonly IMongoCollection<Book> _books;

		public BookService(IBookstoreDatabaseSettings settings)
		{
			// Reads server instance for performing database operations
			MongoClient client = new MongoClient(settings.ConnectionString);

			IMongoDatabase db = client.GetDatabase(settings.DatabaseName);

			_books = db.GetCollection<Book>(settings.BooksCollectionName);
		}

		// Gets all books existing in the database collection
		public List<Book> GetBooks() => _books.Find(book => true).ToList();

		// Gets a single book by ID
		public Book GetBookById(string id) => _books.Find(book => book.Id == id).FirstOrDefault();

		// Adds a book to the database collection
		public Book CreateBook(Book book)
		{
			_books.InsertOne(book);
			return book;
		}

		// Replaces specified book in the database with the provided Book object
		public void UpdateBook(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

		// Deletes the selected book object from database
		public void RemoveBook(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);

		// Deletes a book specified by ID from database
		public void RemoveBookById(string id) => _books.DeleteOne(book => book.Id == id);
	}
}
