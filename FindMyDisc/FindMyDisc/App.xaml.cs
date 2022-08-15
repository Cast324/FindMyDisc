using System;
using FindMyDisc.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindMyDisc
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<IAuthenticationService>(new FirebaseAuthenticationService());

            MainPage = new MainShell();


            //if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            //{
            //    MainPage = new NavigationPage(new HomePage());
            //}
            //else
            //{
            //    MainPage = new NavigationPage(new LoginPage());
            //}
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

