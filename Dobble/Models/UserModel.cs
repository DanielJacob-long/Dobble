using Dobble.ModelsLogic;

namespace Dobble.Models
{
    internal abstract class UserModel
    {
        protected FbData fbd = new();
        public EventHandler? OnAuthComplete;
        public bool IsRegistered => !string.IsNullOrWhiteSpace(Name);
        public string Name { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public abstract bool Login();
        public abstract void Register();
        public abstract bool IsValid();
    }
}
