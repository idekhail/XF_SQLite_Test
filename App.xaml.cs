using System;
using System.IO;
using Xamarin.Forms;
namespace XF_SQLiteDB_Test
{
    public partial class App : Application
    {
        static UserOperation db;

        // Create the database connection as a singleton.
        public static UserOperation UserSQLite
        {
            get
            {
                if (db == null)
                {
                    db = new UserOperation(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDB.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
