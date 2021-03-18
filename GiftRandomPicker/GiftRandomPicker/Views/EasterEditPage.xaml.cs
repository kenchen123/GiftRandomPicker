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
    public partial class EasterEditPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadSteps(value);
            }
        }

        public EasterEditPage()
        {
            InitializeComponent();
            BindingContext = new EasterSteps();
        }

        public EasterEditPage(EasterSteps item)
        {
            InitializeComponent();
            BindingContext = item;
        }

        async void LoadSteps(string itemId)
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
                Console.WriteLine("Failed to load note.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (EasterSteps)BindingContext;
            if (!string.IsNullOrWhiteSpace(note.Name))
            {
                await App.EasterStepsDatabase.SaveStepsAsync(note);
            }

            Navigation.PushAsync(new EasterPage());
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (EasterSteps)BindingContext;
            await App.EasterStepsDatabase.DeleteStepsAsync(note);
            Navigation.PushAsync(new EasterPage());
        }
    }
}