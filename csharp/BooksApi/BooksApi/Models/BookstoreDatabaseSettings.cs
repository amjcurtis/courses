using BooksApi.Models.Interfaces;

namespace BooksApi.Models
{
	/// <summary>
	/// This class stores appsettings.json file's BookstoreDatabaseSettings property values.
	/// The JSON and C# property names are identical to ease the mapping process.
	/// </summary>
	public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
	{
		public string BooksCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
