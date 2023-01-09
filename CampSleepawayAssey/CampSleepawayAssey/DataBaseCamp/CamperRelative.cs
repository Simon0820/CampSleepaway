using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class CamperRelative
    {
        [Key]
        public int ID { get; set; }
        public int RelativeID { get; set; }
        public int CamperID { get; set; }
        [MaxLength(255)]
        public string CamperName { get; set; }
        [MaxLength(255)]
        public string RelativeName { get; set; }

        [ForeignKey(nameof(CamperID))]
        public virtual Camper Camper { get; set; }

        [ForeignKey(nameof(RelativeID))]
        public virtual NextOfKin NextOfKin { get; set; }
    }
}
