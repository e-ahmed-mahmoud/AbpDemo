using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;

namespace AbpDemo.Products;

public class ProductNotFoundException : BusinessException
{
    public ProductNotFoundException(Guid id) : base(code: AbpDemoDomainErrorCodes.ProductNotFoundException)
    {
        WithData("id", id);
    }
}
