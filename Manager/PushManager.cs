using Appacitive.Sdk;
using Microsoft.Phone.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Push
{
    public class PushManager
    {
        public async static Task Init()
        {
            //register device
            await AppContext.DeviceContext.RegisterCurrentDeviceAsync();

            //add hooks for push notifications
            AppContext.DeviceContext.Notifications.HttpNotificationReceived += OnHttpNotificationReceived;
            AppContext.DeviceContext.Notifications.ShellToastNotificationReceived += OnShellToastNotificationReceived;
        }

        static void OnHttpNotificationReceived(object sender, HttpNotificationEventArgs e)
        {
            if (e.Notification == null || e.Notification.Body == null) App.ViewModel.AddRawItem("No Content");
            else
            {
                var bytes = new byte[e.Notification.Body.Length];
                e.Notification.Body.Write(bytes, 0, (int)e.Notification.Body.Length);
                App.ViewModel.AddRawItem(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
            }
        }

        static void OnShellToastNotificationReceived(object sender, NotificationEventArgs e)
        {
            if (e.Collection == null || e.Collection.Count == 0)
            {
                App.ViewModel.AddToastItem("No Content", "-");
            }
            else
            {
                string text1 = "", text2 = "", param = "";
                // Parse out the information that was part of the message.
                foreach (string key in e.Collection.Keys)
                {
                    switch (key)
                    {
                        case "wp:Text1": text1 = e.Collection[key].TrimEnd().TrimEnd(':'); break;
                        case "wp:Text2": text2 = e.Collection[key]; break;
                        case "wp:Param": param = e.Collection[key]; break;
                    }
                }
                App.ViewModel.AddToastItem(text1, text2, param);
            }
        }
    }
}
