using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleRegister.Data;
using TeleRegister.Models;

namespace TeleRegister.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public readonly DBContext db;
        public RegisterController(DBContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("GetRegister")]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.Register.OrderByDescending(x => x.Id).ToListAsync());
        }
        [HttpGet]
        [Route("GetRegisterByID/{Id}")]
        public async Task<IActionResult> GetRegisterById(int Id)
        {
            return Ok(await db.Register.FindAsync(Id));
        }
        [HttpPost]
        [Route("AddRegister")]
        public async Task<IActionResult> Post(Register register)
        {
            register.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            var result = await db.Register.AddAsync(register);
            await db.SaveChangesAsync();
            if (result.Entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok();
        }
        [HttpPut]
        [Route("UpdateRegister")]
        public async Task<IActionResult> Put(Register register)
        {
            db.Entry(register).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteRegister")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Register = db.Register.Find(Id);
            db.Entry(Register).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
