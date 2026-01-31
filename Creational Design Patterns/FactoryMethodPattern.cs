using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Creational_Design_Patterns
{
    public class FactoryMethodPattern
    {
        public interface INotification
        {
            void Send(string message);
        }

        public class EmailNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"Email send: {message}");
            }
        }

        public class SMSNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"SMS send: {message}");
            }
        }
        public class PushNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"Push send: {message}");
            }
        }

        public class SlackNotification : INotification
        {
            public void Send(string message)
            {
                Console.WriteLine($"Slack send: {message}");
            }
        }

        public abstract class NotificationCrator
        {
            public abstract INotification CreateNotification();

            public void Send(string message)
            {
                INotification notification = CreateNotification();
                notification.Send(message);
            }
        }

        public class EmailNotificationCreator : NotificationCrator
        {
            public override INotification CreateNotification()
            {
                return new EmailNotification();
            }
        }

        public class SMSNotificationCreation : NotificationCrator
        {
            public override INotification CreateNotification()
            {
                return new SMSNotification();
            }
        }

        public class PushNotificationCreator : NotificationCrator
        {
            public override INotification CreateNotification()
            {
                return new PushNotification();
            }
        }

        public class SlackNotificationCreator : NotificationCrator
        {
            public override INotification CreateNotification()
            {
                return new SlackNotification();
            }
        }


        public class Program
        {
            //public static void Main(string[] args)
            //{
            //    NotificationCrator creator;

            //    creator = new EmailNotificationCreator();
            //    creator.Send("Mail");

            //    creator = new SMSNotificationCreation();
            //    creator.Send("SMS");

            //    creator = new PushNotificationCreator();
            //    creator.Send("Push");

            //    creator = new SlackNotificationCreator();
            //    creator.Send("Slack");

            //}
        }
    }
}
