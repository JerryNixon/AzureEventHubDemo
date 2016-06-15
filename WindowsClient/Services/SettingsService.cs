using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient.Services
{
    public class SettingsService
    {
        public readonly string NotificationHubPath = "s2tdemonh";
        public readonly string ConnectionString = "Endpoint=sb://s2tdemons.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=qniehIoyIbbAYQllsopTL2C8uewY0x86e9wF5Dkcl1Y=";
    }
}
