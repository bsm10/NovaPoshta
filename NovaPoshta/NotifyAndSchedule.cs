using NotificationsExtensions.TileContent;
using NotificationsExtensions.ToastContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace eDay
{
    public static class NotifyAndSchedule
    {
        #region Notifications
        static DispatcherTimer dispatcherTimer;
        static int timesTicked = 0;
        static int timesToTick = 10;
        static Border statusBorder;
         
        public static void NotifyUser(string strMessage, NotifyType type, Border StatusBorder, TextBlock StatusBlock, int Seconds = 0)
        {
            statusBorder = StatusBorder;
            if (StatusBlock != null)
            {
                switch (type)
                {
                    case NotifyType.StatusMessage:
                        StatusBorder.Background = new SolidColorBrush(Colors.Green);
                        break;
                    case NotifyType.ErrorMessage:
                        StatusBorder.Background = new SolidColorBrush(Colors.Red);
                        break;
                }
                StatusBlock.Text = strMessage;
                // Collapse the StatusBlock if it has no text to conserve real estate.
                if (StatusBlock.Text != string.Empty)
                {
                    StatusBorder.Visibility = Visibility.Visible;
                }
                else
                {
                    StatusBorder.Visibility = Visibility.Collapsed;
                }
                if (Seconds!=0)
                {
                    dispatcherTimer = new DispatcherTimer();
                    dispatcherTimer.Tick += dispatcherTimer_Tick;
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    timesToTick = Seconds;
                    dispatcherTimer.Start();

                }

            }
        }
        static void dispatcherTimer_Tick(object sender, object e)
        {
            if (timesTicked == timesToTick)
            {
                dispatcherTimer.Stop();
                statusBorder.Visibility = Visibility.Collapsed;
                timesTicked = 0;
                return;
            }
            timesTicked++;
        }
        public static void ScheduleToast(string updateString, int eventID, DateTime dueTime, bool RepeatToast = false)
        {
            if (dueTime < DateTime.Now) return;
            //Random rand = new Random();
            //int idNumber = rand.Next(0, 10000000);
            // Scheduled toasts use the same toast templates as all other kinds of toasts.
            IToastText02 toastContent = ToastContentFactory.CreateToastText02();
            toastContent.TextHeading.Text = updateString;
            //toastContent.TextBodyWrap.Text = "Received: " + dueTime.ToLocalTime();

            ScheduledToastNotification toast;
            //Этот код нужен если отложить напоминайку
            if (RepeatToast == true)
            {
                toast = new ScheduledToastNotification(toastContent.GetXml(), dueTime, TimeSpan.FromSeconds(60), 5);

                // You can specify an ID so that you can manage toasts later.
                // Make sure the ID is 15 characters or less.
                //toast.Id = "Repeat" + eventID;
            }
            else
            {
                toast = new ScheduledToastNotification(toastContent.GetXml(), dueTime);
                
            }
            toast.Id = eventID.ToString();
            Everyday.listNotrfications.Add(toast.Id);
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            notifier.AddToSchedule(toast);
            //NotifyUser("Event scheduled on " + dueTime + ", a toast with ID: " + toast.Id, NotifyType.StatusMessage);
        }
        public static void UnScheduleToast(string idToast)
        {
            ToastNotifier notifier = ToastNotificationManager.CreateToastNotifier();
            IReadOnlyList<ScheduledToastNotification> scheduled = notifier.GetScheduledToastNotifications();
            var q = from ScheduledToastNotification toast in scheduled where toast.Id == idToast select toast;
            foreach (ScheduledToastNotification t in q)
            {
                notifier.RemoveFromSchedule(t);
            }
        }
        public static void ScheduleTile(string updateString, DateTime dueTime, int idNumber)
        {
            // Set up the wide tile text
            ITileWide310x150Text09 tileContent = TileContentFactory.CreateTileWide310x150Text09();
            tileContent.TextHeading.Text = updateString;
            tileContent.TextBodyWrap.Text = "Received: " + dueTime.ToLocalTime();

            // Set up square tile text
            ITileSquare150x150Text04 squareContent = TileContentFactory.CreateTileSquare150x150Text04();
            squareContent.TextBodyWrap.Text = updateString;

            tileContent.Square150x150Content = squareContent;

            // Create the notification object
            ScheduledTileNotification futureTile = new ScheduledTileNotification(tileContent.GetXml(), dueTime);
            futureTile.Id = "Tile" + idNumber;

            // Add to schedule
            // You can update a secondary tile in the same manner using CreateTileUpdaterForSecondaryTile(tileId)
            // See "Tiles" sample for more details
            TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(futureTile);
            //NotifyUser("Scheduled a tile with ID: " + futureTile.Id, NotifyType.StatusMessage);
        }
        public static void ScheduleToastWithStringManipulation(String updateString, DateTime dueTime, int idNumber)
        {
            // Scheduled toasts use the same toast templates as all other kinds of toasts.
            string toastXmlString = "<toast>"
            + "<visual version='2'>"
            + "<binding template='ToastText02'>"
            + "<text id='2'>" + updateString + "</text>"
            + "<text id='1'>" + "Received: " + dueTime.ToLocalTime() + "</text>"
            + "</binding>"
            + "</visual>"
            + "</toast>";

            Windows.Data.Xml.Dom.XmlDocument toastDOM = new Windows.Data.Xml.Dom.XmlDocument();
            try
            {
                toastDOM.LoadXml(toastXmlString);

                ScheduledToastNotification toast;
                //if (RepeatBox.IsChecked != null && (bool)RepeatBox.IsChecked)
                //{
                //    toast = new ScheduledToastNotification(toastDOM, dueTime, TimeSpan.FromSeconds(60), 5);

                //    // You can specify an ID so that you can manage toasts later.
                //    // Make sure the ID is 15 characters or less.
                //    toast.Id = "Repeat" + idNumber;
                //}
                //else
                //{
                toast = new ScheduledToastNotification(toastDOM, dueTime);
                toast.Id = "Toast" + idNumber;
                //}

                ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);
                //NotifyUser("Scheduled a toast with ID: " + toast.Id, NotifyType.StatusMessage);
            }
            catch (Exception)
            {
                //NotifyUser("Error loading the xml, check for invalid characters in the input", NotifyType.ErrorMessage);
            }
        }
        public static void ScheduleTileWithStringManipulation(String updateString, DateTime dueTime, int idNumber)
        {
            string tileXmlString = "<tile>"
                         + "<visual version='2'>"
                         + "<binding template='TileWide310x150Text09' fallback='TileWideText09'>"
                         + "<text id='1'>" + updateString + "</text>"
                         + "<text id='2'>" + "Received: " + dueTime.ToLocalTime() + "</text>"
                         + "</binding>"
                         + "<binding template='TileSquare150x150Text04' fallback='TileSquareText04'>"
                         + "<text id='1'>" + updateString + "</text>"
                         + "</binding>"
                         + "</visual>"
                         + "</tile>";

            Windows.Data.Xml.Dom.XmlDocument tileDOM = new Windows.Data.Xml.Dom.XmlDocument();
            try
            {
                tileDOM.LoadXml(tileXmlString);

                // Create the notification object
                ScheduledTileNotification futureTile = new ScheduledTileNotification(tileDOM, dueTime);
                futureTile.Id = "Tile" + idNumber;

                // Add to schedule
                // You can update a secondary tile in the same manner using CreateTileUpdaterForSecondaryTile(tileId)
                // See "Tiles" sample for more details
                TileUpdateManager.CreateTileUpdaterForApplication().AddToSchedule(futureTile);
                //NotifyUser("Scheduled a tile with ID: " + futureTile.Id, NotifyType.StatusMessage);
            }
            catch (Exception)
            {
                //NotifyUser("Error loading the xml, check for invalid characters in the input", NotifyType.ErrorMessage);
            }
        }
        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };
        #endregion

    }

}
