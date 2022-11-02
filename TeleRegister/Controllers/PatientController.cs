using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeleRegister.Data;
using TeleRegister.Models;

namespace TeleRegister.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public readonly DBContext db;
        public PatientController(DBContext _db)
        {
            this.db = _db;
        }
        [HttpGet]
        [Route("GetPatient")]
        public async Task<IActionResult> Get()
        {
            return Ok(await db.Patient.OrderByDescending(x=>x.Id).ToListAsync());
        }
        [HttpGet]
        [Route("GetPatientByID/{Id}")]
        public async Task<IActionResult> GetPatientById(int Id)
        {
            return Ok(await db.Patient.FindAsync(Id));
        }
        [HttpPost]
        [Route("AddPatient")]
        public async Task<IActionResult> Post(Patient patient)
        {
            patient.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            var result = await db.Patient.AddAsync(patient);
            await db.SaveChangesAsync();
            if (result.Entity == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok();
        }
        [HttpPut]
        [Route("UpdatePatient")]
        public async Task<IActionResult> Put(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeletePatient")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Patient = db.Patient.Find(Id);
            db.Entry(Patient).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
