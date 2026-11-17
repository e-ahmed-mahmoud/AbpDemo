using System;
using AbpDemo.Categories;

namespace AbpDemo.Products;

public class Product : FullAuditedEntity<Guid>
{
    public new Guid Id { get; set; } = Guid.CreateVersion7();
    public required string NameEn { get; set; }
    public required string NameAr { get; set; }
    public required string DescripationEn { get; set; }
    public required string DescripationAr { get; set; }
    public int Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
