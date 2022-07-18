using System;
using System.Threading.Tasks;
using FindMyDisc.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FindMyDisc
{
    public class FirebaseAuthenticationService : IAuthenticationService
    {
        public static string FirebaseClient = "***REMOVED***";
        public static string FirebaseDatabaseSecrect = "***REMOVED***";
        public static string FirebaseAPIKey = "***REMOVED***";

        public FirebaseClient fc = new FirebaseClient(FirebaseClient,
                                   new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(FirebaseDatabaseSecrect) });

        public FirebaseAuthProvider ap = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAPIKey));

        public FirebaseAuthenticationService()
        {

        }

        public async void AddTestData()
        {
            await fc.Child("ItemTable")
         .PostAsync(new UserPostModel() { Description = "Testing to see if this works", Date = DateTime.Now.ToString() });
        }

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var auth = await ap.SignInWithEmailAndPasswordAsync(email, password);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                return true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
                return false;
            }

        }

        public async void CreateUser(string email, string password)
        {
            var result = await ap.CreateUserWithEmailAndPasswordAsync(email, password);
        }

        public void Logout()
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }

        public async Task<bool> RefreshAuth()
        {
            try
            {
                var savedfirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", null));
                var RefreshedContent = await ap.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));

                //We can get the email from the auth
                //var test = savedfirebaseauth.User.Email;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //await App.Current.MainPage.DisplayAlert("Alert", "Oh no ! Token expired", "OK");

                return false;

            }
        }
    }
}

