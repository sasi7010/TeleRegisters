using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleRegister.Data;
using TeleRegister.Models;

namespace TeleRegister.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly DBContext db;
        public LoginController(DBContext _db)
        {
            this.db = _db;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Post([FromBody] Login login)
        {
            var Login=await db.Register.Where(x=>x.PhoneNumber == login.PhoneNumber && x.Password == login.Password).FirstOrDefaultAsync();
            if(Login == null)
            {
                return Ok(false);
            }
            return Ok(true);
        }
    }
}
