using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Models;

namespace SignalRDemo
{
    [ApiController]
    public class PushNotificationsController : ControllerBase
    {
        [HttpGet("push")]
        public async Task<IActionResult> SendNotification()
        {
            WebPushPushNotificationService pushService = new WebPushPushNotificationService();
            await pushService.SendNotificationAsync();

            return NoContent();
        }
    }
}
