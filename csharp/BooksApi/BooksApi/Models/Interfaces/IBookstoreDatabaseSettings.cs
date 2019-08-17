namespace BooksApi.Models.Interfaces
{
	public class IBookstoreDatabaseSettings
	{
		//TODO May need to add public access modifier to props below

		string BooksCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
