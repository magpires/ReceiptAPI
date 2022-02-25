using Flunt.Notifications;
using System.Collections.Generic;

namespace ReceiptAPI.Dtos.Response
{
    public class ResponseDto : Notifiable<Notification>
    {
        public int StatusCode { get; private set; }
        public object Data { get; private set; }

        public ResponseDto()
        {
            StatusCode = 200;
        }

        public ResponseDto(int statusCode)
        {
            StatusCode = statusCode;
        }

        public ResponseDto(int statusCode, object data)
        {
            StatusCode = statusCode;
            Data = data;
        }

        public ResponseDto(int statusCode, Notifiable<Notification> contractNotifications)
        {
            StatusCode = statusCode;
            AddNotifications(contractNotifications);
        }

        public ResponseDto(int statusCode, List<Notification> notifications)
        {
            StatusCode = statusCode;
            notifications.ForEach(notification => AddNotification(notification));
        }

        public ResponseDto(int statusCode, Notifiable<Notification> contractNotifications, List<Notification> notifications)
        {
            StatusCode = statusCode;
            notifications.ForEach(notification => AddNotification(notification));
            AddNotifications(contractNotifications);
        }

        public ResponseDto(int statusCode, object data, Notifiable<Notification> contractNotifications)
        {
            StatusCode = statusCode;
            Data = data;
            AddNotifications(contractNotifications);
        }

        public ResponseDto(int statusCode, object data, List<Notification> notifications)
        {
            StatusCode = statusCode;
            Data = data;
            notifications.ForEach(notification => AddNotification(notification));
        }

        public ResponseDto(int statusCode, object data, Notifiable<Notification> contractNotifications, List<Notification> notifications)
        {
            StatusCode = statusCode;
            Data = data;
            notifications.ForEach(notification => AddNotification(notification));
            AddNotifications(contractNotifications);
        }
    }
}
