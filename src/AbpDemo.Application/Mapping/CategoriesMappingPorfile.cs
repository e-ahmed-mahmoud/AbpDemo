using AbpDemo.Categories;
using AutoMapper;
using Volo.Abp.AutoMapper;
namespace AbpDemo.Mapping;

public class CategoryToCategoryDtoMapper : Profile
{
    public CategoryToCategoryDtoMapper()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
    }
}
// [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
// public partial class AbpDemoAuthorToAuthorExcelDtoMapper : MapperBase<Author, AuthorExcelDto>
// {
//     public override partial AuthorExcelDto Map(Author source);

//     public override partial void Map(Author source, AuthorExcelDto destination);
// }