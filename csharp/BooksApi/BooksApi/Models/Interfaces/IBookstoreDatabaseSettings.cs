namespace BooksApi.Models.Interfaces
{
	public class IBookstoreDatabaseSettings
	{
		public string BooksCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}
}
