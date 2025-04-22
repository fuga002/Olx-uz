using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Olx_uz.Services;

namespace Olx_uz.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }
    
    private async void TapJoinNow_OnTapped(object? sender, TappedEventArgs e)
    {
        await Navigation.PushModalAsync(new RegisterPage());
    }

    private async void BtnLogin_Clicked(object? sender, EventArgs e)
    {
      var response =  await  ApiService.Login(EntEmail.Text, EntPassword.Text);
      
      if (response)
      {
          if (Application.Current != null) Application.Current.MainPage = new CustomTabbedPage();
      }
      else
      {
          await DisplayAlert("Error", "Oops something went rent", "Cancel");
      }
      
    }
}