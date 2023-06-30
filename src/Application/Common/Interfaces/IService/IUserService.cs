using SRIS.Application.MyUsers.Queries.GetMyUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IMyUserService
    {
        Task<List<MyUserDto>> GetMyUsers();

        Task<int> AddMyUser(MyUserDto MyUser);

        Task<MyUserDto> GetMyUser(int? MyUserId);

        Task<int> DeleteMyUser(int? MyUserId);

        Task<int> UpdateMyUser(MyUserDto MyUser);
    }
}
