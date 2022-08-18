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
        

        public HomeViewModel(IAuthenticationService authService)
        {
            mAuthService = authService;
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

    }
}

