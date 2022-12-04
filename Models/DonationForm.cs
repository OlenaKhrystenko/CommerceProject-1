using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CommerceProject.Models
{
    public class DonationForm
    {
        [Key]
        public int FormID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public double DonationAmount { get; set; }
       
        public string? DonationType { get; set; }

        public string? NameOnCard { get; set; }
        public string? CardNumber { get; set; }
        public string? MonthYear { get; set; }
        public string?   CVC { get; set; }
        public string?   BankName { get; set; }
        public string? RoutingNumber { get; set; }

        public string? AccountNumber { get; set; }

        public string? NameOfAccountHolder { get; set; }

        public int FundraiserID { get; set; }





    }
}
