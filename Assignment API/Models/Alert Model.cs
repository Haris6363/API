
using LiteDB;
using System.ComponentModel.DataAnnotations;
namespace Assignment.Models
{
    public class Alert_Model
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }



    }
    
    
}
