using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleRegister.Data;
using TeleRegister.Models;

namespace TeleRegister.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public readonly DBContext db;
        public DoctorController(DBContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("GetDoctor")]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.Doctor.OrderByDescending(x => x.Id).ToListAsync());
        }
        [HttpGet]
        [Route("GetDoctorByID/{Id}")]
        public async Task<IActionResult> GetDoctorById(int Id)
        {
            return Ok(await db.Doctor.FindAsync(Id));
        }
        [HttpPost]
        [Route("AddDoctor")]
        public async Task<IActionResult> Post(Doctor doctor)
        {
            doctor.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            var result = await db.Doctor.AddAsync(doctor);
            await db.SaveChangesAsync();
            if (result.Entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok();
        }
        [HttpPut]
        [Route("UpdateDoctor")]
        public async Task<IActionResult> Put(Doctor doctor)
        {
            db.Entry(doctor).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteDoctor")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Doctor = db.Doctor.Find(Id);
            db.Entry(Doctor).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
