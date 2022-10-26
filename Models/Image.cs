using MessagePack;
using Microsoft.Build.Framework;

namespace CommerceProject.Models
{
    public class Image
    {
        
        public int ImageID { get; set; }
        [Required]
        public string Title { get; set; }
        public int MyProperty { get; set; }
    }
}
