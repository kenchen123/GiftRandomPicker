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
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class EasterDataEditPage : ContentPage
    {
        public string ItemId
        {
            set => LoadSteps(value);
        }

        public EasterDataEditPage()
        {
            InitializeComponent();
            BindingContext = new EasterData();
        }

        public EasterDataEditPage(EasterData item)
        {
            InitializeComponent();
            BindingContext = item;
        }

        private async void LoadSteps(string itemId)
        {
            try
            {
                var id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                var note = await App.EasterStepsDatabase.GetStepsAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load data.");
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (EasterData)BindingContext;
            if (!string.IsNullOrWhiteSpace(note.Name))
            {
                await App.EasterStepsDatabase.SaveStepsAsync(note);
            }

            Navigation.PushAsync(new EasterDataListPage());
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (EasterData)BindingContext;
            await App.EasterStepsDatabase.DeleteStepsAsync(note);
            Navigation.PushAsync(new EasterDataListPage());
        }
    }
}