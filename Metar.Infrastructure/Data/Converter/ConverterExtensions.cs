using MetarSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MetarApi.Data.Converter
{
    public static class ConverterExtensions
    {
        public static PropertyBuilder<T?> HasJsonConversion<T>(this PropertyBuilder<T?> propertyBuilder,bool isRequired)
        {
            propertyBuilder.HasConversion(new JsonValueConverter<T>())
                .HasColumnType("TEXT")
                .IsRequired(isRequired)
                .Metadata.SetValueConverter(new JsonValueConverter<T>());
            return propertyBuilder;
        }
    }
}
