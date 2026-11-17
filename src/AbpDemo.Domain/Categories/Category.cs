
namespace AbpDemo.Categories;

public class Category(int id, string nameEn, string nameAr) : FullAuditedEntity<int>(id)
{
    public string NameEn { get; set; } = nameEn;
    public string NameAr { get; set; } = nameAr;
}