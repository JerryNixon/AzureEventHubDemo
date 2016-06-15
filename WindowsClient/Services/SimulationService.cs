using System;
using System.Collections.Generic;
using Windows.UI.Xaml;

namespace WindowsClient.Services
{
    public class SimulationService
    {
        public static SimulationService Instance { get; } = new SimulationService();
        private SimulationService(int seconds = 10)
        {
            _pushService = PushService.Instance;
            _random = new Random((int)DateTime.Now.Ticks);
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(seconds) };
            _timer.Tick += (s, e) => Simulate();
        }

        DispatcherTimer _timer;
        PushService _pushService;
        static int _sampleSequenceId = 0;
        static string image = "https://raw.githubusercontent.com/Windows-XAML/Template10/master/Assets/T10%20256x256.png";
        static Random _random;

        public void Start()
        {
            _timer.Start();
            Simulate();
        }
        public void Stop() => _timer.Stop();
        private void Simulate()
        {
            _pushService.RaiseVoiceReceived(GetSampleVoice());
            _pushService.RaiseMessageReceived(GetSampleMessage());
        }

        public static Models.Message GetSampleMessage() => new Models.Message
        {
            Date = DateTime.Now,
            Title = SampleStringService.GetSentence(2, 5),
            Text = SampleStringService.GetSentence(5, 20),
            Direction = _random.Next(1, 4).Equals(2) ? Models.Directions.To : Models.Directions.From
        };

        public static Models.Voice GetSampleVoice() => new Models.Voice
        {
            Date = DateTime.Now,
            Image = image,
            Phrase = SampleStringService.GetSentence(15, 30),
            SequenceId = _sampleSequenceId++,
            Url = new Uri("http://bing.com"),
            WikiId = Guid.NewGuid().ToString()
        };

    }

    public static class SampleStringService
    {
        static string[] _text = "Lorem ipsum dolor sit amet consectetur adipiscing elit Nam porttitor velit et lobortis ultricies Curabitur non dui venenatis rutrum quam nec congue justo Phasellus euismod gravida consequat Vivamus dolor nisi tincidunt sed semper nec hendrerit elementum est Morbi eu scelerisque magna Sed efficitur ullamcorper porttitor Nunc feugiat tincidunt urna eu imperdiet neque faucibus nec Donec maximus neque mi sed volutpat justo sodales id In suscipit risus ut magna faucibus luctusSuspendisse vel consectetur magna eget lacinia anteDonec nibh nisi lobortis vel imperdiet sed euismod volutpat sapienIn eget quam leo Vestibulum sed nisi massa Nulla at odio justo Phasellus vulputate magna velit id sodales magna consequat sit amet Nulla facilisis erat massa Praesent aliquam est quis justo sollicitudin tempusDonec lacinia tincidunt elit et commodo mauris fermentum euMorbi volutpat non nunc in feugiatPhasellus rhoncus varius mauris sed tristique Nam non tellus sed leo fermentum convallis sed eu nisi Nullam id felis semper lacus accumsan porttitorMauris neque urna interdum id rutrum vitae tincidunt non miAenean et hendrerit purus non posuere exFusce aliquet in urna ut placeratSed eleifend metus urna quis gravida ipsum luctus imperdietNunc vitae lorem facilisis feugiat risus id dapibus orci Aenean quis tincidunt libero Cras vestibulum arcu non tempus consequat Ut sem arcu pretium et elementum condimentum accumsan a massaSed non cursus eros vitae iaculis semPraesent mollis elit dui a consectetur eros suscipit etAliquam dapibus non diam ac eleifend Pellentesque pulvinar eu augue elementum mollis Maecenas pulvinar lorem ac mattis accumsan odio ipsum scelerisque leo condimentum volutpat erat ex eu arcu Phasellus nec purus magna Aenean non leo ullamcorper convallis sapien eu pharetra massa Sed dapibus laoreet orci Praesent malesuada pretium lectus a condimentum ipsum dignissim nonPraesent suscipit maximus libero interdum commodo Nulla cursus lacus eros ac tristique augue porttitor laciniaNullam sapien dui faucibus vestibulum viverra nec faucibus id urnaSuspendisse purus lorem mattis a dolor eget dictum feugiat erosAliquam diam ligula rhoncus eget lacus ac maximus suscipit ipsum Duis ac odio mi Nam vel libero eu magna lacinia consequatCras luctus convallis euismod Sed ut est porttitor euismod arcu vel tempus leo Nam risus est finibus et interdum nec tincidunt et nisiPraesent finibus vel odio vel mollis Vivamus pellentesque magna neque Morbi nec rutrum libero Pellentesque feugiat pretium nisl id bibendum turpis varius in Sed interdum nunc sit amet massa luctus suscipit Pellentesque blandit interdum metus eu tempor Morbi rhoncus lacinia tempor Vestibulum consequat ullamcorper massa id sollicitudin libero consequat nonInteger sed fermentum arcu".Split(' ');
        static Random _random = new Random((int)DateTime.Now.Ticks);
        public static string GetSentence(int minWords, int maxWords)
        {
            var length = _text.Length - 1;
            var list = new List<string>();
            for (int i = 0; i < _random.Next(minWords, maxWords); i++)
            {
                list.Add(_text[_random.Next(0, length)]);
            }
            var phrase = string.Join(" ", list);
            return phrase;
        }
    }
}
