using WebModels.ViewModels;

namespace Services.Interfaces
{
    public interface IUserService
    {
        void Register(RegisterViewModel model);
    }
}
