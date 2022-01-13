using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class OperatorModel : IdentityUser
    {
        public string IdOperator { get; set; }
        public string PictureFile { get; set; }
        
    }
}
