using System;
using System.IO;
using GiftRandomPicker.Data;
using Xamarin.Forms;

namespace GiftRandomPicker
{
    public partial class App : Application
    {
        static RecordDatabase database;

        public static RecordDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecordDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "record.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
