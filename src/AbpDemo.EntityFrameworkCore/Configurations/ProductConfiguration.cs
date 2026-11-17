using AbpDemo.Products;

namespace AbpDemo.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // configure by Abp for inherited properties
        builder.ConfigureByConvention();

        builder.Property(x => x.NameAr).IsRequired().HasMaxLength(300);
        builder.Property(x => x.NameEn).IsRequired().HasMaxLength(300);
        builder.Property(x => x.DescripationEn).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.DescripationAr).IsRequired().HasMaxLength(1000);

        builder.HasOne(x => x.Category).WithMany().HasForeignKey("CategoryId");

        builder.ToTable("Products");
    }
}
