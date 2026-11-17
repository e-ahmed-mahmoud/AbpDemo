using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbpDemo.Categories;
using AbpDemo.Products;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpDemo.Data.DataSeed;

public class ProductSeed(IRepository<Product, Guid> repo, IRepository<Category, int> CategoryIdRepo) : IDataSeedContributor, IScopedDependency
{
    public async Task SeedAsync(DataSeedContext context)
    {
        if (await repo.AnyAsync() || !await CategoryIdRepo.AnyAsync())
        {
            return;
        }
        var products = new List<Product>
        {
            // CategoryId 1: Food & Drinks (أطعمة ومشروبات)
            new Product
            {
                NameEn = "Green Tea",
                NameAr = "شاي أخضر",
                DescripationEn = "Organic natural green tea bags",
                DescripationAr = "أكياس شاي أخضر طبيعي وعضوي",
                Price = 45,
                CategoryId = 1
            },
            new Product
            {

                NameEn = "Natural Honey",
                NameAr = "عسل طبيعي",
                DescripationEn = "Pure organic flower honey 500g",
                DescripationAr = "عسل زهور طبيعي نقي 500 جرام",
                Price = 120,
                CategoryId = 1
            },
            
            // CategoryId 2: Detergents (مواد تنظيف)
            new Product
            {

                NameEn = "Surface Cleaner",
                NameAr = "منظف الأسطح",
                DescripationEn = "Multi-purpose surface disinfectant cleaner",
                DescripationAr = "منظف ومطهر متعدد الأغراض للأسطح",
                Price = 25,
                CategoryId = 2
            },
            new Product
            {

                NameEn = "Dishwashing Liquid",
                NameAr = "سائل غسيل الأطباق",
                DescripationEn = "Lemon scented grease-cutting dish soap",
                DescripationAr = "سائل غسيل أطباق برائحة الليمون ومزيل للدهون",
                Price = 30,
                CategoryId = 2
            },

            // CategoryId 3: Fragrances (عطور)
            new Product
            {

                NameEn = "Oud Perfume",
                NameAr = "عطر عود",
                DescripationEn = "Luxury oriental woody fragrance 100ml",
                DescripationAr = "عطر شرقي خشبي فاخر 100 مل",
                Price = 350,
                CategoryId = 3
            },
            new Product
            {

                NameEn = "Lavender Mist",
                NameAr = "بخاخ لافندر",
                DescripationEn = "Refreshing body and linen lavender mist",
                DescripationAr = "بخاخ منعش للجسم والأقمشة برائحة اللافندر",
                Price = 75,
                CategoryId = 3
            },

            // CategoryId 4: Plastic (بلاستيك)
            new Product
            {

                NameEn = "Food Storage Containers",
                NameAr = "حاويات حفظ الطعام",
                DescripationEn = "Reusable airtight plastic container set of 4",
                DescripationAr = "طقم حاويات بلاستيكية محكمة الغلق وقابلة لإعادة الاستخدام 4 قطع",
                Price = 60,
                CategoryId = 4
            },
            new Product
            {

                NameEn = "Garbage Bags",
                NameAr = "أكياس قمامة",
                DescripationEn = "Heavy duty recyclable trash bags roll",
                DescripationAr = "رول أكياس قمامة متينة وقابلة للتدوير",
                Price = 20,
                CategoryId = 4
            }
        };

        await repo.InsertManyAsync(products, true);

    }
}
