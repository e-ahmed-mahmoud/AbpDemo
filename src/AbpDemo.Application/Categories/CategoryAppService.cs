using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace AbpDemo.Categories;

public class CategoryAppService(IRepository<Category, int> repo) :
CrudAppService<Category, CategoryDto, int, PagedAndSortedResultRequestDto, CreateUpdateCategoryDto>(repo)
, ICategoryAppService
{

}
