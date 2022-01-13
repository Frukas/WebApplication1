using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Client")]
    public class ClientModel
    {
       
        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string AbreviationName { get; set; }
        public int Wave { get; set; }
        public bool IsActive { get; set; }

    }
}
