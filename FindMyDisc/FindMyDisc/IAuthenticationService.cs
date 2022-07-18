using System.Threading.Tasks;

namespace FindMyDisc
{
    public interface IAuthenticationService
    {
        void CreateUser(string email, string password);
        Task<bool> Login(string email, string password);
        void Logout();
        Task<bool> RefreshAuth();
    }
}