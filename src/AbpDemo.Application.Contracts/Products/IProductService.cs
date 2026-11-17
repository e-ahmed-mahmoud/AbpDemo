using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AbpDemo.Products;

public interface IProductService
{
    public Task<PagedResultDto<ProductDto>> GetAsync(GetProductListDto dto);
    public Task<ProductDto> GetByIdAsync(Guid productId);
    public Task<ProductDto> CreateAsync(CreateUpdateProductDto createUpdateProductDto);
    public Task<ProductDto> UpdateAsync(CreateUpdateProductDto createUpdateProductDto);
    public Task<bool> DeleteAsyncAsync(Guid productId);

}
