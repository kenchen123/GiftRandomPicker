using System;
using System.IO;
using GiftRandomPicker.Data;
using GiftRandomPicker.Views;
using Xamarin.Forms;

namespace GiftRandomPicker
{
    public partial class App : Application
    {
        static RecordDatabase database;
        private static EasterStepsDatabase easterStepsDatabase;

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

        public static EasterStepsDatabase EasterStepsDatabase
        {
            get
            {
                if (easterStepsDatabase == null)
                {
                    easterStepsDatabase = new EasterStepsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "easter.db3"));
                }
                return easterStepsDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new EasterPage());
            //MainPage = new EasterEditPage();
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
