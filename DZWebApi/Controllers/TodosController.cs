using DZWebApi.Data;
using DZWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DZWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController:Controller
    {

        private ToDoDBContext dbContext;
        public TodosController(ToDoDBContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [HttpGet]

        public async Task<IActionResult> GetTodos()
        {
            return Ok(await dbContext.Todos.ToListAsync());
        }

        [HttpPost]  
        public async Task<IActionResult> AddTodo(AddTodoRequest addTodoRequest)
        {
            var todo = new Todo()
            {
                Id = new Guid(),
                Title = addTodoRequest.Title,
                Description = addTodoRequest.Description,
            };
            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTodo([FromRoute] Guid id)
        {
            var todo = await dbContext.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

    }
} 
