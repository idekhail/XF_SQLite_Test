using System;
using Xamarin.Forms;

namespace XF_SQLiteDB_Test
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Close.Clicked += (s, e) => Environment.Exit(0);
            Create.Clicked += (s, e) => Navigation.PushAsync(new CreatePage());
        }
        private async void Login_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Username.Text))
            {
                var user =  await App.UserSQLite.GetUserAsync(Username.Text);
                if(user != null)
                {
                    if (user.Password == Password.Text)
                    {
                        await Navigation.PushAsync(new ShowPage(user));
                    }
                    else
                        await DisplayAlert("Error", "Password  is error", "Ok");

                }
                else
                    await DisplayAlert("Error", "Username is error", "Ok");
            }
            else
                await DisplayAlert("Error", "Username is empty", "Ok");
        }

        private async void Update_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Username.Text))
            {
                var user = await App.UserSQLite.GetUserAsync(Username.Text);
                if (user != null)
                {
                    if (user.Password == Password.Text)
                    {
                        await Navigation.PushAsync(new UpdatePage(user));
                    }
                    else
                        await DisplayAlert("Error", "Password  is error", "Ok");

                }
                else
                    await DisplayAlert("Error", "Username is error", "Ok");
            }
            else
                await DisplayAlert("Error", "Username is empty", "Ok");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Username.Text = string.Empty;
            Password.Text = "";

        }
    }
}
