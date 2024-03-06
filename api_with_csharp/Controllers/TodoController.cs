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
using System.ComponentModel;
using System.Text;

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

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoModel>> Update(int id,TodoModel model)
        {
            TodoModel data = ctx.TodoModels.FirstOrDefault(item => item.id == id);
            data.title = model.title;
            data.isCompleted = model.isCompleted;
            await ctx.SaveChangesAsync();
            return data;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await ctx.TodoModels.FirstOrDefaultAsync(item => item.id == id);
                if (data is null)
                {
                    return NotFound();
                }

                ctx.TodoModels.Remove(data);
                await ctx.SaveChangesAsync();

                return Ok("Berhasil menghapus data");
            }
            catch (Exception err)
            {
                // Log kesalahan jika diperlukan
                return StatusCode(500, "Terjadi kesalahan dalam menghapus data");
            }
        }

    }
}
