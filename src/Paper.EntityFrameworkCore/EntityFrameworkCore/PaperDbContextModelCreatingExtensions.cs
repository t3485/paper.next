using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Paper.Papers;
using Paper.Papers.Price;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Paper.EntityFrameworkCore
{
    public static class PaperDbContextModelCreatingExtensions
    {
        public static void ConfigurePaper(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<MarketPaper>(b =>
            {
                b.ToTable(PaperConsts.DbTablePrefix + nameof(MarketPaper), PaperConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Code).HasMaxLength(8).IsRequired();
                b.Property(x => x.SimpleName).HasMaxLength(16).IsRequired();
                b.Property(x => x.FullName).HasMaxLength(64).IsRequired();
                //b.HasMany(x => x.DayExchangeInfo).WithOne();
                //b.HasMany(x => x.WeekExchangeInfo).WithOne();
            });

            builder.Entity<PaperDayPricePoint>(b =>
            {
                b.ToTable(PaperConsts.DbTablePrefix + nameof(PaperDayPricePoint), PaperConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Code).HasMaxLength(8).IsRequired();
                b.Property(x => x.Date).IsRequired();
                b.OwnsOne(x => x.Price, ob =>
                {
                    PaperPriceConfig(ob);
                });
                b.HasIndex(x => new { x.Code, x.Date });
            });

            builder.Entity<PaperWeekPricePoint>(b =>
            {
                b.ToTable(PaperConsts.DbTablePrefix + nameof(PaperWeekPricePoint), PaperConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Code).HasMaxLength(8).IsRequired();
                b.Property(x => x.Date).IsRequired();
                b.OwnsOne(x => x.Price, ob =>
                {
                    PaperPriceConfig(ob);
                });
                b.HasIndex(x => new { x.Code, x.Date });
            });
        }

        private static void PaperPriceConfig<T>(OwnedNavigationBuilder<T, PaperPrice> ob)
                where T : class
        {
            ob.Property(p => p.Open).HasColumnName("Open");
            ob.Property(p => p.Close).HasColumnName("Close");
            ob.Property(p => p.Low).HasColumnName("Low");
            ob.Property(p => p.High).HasColumnName("High");
            ob.Property(p => p.Turn).HasColumnName("Turn");
            ob.Property(p => p.Chg).HasColumnName("Chg");
        }
    }
}