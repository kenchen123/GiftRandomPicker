using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftRandomPicker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EasterMainPage : ContentPage
    {
        public EasterMainPage()
        {
            InitializeComponent();
        }

        private async void NavigateToEditPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EasterDataListPage());
        }
    }
}