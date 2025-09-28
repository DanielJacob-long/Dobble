using Dobble.ModelsLogic;
using Dobble.Views;

namespace Dobble
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            User user = new();
            Page page = user.IsRegistered ? new LoginPage() : new RegisterPage();
            MainPage = page;
         
        }
    }
}
