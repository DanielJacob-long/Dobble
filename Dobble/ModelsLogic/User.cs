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
            Preferences.Set(Keys.NameKey, Name);
            Preferences.Set(Keys.UserNameKey, UserName);
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
    }
}
