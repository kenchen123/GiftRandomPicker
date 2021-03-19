using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GiftRandomPicker.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace GiftRandomPicker
{
    public partial class MainPage : ContentPage
    {
        private List<string> EmployeeList = new List<string> { "Leo", "Joy", "Weita", "Ken", "Truman", "Jason", "Shareena", "Esther", "Evan", "Peggie", "Jennifer", "Sandy" };
        private List<int> GiftList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        private Color PickedLabelTextColor = (Color)App.Current.Resources["PickedLabelTextColor"];

        public MainPage()
        {
            InitializeComponent();
            ButtonPickNumber.IsEnabled = false;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var records = await App.Database.GetRecordsAsync();
            if (records.Count > 0 && !string.IsNullOrWhiteSpace(records.Where(x => x.ID == 1).FirstOrDefault().Record))
            {
                LoadRecord(records.Where(x => x.ID == 1).FirstOrDefault().Record);
                if (EmployeeList.Count < GiftList.Count)
                {
                    ButtonPickName.IsEnabled = false;
                    ButtonPickNumber.IsEnabled = true;
                }
            }
        }

        private async void Button_Pick_Name_OnClicked(object sender, EventArgs e)
        {
            var task = Task.Run(() => { Thread.Sleep(1000); });

            if (EmployeeList.Count != 0)
            {
                EmployeeName.IsVisible = false;
                NameProgressBar.IsVisible = true;
                EmployeeList = EmployeeList.OrderBy(x => Guid.NewGuid()).ToList();
                await NameProgressBar.ProgressTo(0.8, 500, Easing.Linear);
                await Task.Delay(1000);
                await NameProgressBar.ProgressTo(1, 500, Easing.Linear);
                NameProgressBar.IsVisible = false;
                NameProgressBar.Progress = 0;
                EmployeeName.IsVisible = true;
                EmployeeName.Text = EmployeeList.FirstOrDefault();
                SetEmployeeNameFormat(EmployeeList.FirstOrDefault(), PickedLabelTextColor);
                EmployeeList.RemoveAt(0);
                ButtonPickName.IsEnabled = false;
                ButtonPickNumber.IsEnabled = true;
            }

            SaveRecord();
        }

        private async void Button_Pick_Gift_OnClicked(object sender, EventArgs e)
        {
            if (GiftList.Count != 0)
            {
                GiftNumber.IsVisible = false;
                NumberProgressBar.IsVisible = true;
                GiftList = GiftList.OrderBy(x => Guid.NewGuid()).ToList();
                await NumberProgressBar.ProgressTo(0.8, 500, Easing.Linear);
                await Task.Delay(1000);
                await NumberProgressBar.ProgressTo(1, 500, Easing.Linear);
                NumberProgressBar.IsVisible = false;
                NumberProgressBar.Progress = 0;
                GiftNumber.IsVisible = true;
                GiftNumber.Text = GiftList.FirstOrDefault().ToString();
                SetGiftNumberFormat(GiftList.FirstOrDefault(), PickedLabelTextColor);
                GiftList.RemoveAt(0);
                ButtonPickNumber.IsEnabled = false;
                ButtonPickName.IsEnabled = true;
            }
            SaveRecord();
        }

        private async void Button_Reset_OnClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Reset?", "Are you sure to reset app?", "Yes", "No");
            if (answer)
            {
                EmployeeList = new List<string> { "Leo", "Joy", "Weita", "Ken", "Truman", "Jason", "Shareena", "Esther", "Evan", "Peggie", "Jennifer", "Sandy" };
                GiftList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                EmployeeName.Text = string.Empty;
                GiftNumber.Text = string.Empty;
                ButtonPickNumber.IsEnabled = false;
                ButtonPickName.IsEnabled = true;

                var color = (Color)App.Current.Resources["LabelTextColor"];
                SetLabelTextColor(Leo, color);
                SetLabelTextColor(Joy, color);
                SetLabelTextColor(Weita, color);
                SetLabelTextColor(Ken, color);
                SetLabelTextColor(Truman, color);
                SetLabelTextColor(Jason, color);
                SetLabelTextColor(Shareena, color);
                SetLabelTextColor(Esther, color);
                SetLabelTextColor(Evan, color);
                SetLabelTextColor(Peggie, color);
                SetLabelTextColor(Sandy, color);
                SetLabelTextColor(Jennifer, color);

                SetLabelTextColor(Gift1, color);
                SetLabelTextColor(Gift2, color);
                SetLabelTextColor(Gift3, color);
                SetLabelTextColor(Gift4, color);
                SetLabelTextColor(Gift5, color);
                SetLabelTextColor(Gift6, color);
                SetLabelTextColor(Gift7, color);
                SetLabelTextColor(Gift8, color);
                SetLabelTextColor(Gift9, color);
                SetLabelTextColor(Gift10, color);
                SetLabelTextColor(Gift11, color);
                SetLabelTextColor(Gift12, color);
            }
        }

        private void SetGiftNumberFormat(int number, Color color)
        {
            if (number == 1)
            {
                SetLabelTextColor(Gift1, color);
            }
            if (number == 2)
            {
                SetLabelTextColor(Gift2, color);
            }
            if (number == 3)
            {
                SetLabelTextColor(Gift3, color);
            }
            if (number == 4)
            {
                SetLabelTextColor(Gift4, color);
            }
            if (number == 5)
            {
                SetLabelTextColor(Gift5, color);
            }
            if (number == 6)
            {
                SetLabelTextColor(Gift6, color);
            }
            if (number == 7)
            {
                SetLabelTextColor(Gift7, color);
            }
            if (number == 8)
            {
                SetLabelTextColor(Gift8, color);
            }
            if (number == 9)
            {
                SetLabelTextColor(Gift9, color);
            }
            if (number == 10)
            {
                SetLabelTextColor(Gift10, color);
            }
            if (number == 11)
            {
                SetLabelTextColor(Gift11, color);
            }
            if (number == 12)
            {
                SetLabelTextColor(Gift12, color);
            }
        }

        private void SetEmployeeNameFormat(string name, Color color)
        {
            if (name == "Leo")
            {
                SetLabelTextColor(Leo, color);
            }
            if (name == "Joy")
            {
                SetLabelTextColor(Joy, color);
            }
            if (name == "Weita")
            {
                SetLabelTextColor(Weita, color);
            }
            if (name == "Ken")
            {
                SetLabelTextColor(Ken, color);
            }
            if (name == "Truman")
            {
                SetLabelTextColor(Truman, color);
            }
            if (name == "Jason")
            {
                SetLabelTextColor(Jason, color);
            }
            if (name == "Shareena")
            {
                SetLabelTextColor(Shareena, color);
            }
            if (name == "Esther")
            {
                SetLabelTextColor(Esther, color);
            }
            if (name == "Evan")
            {
                SetLabelTextColor(Evan, color);
            }
            if (name == "Peggie")
            {
                SetLabelTextColor(Peggie, color);
            }
            if (name == "Sandy")
            {
                SetLabelTextColor(Sandy, color);
            }
            if (name == "Jennifer")
            {
                SetLabelTextColor(Jennifer, color);
            }
        }

        private void SetLabelTextColor(Label label, Color color)
        {
            label.TextColor = color;
        }

        async Task SaveRecord()
        {
            var record = new Record()
            {
                CurrentName = EmployeeName.Text,
                CurrentGiftNumber = GiftNumber.Text,
                Employees = EmployeeList,
                Gifts = GiftList
            };

            var recordTable = new RecordTable()
            {
                ID = 1,
                Record = JsonConvert.SerializeObject(record),
                TimeStamp = DateTime.Now
            };

            await App.Database.SaveRecordAsync(recordTable);
        }

        private void LoadRecord(string text)
        {
            var record = JsonConvert.DeserializeObject<Record>(text);

            var names = EmployeeList.Except(record.Employees).ToList();
            foreach (var name in names)
            {
                SetEmployeeNameFormat(name, PickedLabelTextColor);
                EmployeeList.Remove(name);
            }

            var gifts = GiftList.Except(record.Gifts).ToList();
            foreach (var gift in gifts)
            {
                SetGiftNumberFormat(gift, PickedLabelTextColor);
                GiftList.Remove(gift);
            }

            EmployeeName.Text = record.CurrentName;
            GiftNumber.Text = record.CurrentGiftNumber;
            Console.WriteLine($"EmployeeList: {EmployeeList} \nGiftList: {GiftList}");
        }
    }
}
