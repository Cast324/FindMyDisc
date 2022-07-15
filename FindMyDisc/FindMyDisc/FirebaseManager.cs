using System;
using System.Threading.Tasks;
using FindMyDisc.Models;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;

namespace FindMyDisc
{
    public class FirebaseManager
    {
        public static string FirebaseClient = "***REMOVED***";
        public static string FirebaseDatabaseSecrect = "***REMOVED***";
        public static string FirebaseAPIKey = "***REMOVED***";

        public FirebaseClient fc = new FirebaseClient(FirebaseClient,
                                   new FirebaseOptions { AuthTokenAsyncFactory = () => Task.FromResult(FirebaseDatabaseSecrect) });

        public FirebaseAuthProvider ap = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAPIKey));

        public FirebaseManager()
        {

        }

        public async void AddTestData()
        {
            await fc.Child("ItemTable")
         .PostAsync(new UserPostModel() { Description = "Testing to see if this works", Date = DateTime.Now.ToString() });
        }

        public async void Login(string email, string password)
        {
            var auth = await ap.SignInWithEmailAndPasswordAsync(email, password);
        }

        public async void CreateUser(string email, string password)
        {
            var result = await ap.CreateUserWithEmailAndPasswordAsync(email, password);
        }
    }
}

