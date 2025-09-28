namespace Dobble.Models
{
    internal abstract class UserModel
    {
        public abstract void Register();
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public abstract bool Login();
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name);
    }
}
