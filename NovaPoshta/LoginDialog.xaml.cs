using System;
using System.Globalization;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу http://go.microsoft.com/fwlink/?LinkID=390556

namespace eDay
{
    public sealed partial class LoginDialog : ContentDialog
    {
        public string Login { get; set; }
        public string Password { get; set; }

        ///Everyday everyday;
        //public Everyday EVERYDAY { get; set; }
        public LoginDialog()
        {
            InitializeComponent();
#if DEBUG
            login.Text = "malyiy";
            password.Password = "12345";
#endif

        }



        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Login = login.Text;
            Password = password.Password;
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Application.Current.Exit();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
