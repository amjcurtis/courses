using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
	[Route("api/todo")] // Routing to controller actions (e.g. 'todo' here) is case-insensitive in ASP.NET Core
	[ApiController]
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

		// GET endpoint: api/Todo
		[HttpGet]
		public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
		{
			return await _context.TodoItems.ToListAsync();
		}

		// GET endpoint: api/Todo/5
		[HttpGet("{id}")]
		public async Task<ActionResult<TodoItem>> GetTodoItemById(long id)
		{
			TodoItem todoItem = await _context.TodoItems.FindAsync(id);

			if (todoItem == null)
			{
				return NotFound(); // Returns 404 response
			}

			return todoItem;
		}

		// POST endpoint: api/Todo
		[HttpPost]
		public async Task<ActionResult<TodoItem>> AddTodoItem(TodoItem item)
		{
			_context.TodoItems.Add(item);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetTodoItemById), new { id = item.Id }, item);
		}

		// PUT endpoint: api/Todo/5
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateTodoItem(long id, TodoItem item)
		{
			if (id != item.Id)
			{
				return BadRequest();
			}

			_context.Entry(item).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
