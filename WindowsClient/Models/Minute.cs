using System;
using System.Collections.ObjectModel;

namespace WindowsClient.Models
{
    public class Minute
    {
        public Minute(DateTime date)
        {
            Date = date;
        }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; }

        public string DateString => Date.ToString("d");
        public string HourString => Date.Hour.ToString();
        public string MinuteString => Date.ToString("mm");

        public ObservableCollection<Models.Voice> Items { get; } = new ObservableCollection<Voice>();
    }
}
