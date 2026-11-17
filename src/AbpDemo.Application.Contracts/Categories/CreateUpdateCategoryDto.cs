using Volo.Abp.Application.Dtos;

namespace AbpDemo.Categories;

public class CreateUpdateCategoryDto : EntityDto<int>
{
    public required string NameEn { get; set; }
    public required string NameAr { get; set; }

}
