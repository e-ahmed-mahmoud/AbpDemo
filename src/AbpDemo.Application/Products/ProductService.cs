using System;
using System.Linq;
using System.Threading.Tasks;
using AbpDemo.Bases;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;


namespace AbpDemo.Products;

public class ProductService(IRepository<Product, Guid> repo, IMapper mapper) : BaseApplicationService, IProductService
{
    #region  fields 
    private readonly IRepository<Product, Guid> _repo = repo;
    private readonly IMapper _mapper = mapper;

    #endregion

    #region Product Services
    public async Task<PagedResultDto<ProductDto>> GetAsync(GetProductListDto dto)
    {
        if (dto.Sorting.IsNullOrWhiteSpace())
            dto.Sorting = nameof(Product.Id);

        var res = await _repo.WithDetailsAsync(p => p.Category!).Result.AsQueryable()
            .WhereIf(dto.Filter.IsNullOrWhiteSpace(), p => p.NameAr.Contains(dto.Filter) || p.NameEn.Contains(dto.Filter))
            .Skip(dto.SkipCount).Take(dto.MaxResultCount)
            .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
            .OrderBy(dto.Sorting).ToListAsync();

        var count = dto.Filter.IsNullOrWhiteSpace() ? await _repo.CountAsync() : await _repo.CountAsync(p => p.NameAr.Contains(dto.Filter) || p.NameEn.Contains(dto.Filter));

        return new PagedResultDto<ProductDto>(count, res);
    }
    public async Task<ProductDto> GetByIdAsync(Guid productId)
    {

        var product = await _repo.WithDetailsAsync(p => p.Category!).Result.FirstOrDefaultAsync(p => p.Id == productId)
            ?? throw new ProductNotFoundException(productId);

        return ObjectMapper.Map<Product, ProductDto>(product);
    }
    public async Task<ProductDto> CreateAsync(CreateUpdateProductDto createUpdateProductDto)
    {
        var product = ObjectMapper.Map<CreateUpdateProductDto, Product>(createUpdateProductDto);
        var res = await _repo.InsertAsync(product);
        return ObjectMapper.Map<Product, ProductDto>(res);
    }

    public async Task<bool> DeleteAsyncAsync(Guid productId)
    {
        var res = await _repo.GetAsync(productId);
        if (res is null)
        {
            return false;
        }
        await _repo.DeleteAsync(res.Id);
        return true;
    }


    public async Task<ProductDto> UpdateAsync(CreateUpdateProductDto createUpdateProductDto)
    {
        var prod = await _repo.FindAsync(createUpdateProductDto.Id)
            ?? throw new ProductNotFoundException(createUpdateProductDto.Id);

        var mapped = ObjectMapper.Map(createUpdateProductDto, prod);
        var updated = await _repo.UpdateAsync(mapped, true);

        return ObjectMapper.Map<Product, ProductDto>(updated);
    }
    #endregion
}
