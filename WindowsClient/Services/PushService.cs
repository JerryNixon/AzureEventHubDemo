using Microsoft.WindowsAzure.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Common;
using Windows.Networking.PushNotifications;
using Windows.UI.Popups;

namespace WindowsClient.Services
{
    public class PushService
    {
        SettingsService _settingsService;
        public static PushService Instance { get; } = new PushService();

        private PushService()
        {
            _settingsService = new SettingsService();
        }

        public PushNotificationChannel Channel { get; private set; }

        public enum AfterActivationActions { Silent, ShowRegistration }

        public async Task InitializeAsync(AfterActivationActions action)
        {
            if (Channel != null)
            {
                throw new Exception("Already initialized");
            }

            // setup channel
            Channel = await PushNotificationChannelManager.CreatePushNotificationChannelForApplicationAsync();
            Channel.PushNotificationReceived += Channel_PushNotificationReceived;
            var hub = new NotificationHub(_settingsService.NotificationHubPath, _settingsService.ConnectionString);
            var result = await hub.RegisterNativeAsync(Channel.Uri);

            // display registration
            if (action == AfterActivationActions.ShowRegistration)
            {
                await ShowAlert(result);
            }
        }

        private static async Task ShowAlert(Registration result)
        {
            var message = "Registration failed, RegistrationId is null.";
            if (result.RegistrationId != null)
            {
                message = $"Registration successful, RegistrationId is {result.RegistrationId}.";
            }
            var dialog = new MessageDialog(message, "Registration result");
            dialog.Commands.Add(new UICommand("OK"));
            await dialog.ShowAsync();
        }

        private void Channel_PushNotificationReceived(PushNotificationChannel sender, PushNotificationReceivedEventArgs e)
        {
            if (e.NotificationType != PushNotificationType.Raw)
            {
                throw new NotSupportedException(e.NotificationType.ToString());
            }
            try
            {
                var content = e.RawNotification.Content;
                var voice = content.ToVoice();
                if (voice != null)
                {
                    RaiseVoiceReceived(voice);
                    return;
                }
                var message = content.ToMessage();
                if (message != null)
                {
                    RaiseMessageReceived(message);
                    return;
                }
                throw new Exception($"Could not serialize {content}");
            }
            catch (Exception ex)
            {
                Debugger.Break();
            }
        }

        public event TypedEventHandler<Models.Voice> VoiceReceived;
        public void RaiseVoiceReceived(Models.Voice item) => VoiceReceived?.Invoke(this, item);

        public event TypedEventHandler<Models.Message> MessageReceived;
        public void RaiseMessageReceived(Models.Message item) => MessageReceived?.Invoke(this, item);
    }

    public static class Extensions
    {
        public static Models.Voice ToVoice(this string content)
        {
            try
            {
                var json = Template10.Services.SerializationService.SerializationService.Json;
                return json.Deserialize<Models.Voice>(content);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Models.Message ToMessage(this string content)
        {
            try
            {
                var json = Template10.Services.SerializationService.SerializationService.Json;
                return json.Deserialize<Models.Message>(content);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
