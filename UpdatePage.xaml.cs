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

            Cancel.Clicked += (s, e) => Navigation.PopAsync();

            UId.Text = this.user.UId.ToString();
            Username.Text = this.user.Username;
            Password.Text = this.user.Password;
            Mobile.Text = this.user.Mobile;
            Email.Text = this.user.Email;
        }
        private async void Update_Clicked(object sender, EventArgs e)
        {
            this.user.Username = Username.Text;
            this.user.Password = Password.Text;
            this.user.Mobile   = Mobile.Text;
            this.user.Email    = Email.Text;

            await App.UserSQLite.SaveUserAsync(this.user);
            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, EventArgs e)
        {
            await App.UserSQLite.DeleteUserAsync(this.user);
            await Navigation.PopAsync();
        }
    }
}