using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class CabinStatus
    {
        [Key]
        public int ID { get; set; }
        public int CabinID { get; set; }
        public int CamperID { get; set; }
        [MaxLength(255)]
        public string CabinArrival { get; set; }
        [MaxLength(255)]
        public string CabinDeparture { get; set; }



        [ForeignKey(nameof(CabinID))]
        public virtual Cabin Cabin { get; set; }

        [ForeignKey(nameof(CamperID))]
        public virtual Camper Camper { get; set; }
    }
}
