using Dobble.ViewModels;

namespace Dobble.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        BindingContext = new RegisterVM();
    }
}