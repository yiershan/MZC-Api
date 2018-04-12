using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MZC.Roles.Dto;
using MZC.Users.Dto;

namespace MZC.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}