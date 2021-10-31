using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_SQLiteDB_Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        public Users user;
        public UpdatePage(Object user)
        {
            InitializeComponent();
            this.user = (Users)user;
            Back.Clicked += (s, e) => Navigation.PopAsync();

            Id.Text = this.user.Id.ToString();
            Username.Text = this.user.Username;
            Password.Text = this.user.Password;
        }
        private async void Update_Clicked(object sender, EventArgs e)
        {
            this.user.Username = Username.Text;
            this.user.Password = Password.Text;
            await App.UserSQLite.SaveUserAsync(this.user);
            await Navigation.PopAsync();
        }
    }
}