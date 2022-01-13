using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Activities")]
    public class ActivitiesModel
    {
        [Key]
        public int Id { get; set; }     
      
       [ForeignKey("TaskListModel")]
        public int IdService { get; set; }
        [ForeignKey("OperatorModel")]
        public int IdOperator { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndTIme { get; set; }

        public string Comment { get; set; }

        public int Time { get; set; }

        public bool IsActive { get; set; }

        public bool IsShadowing { get; set; }

        public bool IsExtraTime { get; set; }
    }
}
