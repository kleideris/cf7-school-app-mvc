using SchoolApp.WebMvcDbFirst.Core.Filters;
using SchoolApp.WebMvcDbFirst.Data;
using SchoolApp.WebMvcDbFirst.DTO;

namespace SchoolApp.WebMvcDbFirst.Services
{
    public interface IUserService
    {
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO cretentials);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize,
            UserFiltersDTO userFiltersDTO);
    }
}
