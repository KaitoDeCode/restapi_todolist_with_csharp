using api_with_csharp.Contexts;
using api_with_csharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Linq;

namespace api_with_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoContext ctx;
        public TodoController(
            TodoContext ctx
        ) {
            this.ctx = ctx;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Get()
        {
            return await ctx.TodoModels.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> Show(int id)
        {
            return await ctx.TodoModels.FirstOrDefaultAsync(item => item.id == id);
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> store(TodoModel model)
        {
            ctx.TodoModels.Add(model);
            await ctx.SaveChangesAsync();
            return CreatedAtAction(null,new {id = model.id},model);
        }

    }
}
