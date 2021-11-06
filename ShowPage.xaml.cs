using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;


namespace XF_SQLiteDB_Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPage : ContentPage
    {
        public ShowPage(Users user)
        {
            InitializeComponent();
            Logout.Clicked += (s, e) => Navigation.PopAsync();

            Username.Text = "Welcom Mr. " + user.Username;

            ShowMe.Text = user.UId + "\t" + user.Username + "\t" + user.Password + "\t" + user.Mobile + "\t" + user.Email;
        }

        private void MailMe_Clicked(object sender, EventArgs e)
        {

        }

        private void CallMe_Clicked(object sender, EventArgs e)
        {

        }

        private async void AllUsers_Clicked(object sender, EventArgs e)
        {
            var details = await App.UserSQLite.GetUsersAsync();
            myListView.ItemsSource = details;
        }
    }
}