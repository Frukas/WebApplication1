using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class GroupModel
    {
        
        [Key]        
        public int GroupId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
