using Dobble.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Runtime.CompilerServices;

namespace Dobble.ModelsLogic
{
    internal class User: UserModel
    {
        public override bool Login()
        {
                return true;
        }
        public override void Register()
        {
            fbd.CreateUserWithEmailAndPasswordAsync(Email, Password, Name, OnComplete);
            Preferences.Set(Keys.NameKey, Name);
            Preferences.Set(Keys.UserNameKey, UserName);
            Preferences.Set(Keys.EmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
        }

        private void OnComplete(Task task)
        {
            if (task.IsCompletedSuccessfully)
            {
                SaveToPreferences();
                OnAuthComplete?.Invoke(this, EventArgs.Empty);
            }
            else if (task.Exception != null)
            {
                string msg = ReasonMsg(task.Exception.Message);
                ShowAlert(msg);
            }
            else
                ShowAlert(Strings.CreateUserError);
        }

        private string ReasonMsg(string msg)
        {
            int reasonIndex= msg.LastIndexOf(Strings.ErorReason);
            if (reasonIndex == -1)
                return Strings.CreateUserError;
            msg= msg.Substring(reasonIndex+ Strings.ErorReason.Length);
            return msg;
        }
        private void ShowAlert(string msg)
        {
            MainThread.InvokeOnMainThreadAsync(() =>
            {
                Toast.Make(msg, ToastDuration.Long).Show();
            });
        }

        private void SaveToPreferences()
        {
            Preferences.Set(Keys.NameKey, Name);
            Preferences.Set(Keys.EmailKey, Email);
            Preferences.Set(Keys.PasswordKey, Password);
        }

        public User()
        {
            Name = Preferences.Get(Keys.NameKey, string.Empty);
            UserName = Preferences.Get(Keys.UserNameKey, string.Empty);
            Email = Preferences.Get(Keys.EmailKey, string.Empty);
            Password = Preferences.Get(Keys.PasswordKey, string.Empty);
        }
        public override bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }
        public async Task ResetPassword()
        {
            await fbd.SendPasswordResetEmailAsync(Email, OnCompleteSendEmail);
        }
        private async Task OnCompleteSendEmail(Task task)
        {
            if (task.IsCompletedSuccessfully)
            {
                await Shell.Current.DisplayAlert(Strings.ResetPWTitle, Strings.ResetPWMessage, Strings.ResetPWButton);
            }
            else
            {
                string errorMessage = ReasonMsg(task!.Exception!.InnerException!.Message);
                await Shell.Current.DisplayAlert(Strings.ResetPWErrorTitle, errorMessage, Strings.ResetPWErrorButton);
            }
        }
    }
}
