using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json; // Allows resolving of JsonProperty attribute reference

namespace BooksApi.Models
{
	public class Book
	{
		/// <summary>
		/// Required for mapping the CLR object to the MongoDB collection.
		/// </summary>
		[BsonId] // Designates this property as the document's primary key
		[BsonRepresentation(BsonType.ObjectId)] // Allows passing parameter as type string instead of ObjectId (Mongo handles conversion)
		public string Id { get; set; }

		[BsonElement("Name")] // Value of "Name" represents the property name in the MongoDB collection
		[JsonProperty("Name")] // Value of "Name" represents property name in the serialized JSON response
		public string BookName { get; set; }

		public decimal Price { get; set; }

		public string Category { get; set; }

		public string  Author { get; set; }
	}
}
