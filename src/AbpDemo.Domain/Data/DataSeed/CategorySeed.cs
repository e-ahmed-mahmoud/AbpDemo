using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpDemo.Categories;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AbpDemo.Data.DataSeed;

public class CategorySeed(IRepository<Category, int> repo) : IDataSeedContributor, IScopedDependency
{

    private readonly IRepository<Category, int> _repo = repo;

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _repo.AnyAsync())
        {
            return;
        }
        Category[] ls = [
            new Category(id: 1,
            nameAr: "أطعمة ومشروبات",
            nameEn: "Food & Drinks"),
        new Category(id: 2,
            nameAr: "مواد تنظيف",
            nameEn: "Detergents"),
        new Category(id: 3,
            nameAr: "عطور",
            nameEn: "Fragrances"),
        new Category(id: 4,
            nameAr: "بلاستيك",
            nameEn: "Plastic")
            ];

        await _repo.InsertManyAsync(ls);
    }
}
