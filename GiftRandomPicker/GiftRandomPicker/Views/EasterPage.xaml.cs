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
    public partial class EasterPage : ContentPage
    {
        private List<string> _employeeList = new List<string> { "Leo", "Weita", "Ken", "Jason", "Shareena", "Esther", "Peggie", "Sandy" };

        public EasterPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //var stepsList = await App.EasterStepsDatabase.GetStepsListAsync();
            collectionView.ItemsSource = await App.EasterStepsDatabase.GetStepsListAsync();

        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterEditPage());
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                var item = (EasterSteps)e.CurrentSelection.FirstOrDefault();
                await Navigation.PushAsync(new EasterEditPage(item));
            }
        }
    }
}