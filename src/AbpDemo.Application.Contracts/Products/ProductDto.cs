using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products;

public class ProductDto : FullAuditedEntityDto<Guid>
{
    public required string NameEn { get; set; }
    public required string NameAr { get; set; }
    public required string DescripationEn { get; set; }
    public required string DescripationAr { get; set; }
    public int Price { get; set; }
    public string CategoryNameEn { get; set; } = string.Empty;
    public string CategoryNameAr { get; set; } = string.Empty;
}


