using Microsoft.EntityFrameworkCore;

namespace CampSleepawayAssey.DataBaseCamp
{
    public class dbContext : DbContext
    {
        public DbSet<Camper> Campers { get; set; }
        public DbSet<NextOfKin> Relatives { get; set; }
        public DbSet<Counselor> Counselors { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<CabinStatus> CabinStatuses { get; set; }
        public DbSet<CamperRelative> CampersRelatives { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=(local)\\SQLEXPRESS;Initial Catalog=CampSleepaway;Integrated Security=SSPI");
        }
    }
}
