using Dobble.Models;

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
                    SaveToPreferences();
                else
                    Shell.Current.DisplayAlert(Strings.CreateUserError, task.Exception?.Message, Strings.Ok);
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
    }
}
