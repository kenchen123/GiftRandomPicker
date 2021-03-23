using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiftRandomPicker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace GiftRandomPicker.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EasterMainPage : ContentPage
    {
        private List<string> _pickedHiderNames = new List<string>();
        private List<string> _pickedHunterNames = new List<string>();

        public EasterMainPage()
        {
            InitializeComponent();
        }

        private async void NavigateToEditPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterDataListPage());
        }

        private async Task<EasterData> RandomPick(List<EasterData> data)
        {
            //var data = await App.EasterStepsDatabase.GetStepsListAsync();
            var pickedItem = data.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //var pickedItem = data.Where(x => !_pickedNames.Contains(x.Name)).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            //var pickedItem = data.Where(x => x.Name == "Weita").FirstOrDefault();
            return pickedItem;
        }


        private async void Button_Get_Hider(object sender, EventArgs e)
        {
            var data = await App.EasterStepsDatabase.GetStepsListAsync();
            if (_pickedHiderNames.Count != data.Count)
            {
                var item = await RandomPick(data);
                while (_pickedHiderNames.Contains(item.Name))
                {
                    item = await RandomPick(data);
                }
                _pickedHiderNames.Add(item.Name);
                Hider.Text = item.Name;
                Step1.Text = item.Step1;
                Step2.Text = item.Step2;
                Step3.Text = item.Step3;
                Step4.Text = item.Step4;
                Step5.Text = item.Step5;
                Step6.Text = item.Step6;
                Step7.Text = item.Step7;
                Step8.Text = item.Step8;
                Step9.Text = item.Step9;
                Step10.Text = item.Step10;
            }
        }

        private async void Button_Get_Hunter(object sender, EventArgs e)
        {
            var data = await App.EasterStepsDatabase.GetStepsListAsync();
            if (_pickedHunterNames.Count != data.Count)
            {
                var item = await RandomPick(data);
                while (item.Name == Hider.Text)
                {
                    item = await RandomPick(data);
                }
                _pickedHunterNames.Add(item.Name);
                Hunter.Text = item.Name;
            }
        }

        private void Button_Reset(object sender, EventArgs e)
        {
            _pickedHiderNames.Clear();
            _pickedHunterNames.Clear();
            Hider.Text = string.Empty;
            Hunter.Text = string.Empty;
            Step1.Text = string.Empty;
            Step2.Text = string.Empty;
            Step3.Text = string.Empty;
            Step4.Text = string.Empty;
            Step5.Text = string.Empty;
            Step6.Text = string.Empty;
            Step7.Text = string.Empty;
            Step8.Text = string.Empty;
            Step9.Text = string.Empty;
            Step10.Text = string.Empty;
        }
    }
}