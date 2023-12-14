using WebApplicationBilling.Models;
using WebApplicationBilling.Models.DTO;

namespace WebApplicationBilling.Repository.Interfaces
{
    public interface IAccountRepository: IRepository<UserRegisterDTO>
    {
        Task<bool> RegisterAsync(string url, UserRegisterDTO itemCrear);
        Task<UserLoginResponseDTO> LoginAsync(string url, UserLoginDTO userLoginDTO);
    }
}
