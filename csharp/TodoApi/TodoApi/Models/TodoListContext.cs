using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
	public class TodoListContext : DbContext
	{
		// Constructor
		public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
		{
		}

		public DbSet<TodoItem> TodoItems { get; set; }
	}
}
