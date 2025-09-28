namespace Dobble.Views;
using Dobble.ViewModels;
using System;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
        InitializeComponent();
        BindingContext = new RegisterVM();
    }
}