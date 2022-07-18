using System;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace FindMyDisc.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IAuthenticationService mAuthService { get; }

        private ICommand _LogoutCommand;
        public ICommand LogoutCommand
        {
            get => _LogoutCommand;
            set => SetProperty(ref _LogoutCommand, value);
        }

        public HomeViewModel(IAuthenticationService authService)
        {
            mAuthService = authService;
            LogoutCommand = new MvvmHelpers.Commands.Command(Logout);
        }

        public HomeViewModel() : this(DependencyService.Get<IAuthenticationService>())
        {

        }

        public async void CheckAuth()
        {
            var result = await mAuthService.RefreshAuth();

            if (!result)
            {
                mAuthService.Logout();
            }
        }

        private void Logout()
        {
            mAuthService.Logout();
        }

    }
}

