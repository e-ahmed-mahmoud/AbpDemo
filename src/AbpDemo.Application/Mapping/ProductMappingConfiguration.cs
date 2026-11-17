using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpDemo.Products;
using AutoMapper;

namespace AbpDemo.Mapping;

public class ProductMappingConfiguration : Profile
{
    public ProductMappingConfiguration()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<CreateUpdateProductDto, Product>().ReverseMap();
    }
}
