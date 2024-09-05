using MetarApi.Data.Converter;
using MetarApi.Entities;
using MetarSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetarApi.Data.Config
{
    public class MetarConfig : IEntityTypeConfiguration<MetarEntity>
    {
        public void Configure(EntityTypeBuilder<MetarEntity> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m=>m.Id).UseIdentityColumn();
            builder.Property(m=>m.MetarRaw).IsRequired(false).HasMaxLength(256).IsUnicode();
            builder.Property(m => m.Airport).IsRequired().HasMaxLength(256).IsUnicode();

            //
            builder.Property(m => m.ReportingTime).HasJsonConversion(true);

            builder.Property(m => m.Wind).HasJsonConversion(true);

            builder.Property(m => m.RunwayVisibilities).HasJsonConversion(false);

            builder.Property(m => m.Visibility).HasJsonConversion(true);

            builder.Property(m => m.Weather).HasJsonConversion(false);

            builder.Property(m => m.Clouds).HasJsonConversion(true);

            builder.Property(m => m.Temperature).HasJsonConversion(true);

            builder.Property(m => m.Pressure).HasJsonConversion(true);

            builder.Property(m => m.Trends).HasJsonConversion(true);

            builder.Property(m => m.RunwayConditions).HasJsonConversion(false);
            builder.Property(m => m.AdditionalInformation).HasJsonConversion(true);

            builder.Property(m => m.ReadableReport).IsRequired(false).HasMaxLength(2024).IsUnicode();

        }
    }
}
