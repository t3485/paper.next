using Microsoft.EntityFrameworkCore;
using Paper.Users;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.Users.EntityFrameworkCore;
using Paper.Papers;
using Paper.Papers.Price;
using Microsoft.Extensions.Logging;

namespace Paper.EntityFrameworkCore
{
    /* This is your actual DbContext used on runtime.
     * It includes only your entities.
     * It does not include entities of the used modules, because each module has already
     * its own DbContext class. If you want to share some database tables with the used modules,
     * just create a structure like done for AppUser.
     *
     * Don't use this DbContext for database migrations since it does not contain tables of the
     * used modules (as explained above). See PaperMigrationsDbContext for migrations.
     */
    [ConnectionStringName("Default")]
    public class PaperDbContext : AbpDbContext<PaperDbContext>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<MarketPaper> Papers { get; set; }
        public DbSet<PaperDayPricePoint> DayPrice { get; set; }
        public DbSet<PaperWeekPricePoint> WeekPrice { get; set; }

        /* Add DbSet properties for your Aggregate Roots / Entities here.
         * Also map them inside PaperDbContextModelCreatingExtensions.ConfigurePaper
         */

        public static readonly ILoggerFactory LogFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public PaperDbContext(DbContextOptions<PaperDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure the shared tables (with included modules) here */

            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users"); //Sharing the same table "AbpUsers" with the IdentityUser
                
                b.ConfigureByConvention();
                b.ConfigureAbpUser();

                /* Configure mappings for your additional properties
                 * Also see the PaperEfCoreEntityExtensionMappings class
                 */
            });

            /* Configure your own tables/entities inside the ConfigurePaper method */

            builder.ConfigurePaper();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LogFactory).UseLazyLoadingProxies();
        }
    }
}
