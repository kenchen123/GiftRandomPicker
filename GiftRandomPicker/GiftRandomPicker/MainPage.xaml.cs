using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace GiftRandomPicker
{
    public partial class MainPage : ContentPage
    {
        private List<string> EmployeeList = new List<string>{"Leo","Joy","Weita","Ken","Truman","Jason","Shareena","Esther","Evan","Peggie", "Jennifer", "Sandy"} ;
        private List<int> GiftList = new List<int>{1,2,3,4,5,6,7,8,9,10,11,12};

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Pick_Name_OnClicked(object sender, EventArgs e)
        {
            EmployeeList = EmployeeList.OrderBy(x => Guid.NewGuid()).ToList();
            if (EmployeeList.Count != 0)
            {
                SetEmployeeNameFormat(EmployeeList.FirstOrDefault());
                EmployeeName.Text = EmployeeList.FirstOrDefault();
                EmployeeList.RemoveAt(0);
            }
        }

        private void Button_Pick_Gift_OnClicked(object sender, EventArgs e)
        {
            GiftList = GiftList.OrderBy(x => Guid.NewGuid()).ToList();
            if (GiftList.Count != 0)
            {
                SetGiftNumberFormat(GiftList.FirstOrDefault());
                GiftNumber.Text = GiftList.FirstOrDefault().ToString();
                GiftList.RemoveAt(0);
            }
        }

        private async void Button_Reset_OnClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Reset?", "Are you sure to reset app?", "Yes", "No");
            if (answer)
            {
                EmployeeList = new List<string> { "Leo", "Joy", "Weita", "Ken", "Truman", "Jason", "Shareena", "Esther", "Evan", "Peggie", "Jennifer", "Sandy" };
                GiftList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

                Leo.TextColor = Color.Black;
                Joy.TextColor = Color.Black;
                Weita.TextColor = Color.Black;
                Ken.TextColor = Color.Black;
                Truman.TextColor = Color.Black;
                Jason.TextColor = Color.Black;
                Shareena.TextColor = Color.Black;
                Esther.TextColor = Color.Black;
                Evan.TextColor = Color.Black;
                Peggie.TextColor = Color.Black;
                Sandy.TextColor = Color.Black;
                Jennifer.TextColor = Color.Black;
                Gift1.TextColor = Color.Black;
                Gift2.TextColor = Color.Black;
                Gift3.TextColor = Color.Black;
                Gift4.TextColor = Color.Black;
                Gift5.TextColor = Color.Black;
                Gift6.TextColor = Color.Black;
                Gift7.TextColor = Color.Black;
                Gift8.TextColor = Color.Black;
                Gift9.TextColor = Color.Black;
                Gift10.TextColor = Color.Black;
                Gift11.TextColor = Color.Black;
                Gift12.TextColor = Color.Black;
            }
        }

        private void SetGiftNumberFormat(int number)
        {
            if (number == 1)
            {
                Gift1.TextColor = Color.LightGray;
            }
            if (number == 2)
            {
                Gift2.TextColor = Color.LightGray;
            }
            if (number == 3)
            {
                Gift3.TextColor = Color.LightGray;
            }
            if (number == 4)
            {
                Gift4.TextColor = Color.LightGray;
            }
            if (number == 5)
            {
                Gift5.TextColor = Color.LightGray;
            }
            if (number == 6)
            {
                Gift6.TextColor = Color.LightGray;
            }
            if (number == 7)
            {
                Gift7.TextColor = Color.LightGray;
            }
            if (number == 8)
            {
                Gift8.TextColor = Color.LightGray;
            }
            if (number == 9)
            {
                Gift9.TextColor = Color.LightGray;
            }
            if (number == 10)
            {
                Gift10.TextColor = Color.LightGray;
            }
            if (number == 11)
            {
                Gift11.TextColor = Color.LightGray;
            }
            if (number == 12)
            {
                Gift12.TextColor = Color.LightGray;
            }
        }

        private void SetEmployeeNameFormat(string name)
        {
            if (name == "Leo")
            {
                Leo.TextColor = Color.LightGray;
            }
            if (name == "Joy")
            {
                Joy.TextColor = Color.LightGray;
            }
            if (name == "Weita")
            {
                Weita.TextColor = Color.LightGray;
            }
            if (name == "Ken")
            {
                Ken.TextColor = Color.LightGray;
            }
            if (name == "Truman")
            {
                Truman.TextColor = Color.LightGray;
            }
            if (name == "Jason")
            {
                Jason.TextColor = Color.LightGray;
            }
            if (name == "Shareena")
            {
                Shareena.TextColor = Color.LightGray;
            }
            if (name == "Esther")
            {
                Esther.TextColor = Color.LightGray;
            }
            if (name == "Evan")
            {
                Evan.TextColor = Color.LightGray;
            }
            if (name == "Peggie")
            {
                Peggie.TextColor = Color.LightGray;
            }
            if (name == "Sandy")
            {
                Sandy.TextColor = Color.LightGray;
            }
            if (name == "Jennifer")
            {
                Jennifer.TextColor = Color.LightGray;
            }
        }
    }
}
