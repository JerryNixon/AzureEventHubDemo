using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient.Models
{
    public enum Directions : int { From = 0, To = 1 }
    public class Message
    {
        public Directions Direction { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }
}
