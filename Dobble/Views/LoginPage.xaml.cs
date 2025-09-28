using Dobble.ViewModels;

namespace Dobble.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent(); 
		BindingContext = new LoginVM();
    }
}