using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace WindowsClient.Models
{
    public class Voice : BindableBase
    {
        public int SequenceId { get; set; }
        public string WikiId { get; set; }
        public Uri Url { get; set; }
        public string Phrase { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        public string DateString => Date.ToString("dddd");
        public string HourString => Date.Hour.ToString();
        public string MinuteString => Date.ToString("mm");

        bool _IsActive = true;
        public bool IsActive { get { return _IsActive; } set { Set(ref _IsActive, value); } }
    }
}
