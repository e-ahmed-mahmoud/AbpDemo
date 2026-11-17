using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products;

public class GetProductListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; } = string.Empty;
}