using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("TaskList")]
    public class TaskListModel
    {
      
        [Key]
        public int IdService { get; set; }      
        [ForeignKey("CLientModel")]
        public int ClientId { get; set; }  
        [ForeignKey("GroupModel")]
        public int GroupId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
