using System.ComponentModel.DataAnnotations;

namespace QuestPond.Models
{
    public class Customer
    {
        [Required]
        [RegularExpression("^[A-Z]{3,3}[0-9]{4,4}$")]
        public string CustomerCode { get; set; }
        [Required]
        [StringLength(10)]
        public string CustomerName { get; set; }
    }
}