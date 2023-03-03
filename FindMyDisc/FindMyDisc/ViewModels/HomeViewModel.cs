using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FindMyDisc.Models;
using MvvmHelpers;
using MvvmHelpers.Commands;
using Xamarin.Forms;

namespace FindMyDisc.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private IAuthenticationService mAuthService { get; }

        public ObservableCollection<UserPostModel> DatabaseItems { get; set; } = new ObservableCollection<UserPostModel>();

        public HomeViewModel(IAuthenticationService authService)
        {
            mAuthService = authService;
            var fc = mAuthService.GetFirebaseClient();
            var collection = fc
                .Child("ItemTable")
                .AsObservable<UserPostModel>()
                .Subscribe((dbevent) =>
                {
                    if (dbevent.Object != null)
                    {
                        DatabaseItems.Add(dbevent.Object);
                    }
                });
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

