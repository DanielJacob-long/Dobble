using System.Windows.Input;
using Dobble.ModelsLogic;

namespace Dobble.ViewModels
{
    internal class RegisterVM
    {
        private readonly User user = new();
        public ICommand RegisterCommand { get; }

        public bool CanRegister()
        {
            return !string.IsNullOrWhiteSpace(user.Name);
        }

        private void Register()
        {
            user.Register();
        }

        public string Name
        {
            get => user.Name;
            set
            {
                user.Name = value;
                (RegisterCommand as Command)?.ChangeCanExecute();
            }
        }
        public string UserName
        {
            get => user.UserName;
            set
            {
                user.UserName = value;
                (RegisterCommand as Command)?.ChangeCanExecute();
            }
        }
        public string Email
        {
            get => user.Email;
            set
            {
                user.Email = value;
                (RegisterCommand as Command)?.ChangeCanExecute();
            }
        }
        public string Password
        {
            get => user.Password;
            set
            {
                user.Password = value;
                (RegisterCommand as Command)?.ChangeCanExecute();
            }
        }
        public RegisterVM()
        {
            RegisterCommand = new Command(Register, CanRegister);
        }
    }
}
