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
                new EasterData
                {
                    Name = "Leo",
                    Step1 = "Say \"I like pui pui\"",
                    Step2 = "Go to hand football",
                    Step3 = "Get a ball",
                    Step4 = "Hop to Esther's door",
                    Step5 = "Say \"I also like one piece\"",
                    Step6 = "Take a chair and slide to football",
                    Step7 = "Put back the ball",
                    Step8 = "Go to Leo' desk",
                    Step9 = "Check the calendar"
                },
                new EasterData
                {
                    Name = "Weita",
                    Step1 = "Go to badge out sensor.",
                    Step2 = "Find the first door you are looking at.",
                    Step3 = "Close the door.",
                    Step4 = "Open the door.",
                    Step5 = "Go through the door.",
                    Step6 = "Go to weita's desk.",
                    Step7 = "Open all the draws.",
                    Step8 = "Look for the egg."
                },
                new EasterData 
                {
                    Name = "Ken",
                    Step1 = "Stand up.",
                    Step2 = "Go to the door.",
                    Step3 = "Go through the door and walk 7 steps, and say \"Here I come.\"",
                    Step4 = "Turn right 270 degrees.",
                    Step5 = "Walk 2 steps, and say \"I will find you.\"",
                    Step6 = "Find a glass jar on the desk."
                },
                new EasterData
                {
                    Name = "Jason",
                    Step1 = "Walk to the front of the printer",
                    Step2 = "Turn left",
                    Step3 = "Go straight until the end",
                    Step4 = "Turn Left",
                    Step5 = "Step forward for 6 steps",
                    Step6 = "Find the egg around telephone"
                },
                new EasterData
                {
                    Name = "Shareena",
                    Step1 = "Go out of the meeting room",
                    Step2 = "Think for a few seconds as to where it was hidden",
                    Step3 = "Walk to the pantry area",
                    Step4 = "on the lower cabinets, from right to left, open the 3rd cabinet.",
                    Step5 = "Open the fridge, cool yourself",
                    Step6 = "Look inside the box of tea bags "
                },
                new EasterData
                {
                    Name = "Peggie",
                    Step1 = "Step1",
                    Step2 = "Step2",
                    Step3 = "Step3",
                    Step4 = "Step4",
                    Step5 = "Step5",
                    Step6 = "Step6",
                    Step7 = "Step7",
                    Step8 = "Step8"
                },
                new EasterData
                {
                    Name = "Sandy",
                    Step1 = "Start from the meeting room, go straight by 3 steps",
                    Step2 = "Turn left from the bar table and move 5 steps",
                    Step3 = "Jump 5 times",
                    Step4 = "Go straight and stand in front of Esther's office",
                    Step5 = "Close the door",
                    Step6 = "Turn around",
                    Step7 = "Open drawer"
                },
                new EasterData
                {
                    Name = "Esther",
                    Step1 = "Come to the office area",
                    Step2 = "Find a desk with yellow and green magnets",
                    Step3 = "Find a key under the desk phone",
                    Step4 = "Use it to open drawer",
                    Step5 = "Open the biggest one",
                    Step6 = "Find it !!"
                }
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