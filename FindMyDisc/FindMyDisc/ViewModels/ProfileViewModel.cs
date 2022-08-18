using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace FindMyDisc.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private IAuthenticationService mAuthService { get; }

        private ICommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get => _LogoutCommand;
            set => SetProperty(ref _LogoutCommand, value);
        }

        public ProfileViewModel(IAuthenticationService authService)
        {
            mAuthService = authService;
            LogoutCommand = new MvvmHelpers.Commands.Command(Logout);
        }

        public ProfileViewModel() : this(DependencyService.Get<IAuthenticationService>())
        {

        }

        private void Logout()
        {
            mAuthService.Logout();
        }
    }
}
