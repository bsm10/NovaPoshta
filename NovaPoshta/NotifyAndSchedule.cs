using System;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;


namespace NovaPoshta
{
    public static class NotifyAndSchedule
    {
        #region Notifications
        static DispatcherTimer dispatcherTimer;
        static int timesTicked = 0;
        static int timesToTick = 10;
        static Border statusBorder;
        public static async Task NotifyUser(string strMessage, NotifyType type, Border StatusBorder, TextBlock StatusBlock, int Seconds = 0)
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

                if (Seconds != 0)
                {
                    await Task.Delay(new TimeSpan(0, 0, Seconds));
                    StatusBorder.Visibility = Visibility.Collapsed;
                    //dispatcherTimer = new DispatcherTimer();
                    //dispatcherTimer.Tick += dispatcherTimer_Tick;
                    //dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    //timesToTick = Seconds;
                    //dispatcherTimer.Start();

                }

            }
        }
        //static void dispatcherTimer_Tick(object sender, object e)
        //{
        //    if (timesTicked == timesToTick)
        //    {
        //        dispatcherTimer.Stop();
        //        statusBorder.Visibility = Visibility.Collapsed;
        //        timesTicked = 0;
        //        return;
        //    }
        //    timesTicked++;
        //}
        public enum NotifyType
        {
            StatusMessage,
            ErrorMessage
        };
        #endregion

    }

}
