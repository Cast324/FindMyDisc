using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindMyDisc.Views
{
    public partial class StartupPage : ContentPage
    {
        private IAuthenticationService mAuthService { get; }

        public StartupPage(IAuthenticationService authenticationService)
        {
            InitializeComponent();
            mAuthService = authenticationService;          
        }

        public StartupPage() : this(DependencyService.Get<IAuthenticationService>())
        {

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckLogin();
        }

        private async void CheckLogin()
        {
            var result = await mAuthService.RefreshAuth();

            if (!result)
            {
                await Shell.Current.GoToAsync($"//Login", false);
            } else
            {
                await Shell.Current.GoToAsync($"//Main");
            }
        }
    }
}
