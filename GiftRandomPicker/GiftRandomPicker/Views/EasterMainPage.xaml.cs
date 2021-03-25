using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            EnableStepClickable();
        }

        private void EnableStepClickable()
        {
            Step1.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox1, null, checkBox2))
            });
            Step2.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox2, checkBox1, checkBox3))
            });
            Step3.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox3, checkBox2, checkBox4))
            });
            Step4.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox4, checkBox3, checkBox5))
            });
            Step5.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox5, checkBox4, checkBox6))
            });
            Step6.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox6, checkBox5, checkBox7))
            });
            Step7.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => ChangeCheckBoxStatus(checkBox7, checkBox6, null))
            });
        }

        private void ChangeCheckBoxStatus(CheckBox element, CheckBox previousElement, CheckBox nextElement)
        {
            if (previousElement is null)
            {
                if (!nextElement.IsChecked)
                {
                    element.IsChecked = !element.IsChecked;
                }
            }
            else if (nextElement is null)
            {
                element.IsChecked = !element.IsChecked;
            }
            else
            {
                if (previousElement.IsChecked && !nextElement.IsChecked)
                {
                    element.IsChecked = !element.IsChecked;
                    if (element.IsChecked)
                    {
                        previousElement.IsEnabled = false;
                    }
                }
            }
        }

        private async void NavigateToEditPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterDataListPage());
        }

        private EasterData RandomPick(IEnumerable<EasterData> data, IEnumerable<string> pickedNameList)
        {
            var pickedItem = data.Where(x => !pickedNameList.Contains(x.Name)).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            return pickedItem;
        }


        private async void GetHider(object sender, EventArgs e)
        {
            var data = await App.EasterStepsDatabase.GetStepsListAsync();
            if (_pickedHiderNames.Count != data.Count)
            {
                var item = RandomPick(data, _pickedHiderNames);
                while (_pickedHiderNames.Contains(item.Name))
                {
                    item = RandomPick(data, _pickedHiderNames);
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
                ButtonGetHider.IsEnabled = false;
                ButtonGetHunter.IsEnabled = true;

                checkBox1.IsChecked = false;
                checkBox2.IsChecked = false;
                checkBox3.IsChecked = false;
                checkBox4.IsChecked = false;
                checkBox5.IsChecked = false;
                checkBox6.IsChecked = false;
                checkBox7.IsChecked = false;
            }
        }

        private async void GetHunter(object sender, EventArgs e)
        {
            var data = await App.EasterStepsDatabase.GetStepsListAsync();
            if (_pickedHunterNames.Count != data.Count)
            {
                var item = RandomPick(data, _pickedHunterNames);
                while (item.Name == Hider.Text)
                {
                    item = RandomPick(data, _pickedHunterNames);
                }
                _pickedHunterNames.Add(item.Name);
                Hunter.Text = item.Name;

                ButtonGetHider.IsEnabled = true;
                ButtonGetHunter.IsEnabled = false;
            }
        }

        private async void Button_Reset(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Reset?", "Are you sure to reset?", "Yes", "No");
            if (answer)
            {
                _pickedHiderNames.Clear();
                _pickedHunterNames.Clear();
                ButtonGetHider.IsEnabled = true;
                ButtonGetHunter.IsEnabled = false;
                Hider.Text = string.Empty;
                Hunter.Text = string.Empty;

                Step1.Text = string.Empty;
                Step2.Text = string.Empty;
                Step3.Text = string.Empty;
                Step4.Text = string.Empty;
                Step5.Text = string.Empty;
                Step6.Text = string.Empty;
                Step7.Text = string.Empty;
            }
        }
    }
}