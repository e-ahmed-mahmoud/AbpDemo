using System;
using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products;

public class CreateUpdateProductDto : EntityDto<Guid>
{
    public required string NameEn { get; set; }
    public required string NameAr { get; set; }
    public required string DescripationEn { get; set; }
    public required string DescripationAr { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }

}


