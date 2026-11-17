using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace AbpDemo.Categories;

public class CategoryDto : AuditedEntityDto
{
    public required string NameEn { get; set; }
    public required string NameAr { get; set; }

}
