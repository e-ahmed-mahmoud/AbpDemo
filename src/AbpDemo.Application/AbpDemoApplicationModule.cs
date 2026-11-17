using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation;
namespace AbpDemo;

[DependsOn(
    typeof(AbpDemoDomainModule),
    typeof(AbpDemoApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpFluentValidationModule)
    )]
public class AbpDemoApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // config automapper
        Configure<AbpAutoMapperOptions>(options => options.AddMaps<AbpDemoApplicationModule>());

        context.Services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(typeof(IAssemblyMarker).Assembly);

        base.ConfigureServices(context);
    }
}
