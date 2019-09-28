using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterViewModel model);
        void Login(LoginViewModel model);
        void Logout();
        UserViewModel GetCurrentUser(string username);
    }
}
