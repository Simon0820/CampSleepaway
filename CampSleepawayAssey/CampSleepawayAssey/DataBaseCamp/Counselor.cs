using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class Counselor
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public int Age { get; set; }
        [MaxLength(255)]
        public string Adress { get; set; }
        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }


    }
}
