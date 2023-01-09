using System.ComponentModel.DataAnnotations;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class Camper
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        [MaxLength(255)]
        public string Adress { get; set; }
        [MaxLength(255)]
        public string ArrivalDate { get; set; }
        [MaxLength(255)]
        public string DepartureDate { get; set; }
    }
}
