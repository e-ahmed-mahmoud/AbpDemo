using AbpDemo.Categories;

namespace AbpDemo.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property(x => x.NameAr).IsRequired().HasMaxLength(100);
        builder.Property(x => x.NameEn).IsRequired().HasMaxLength(100);

        builder.ToTable("Categories");
    }
}