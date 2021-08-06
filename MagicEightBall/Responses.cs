using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace MagicEightBall
{
    public class Responses
    {
        private string[] _responses;

        [Bindable(true, BindingDirection.OneWay)]
        public string CurrentResponse { get; set; }

        public Responses()
        {
            CurrentResponse = "";
            _responses = new string[20]
            {
                "It is decidedly so.",
                "Without a doubt.",
                "As I see it, yes.",
                "Most likely.",
                "You may rely on it",
                "Outlook good.",
                "It is certain.",
                "Signs point to yes.",
                "Yes.",
                "Yes - definitely.",
                "Outlook not so good.",
                "Very doubtful.",
                "My reply is no.",
                "My sources say no.",
                "Don’t count on it.",
                "Better not tell you now.",
                "Concentrate and ask again.",
                "Reply hazy, try again.",
                "Ask again later.",
                "Can not predict now."
            };
        }

        public string GetRandomResponse()
        {
            var rand = new Random();
            int randomNum = rand.Next(100, 300);
            decimal num = Math.Floor((decimal)((randomNum / 10) - 10));
            Debug.WriteLine($"resulting random number: {num}");
            return _responses[(int)num];
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
