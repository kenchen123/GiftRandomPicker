using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GiftRandomPicker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPopup : PopupPage
    {
        float maxValue = 1;
        float progressmax = 1;
        bool istimerRunning = true;
        float progress = 0;
        int counter = 1;
        public ProgressBarPopup()
        {
            InitializeComponent();

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (progress >= 1)
                {
                    istimerRunning = false;
                    Navigation.PopPopupAsync();
                }
                else
                {
                    progress += maxValue / progressmax;
                    progressbar.ProgressTo(progress, 500, Easing.Linear);
                    progressLabel.Text = $"{progress*100}%";
                    counter += 1;
                }

                return istimerRunning;
            });
        }
    }
}