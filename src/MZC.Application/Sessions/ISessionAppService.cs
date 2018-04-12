using System.Threading.Tasks;
using Abp.Application.Services;
using MZC.Sessions.Dto;

namespace MZC.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
