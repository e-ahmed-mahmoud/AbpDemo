using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpDemo.Categories;

public interface ICategoryAppService : ICrudAppService<CategoryDto, int, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto>
{

}
