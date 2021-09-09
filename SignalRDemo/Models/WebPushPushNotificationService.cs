using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using WebPush;

namespace SignalRDemo.Models
{
    public class WebPushPushNotificationService
    {

        public WebPushPushNotificationService() { }

        public async Task SendNotificationAsync()
        {
            var pushEndpoint = @"https://fcm.googleapis.com/fcm/send/eDPTG3vxJlQ:APA91bHZXzb_d3RLAxisBRfW4wZP8gxmcLmkVjrodBhz32QeFWEbqXfmE9TZq3sOP89z-9gLX5aJo16-BJBSwcuAY3EgcJbR9xuxK3BWJsvORSjA3qEJy4J9GUZSIdiU4v2Oh0aXuJhK";
            var p256dh = @"BO3IFIyzUrDi4J6DtkZ365eJ2UsKPKS3fNJ8EdQZo25W6xxFBxOEoiDqpHs41oCodwvogEp69kggfwwHpMYgtmk";
            var auth = @"n0Qc-0Pv74y3vbvRl7p4PA";

            var subject = @"mailto:example@yourdomain.org";
            var publicKey = @"BLPJPmT4tq4OtPfC2SKooN6y1i7fNna9-x0Q0ic74jD4ONDu0RfwnkZvWewG9I2gw-MQKLh2dYjFVfqc2Y0PujM";
            var privateKey = @"Plu0kdvbuyOu653s5MJsxPk2KtS2rjOggqCFV65a_gw";

            var subscription = new PushSubscription(pushEndpoint, p256dh, auth);
            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            //var gcmAPIKey = @"[your key here]";

            var webPushClient = new WebPushClient();
            try
            {
                string payload = "{\"notification\":{ \"title\":\"Hola!\",\"body\":\"Saludos desde el servicio NEXCEL PUSH\",\"vibrate\":[100,50,100],\"image\":\"\",\"data\":{ \"dateOfArrival\":1630654068403,\"primaryKey\":1},\"actions\":[{ \"action\":\"explore\",\"title\":\"Go to the site\"}]}}";
                await webPushClient.SendNotificationAsync(subscription, payload, vapidDetails);
                //await webPushClient.SendNotificationAsync(subscription, "payload", gcmAPIKey);
            }
            catch (WebPushException exception)
            {
                Console.WriteLine("Http STATUS code" + exception.StatusCode);
            }
        }
    }
}
