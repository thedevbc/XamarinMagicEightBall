using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;

namespace MagicEightBall
{
    public partial class MagicEightBall : ContentPage
    {
        public Responses responses { get; set; }

        public MagicEightBall()
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

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
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
        }

        private async void backBtn_Pressed(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
