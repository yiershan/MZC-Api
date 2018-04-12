using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MZC.MultiTenancy.Dto;

namespace MZC.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
