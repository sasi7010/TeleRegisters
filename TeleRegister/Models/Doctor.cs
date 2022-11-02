using System.ComponentModel.DataAnnotations;

namespace TeleRegister.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string? LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime? DOB { get; set; }
        [StringLength(10)]
        public string Gender { get; set; }
        [StringLength(20)]
        public string? CreatedDate { get; set; }
    }
}
