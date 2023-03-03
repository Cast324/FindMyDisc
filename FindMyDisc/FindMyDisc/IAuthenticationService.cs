using Firebase.Database;
using System.Threading.Tasks;

namespace FindMyDisc
{
    public interface IAuthenticationService
    {
        void CreateUser(string email, string password);
        FirebaseClient GetFirebaseClient();
        Task<bool> Login(string email, string password);
        void Logout();
        Task<bool> RefreshAuth();
    }
}