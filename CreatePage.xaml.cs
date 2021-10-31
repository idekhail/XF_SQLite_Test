using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_SQLiteDB_Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreatePage : ContentPage
    {
        public CreatePage()
        {
            InitializeComponent();
            Back.Clicked += (s, e) => Navigation.PopAsync();

        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(Username.Text)) && (await App.UserSQLite.GetUserAsync(Username.Text) == null))
            {
                Users user = new Users()
                {
                    Username = Username.Text,
                    Password = Password.Text
                };
                await App.UserSQLite.SaveUserAsync(user);
                await DisplayAlert("Done", "Username is added", "Ok");
                await Navigation.PopAsync();
            }
            else
                await DisplayAlert("Error", "Username is empty Or Username is already existe", "Ok");
        }
    }
}