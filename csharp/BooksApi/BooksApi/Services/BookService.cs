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
			MongoClient client = new MongoClient(settings.ConnectionString);
			IMongoDatabase db = client.GetDatabase(settings.DatabaseName);

			_books = db.GetCollection<Book>(settings.BooksCollectionName);
		}

		public List<Book> GetBooks() => _books.Find(book => true).ToList();

		public Book GetBookById(string id) => _books.Find(book => book.Id == id).FirstOrDefault();

		public Book CreateBook(Book book)
		{
			_books.InsertOne(book);
			return book;
		}

		public void UpdateBook(string id, Book bookIn) => _books.ReplaceOne(book => book.Id == id, bookIn);

		public void RemoveBook(Book bookIn) => _books.DeleteOne(book => book.Id == bookIn.Id);

		public void RemoveBookById(string id) => _books.DeleteOne(book => book.Id == id);
	}
}
