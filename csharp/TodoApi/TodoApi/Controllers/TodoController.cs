using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
	[Route("api/[controller]")]
	public class TodoController : Controller
	{
		private readonly TodoListContext _context;

		public TodoController(TodoListContext context)
		{
			_context = context;

			if (_context.TodoItems.Count() == 0)
			{
				_context.TodoItems.Add(new TodoItem { Name = "Item1" });
				_context.SaveChanges();
			}
		}
	}
}
