using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MagicEightBall
{
    public partial class MainPage : ContentPage
    {
        public Responses responses { get; set; }

        public MainPage()
        {
            InitializeComponent();
            responses = new Responses();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(SensorSpeed.Game);
        }

        protected override void OnDisappearing()
        {
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
            base.OnDisappearing();
        }

        private async void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            await responseDisplay.FadeTo(0, 500);
            if (responses == null)
            {
                responses = new Responses();
            }

            responses.CurrentResponse = responses.GetRandomResponse();

            // prevent same response twice in a row
            if (responses.CurrentResponse == responseDisplay.Text)
            {
                responses.CurrentResponse = responses.GetRandomResponse();
            }
            
            responseDisplay.Text = responses.CurrentResponse;
            await responseDisplay.FadeTo(1, 1500);
        }

        //private async void StartBtn_Pressed(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new MagicEightBall());
        //}

    }
}
