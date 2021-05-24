using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _context;

        public TodoController(ITodoRepository todoRpository)
        {
            _context = todoRpository;
        }
        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetTodoItem()
        {
            return await _context.Get();
        }
        [HttpGet("{id}")] //get pelo id
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            return await _context.Get(id);
        }
        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }
    }
}
