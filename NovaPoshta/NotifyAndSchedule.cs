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
                }

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
