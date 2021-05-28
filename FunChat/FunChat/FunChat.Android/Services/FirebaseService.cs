using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using FunChat.Droid.Services;
using FunChat.Services;
using Java.Lang;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FunChat.Droid.Services
{
    public class FirebaseService : PhoneAuthProvider.OnVerificationStateChangedCallbacks, IFirebaseService
    {
        private const int TIMEOUT = 60;
        private string verificationID;
        private TaskCompletionSource<bool> _phoneVerifyTask;

        public FirebaseService()
        {

        }

        // https://www.youtube.com/watch?v=y6pCo0lLx9U
        public override void OnVerificationCompleted(PhoneAuthCredential p0)
        {
            throw new NotImplementedException();
        }

        // This request is missing a valid app identifier, meaning that neither SafetyNet checks nor reCAPTCHA checks succeeded. Please try again, or check the logcat for more details.

        public override void OnVerificationFailed(FirebaseException p0)
        {
            _phoneVerifyTask?.TrySetResult(false);
        }

        public override void OnCodeSent(string p0, PhoneAuthProvider.ForceResendingToken p1)
        {
            base.OnCodeSent(p0, p1);

            verificationID = p0;
            _phoneVerifyTask?.TrySetResult(true);
        }

        public Task<bool> LoginWithPhone(string phoneNo)
        {
            _phoneVerifyTask = new TaskCompletionSource<bool>();

            PhoneAuthOptions options = PhoneAuthOptions.NewBuilder()
                .SetPhoneNumber(phoneNo)
                .SetTimeout(new Long(TIMEOUT), TimeUnit.Seconds)
                .SetCallbacks(this)
                .SetActivity(Platform.CurrentActivity)
                .Build();

            PhoneAuthProvider.VerifyPhoneNumber(options);

            return _phoneVerifyTask.Task;
        }

        

        public Task<bool> VerifyOTPCode(string code)
        {
            if (!string.IsNullOrWhiteSpace(verificationID))
            {
                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
                PhoneAuthCredential credential = PhoneAuthProvider.GetCredential(verificationID, code);

                FirebaseAuth.Instance.SignInWithCredentialAsync(credential).ContinueWith((task) => OnAuthCompleted(task, tcs));

                return tcs.Task;
            }

            return Task.FromResult(false);
        }

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                // something went wrong
                tcs.SetResult(false);
                return;
            }

            verificationID = null;
            tcs.SetResult(true);
        }
    }
}