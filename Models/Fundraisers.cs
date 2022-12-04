using System.ComponentModel.DataAnnotations;

namespace CommerceProject.Models
{
    public class Fundraisers
    {
        [Key]
        public int FundraiserID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        

        public double? Goals { get; set; }

        public string Imagelink { get; set; }

        public int Amount { get; set; }  
    }
}
