using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftRandomPicker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftRandomPicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EasterDataListPage : ContentPage
    {
        private List<string> _employeeList = new List<string> { "Leo", "Weita", "Ken", "Jason", "Shareena", "Esther", "Peggie", "Sandy" };

        public EasterDataListPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var stepsList = await App.EasterStepsDatabase.GetStepsListAsync();
            if (stepsList.Count == 0)
            {
                InitialData();
                collectionView.ItemsSource = await App.EasterStepsDatabase.GetStepsListAsync();
            }
            else
            {
                collectionView.ItemsSource = stepsList;
            }
        }

        private static async void InitialData()
        {
            var data = new List<EasterData>()
            {
                new EasterData {Name = "Leo"},
                new EasterData {Name = "Weita"},
                new EasterData {Name = "Ken"},
                new EasterData {Name = "Jason"},
                new EasterData {Name = "Shareena"},
                new EasterData {Name = "Peggie"},
                new EasterData {Name = "Sandy"},
                new EasterData {Name = "Esther"}
            };

            foreach (var item in data)
            {
                await App.EasterStepsDatabase.SaveStepsAsync(item);
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterDataEditPage());
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var item = (EasterData)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new EasterDataEditPage(item));
            }
        }
    }
}