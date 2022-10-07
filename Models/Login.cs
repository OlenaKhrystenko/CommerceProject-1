using System.ComponentModel.DataAnnotations;

namespace CommerceProject.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string SecurityQuestion1 { get; set; }
        [Required]
        public string SecurityQuestion2 { get; set; }
        [Required]
        public string SecurityQuestion3 { get; set; }  


    }
}
