
using System.ComponentModel.DataAnnotations;
namespace Assignment.Models
{
    public class Event_Model
    {
       public int id {  get; set; }
        [Required]
        public string name { get; set; }
        public DateTime Date { get; set; }

    }
}
