using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Template10.Utils;

namespace WindowsClient.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        Services.PushService _pushService;

        public MainPageViewModel()
        {
            Enumerable.Range(0, 10).ForEach(m => AddMinute(DateTime.Now.AddMinutes(-10 + m)));
            if (true | Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // sample data
                var random = new Random((int)DateTime.Now.Ticks);
                foreach (var minute in Minutes)
                {
                    foreach (var item in Enumerable.Range(0, random.Next(1, 5)))
                    {
                        minute.Items.Add(Services.SimulationService.GetSampleVoice());
                    }
                }
                Enumerable.Range(1, 15).ForEach(x => AddMessage(Services.SimulationService.GetSampleMessage()));
            }

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(30) };
            timer.Tick += (s, e) => AddMinute(DateTime.Now);
            timer.Start();

            _pushService = Services.PushService.Instance;
            _pushService.VoiceReceived += (s, e) => { if (IsEnabled) AddVoice(e); };
            _pushService.MessageReceived += (s, e) => { AddMessage(e); };
            Services.SimulationService.Instance.Start();
        }

        private void AddMessage(Models.Message message)
        {
            Messages.Add(message);
        }

        private void AddMinute(DateTime date)
        {
            if (Minutes.Any(x => x.Date.Minute.Equals(date.Minute)))
            {
                return;
            }
            Minutes.Insert(0, new Models.Minute(date));
            foreach (var item in Minutes.Skip(10).ToArray())
            {
                Minutes.Remove(item);
            }
        }

        private void AddVoice(Models.Voice voice)
        {
            if (Minutes.SelectMany(x => x.Items).Any(x => x.Date.Equals(voice.Date)))
            {
                throw new Exception("Item already in list.");
            }
            foreach (var item in Minutes.SelectMany(x => x.Items).Where(x => x.IsActive))
            {
                item.IsActive = false;
            }
            if (!Minutes.Any(x => x.Date.Minute.Equals(voice.Date.Minute)))
            {
                AddMinute(voice.Date);
            }
            var minute = Minutes.First(x => x.Date.Minute.Equals(voice.Date.Minute));
            minute.Items.Add(voice);
        }

        public ObservableCollection<Models.Minute> Minutes { get; } = new ObservableCollection<Models.Minute>();
        public ObservableCollection<Models.Message> Messages { get; } = new ObservableCollection<Models.Message>();

        bool _IsEnabled = true;
        public bool IsEnabled { get { return _IsEnabled; } set { Set(ref _IsEnabled, value); } }
    }
}

