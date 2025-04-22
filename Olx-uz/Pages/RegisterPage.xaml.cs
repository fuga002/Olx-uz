using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olx_uz.Services;

namespace Olx_uz.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    async void BtnRegister_Clicked(System.Object sender, System.EventArgs e)
    {
      var response =  await  ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);

      if (response)
      {
          await DisplayAlert("Success", "Your account has been created", "Alright");
          await Navigation.PushModalAsync(new LoginPage()); 
      }
      else
      {
          await DisplayAlert("Error", "Oops something went rent", "Cancel");
      }
    }

    private async void TapLogin_OnTapped(object? sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new LoginPage()); 
    }
}