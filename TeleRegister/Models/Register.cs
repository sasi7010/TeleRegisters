using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TeleRegister.Models
{
    public class Register
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
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        [StringLength(20)]
        public string? CreatedDate { get; set; }


    }
}
