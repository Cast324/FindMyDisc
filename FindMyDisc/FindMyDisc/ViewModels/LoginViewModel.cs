using System;
using System.Windows.Input;
using FindMyDisc.Views;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace FindMyDisc.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        private INavigation mNavigation { get; set; }

        private string _Email;
        public string Email
        {
            get => _Email;
            set => SetProperty(ref _Email, value);
        }

        private string _Password;
        public string Password
        {
            get => _Password;
            set => SetProperty(ref _Password, value);
        }

        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get => _LoginCommand;
            set => SetProperty(ref _LoginCommand, value);
        }

        private ICommand _CreateUserCommand;
        public ICommand CreateUserCommand
        {
            get => _CreateUserCommand;
            set => SetProperty(ref _CreateUserCommand, value);
        }

        private IAuthenticationService mAuthService { get; }

        private LoginPage mLoginPage { get; set; }

        #endregion

        public LoginViewModel(INavigation navigation, IAuthenticationService authService, LoginPage loginPage)
        {
            mNavigation = navigation;
            mAuthService = authService;
            mLoginPage = loginPage;
            LoginCommand = new MvvmHelpers.Commands.Command(Login);
            CreateUserCommand = new MvvmHelpers.Commands.Command(CreateUser);
        }

        public LoginViewModel(INavigation navigation, LoginPage loginPage) : this(navigation, DependencyService.Get<IAuthenticationService>(), loginPage)
        {
            
        }

        private void CreateUser()
        {
            mAuthService.CreateUser(Email, Password);
        }

        private async void Login()
        {
            var result = await mAuthService.Login(Email, Password);
            if (result) {
                App.Current.MainPage = new NavigationPage(new HomePage());
            }
        }
    }
}

