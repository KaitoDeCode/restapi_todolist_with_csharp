using api_with_csharp.Contexts;
using api_with_csharp.Models;
using api_with_csharp.Payloads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;

namespace api_with_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserContext ctx;
        public AuthController (
            UserContext ctx
        )
        {
            this.ctx = ctx;
        }

        [HttpPost("login",Name = "login")]
          public async Task<IActionResult> Login(LoginPayload payload)
          {
                var user = await ctx.User.FirstOrDefaultAsync(item => item.email == payload.email && item.password == payload.password);
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok(user);
          }

        [HttpPost("register",Name = "register")]
        public async Task<IActionResult> register(UserModel model)
        {
            ctx.User.Add(model);
            await ctx.SaveChangesAsync();
            return CreatedAtAction("Register", new { id = model.id}, model);
        }

  }

}
