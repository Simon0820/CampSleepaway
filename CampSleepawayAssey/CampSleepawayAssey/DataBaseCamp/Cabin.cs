using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class Cabin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(255)]
        public string CabinName { get; set; }
        public int CounselorID { get; set; }

        [ForeignKey(nameof(CounselorID))]
        public virtual Counselor Counselor { get; set; }
    }
}
