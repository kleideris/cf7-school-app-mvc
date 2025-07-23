using SchoolApp.WebMvc.ModelFirst.Core.Filters;
using SchoolApp.WebMvc.ModelFirst.Data;
using SchoolApp.WebMvc.ModelFirst.DTO;

namespace SchoolApp.WebMvc.ModelFirst.Services
{
    public interface IUserService
    {
        Task<User?> VerifyAndGetUserAsync(UserLoginDTO cretentials);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<List<User>> GetAllUsersFiltered(int pageNumber, int pageSize,
            UserFiltersDTO userFiltersDTO);
    }
}
