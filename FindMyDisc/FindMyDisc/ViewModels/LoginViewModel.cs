using System;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace FindMyDisc.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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

        public FirebaseManager fb = new FirebaseManager();

        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }

        private void Login()
        {
            fb.CreateUser(Email, Password);
        }
    }
}

