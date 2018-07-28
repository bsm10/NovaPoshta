using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NovaPoshta.DataModel;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Chat;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Networking.NetworkOperators;
using System.Collections.Generic;


// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NovaPoshta
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static string SERVER = "https://api.novaposhta.ua/v2.0/json/";//"https://api.novaposhta.ua/v2.0/xml/ "; 
        //"https://api.novaposhta.ua/v2.0/json/";
        private static string response;
        NPTracking npt;
        //IReadOnlyList<string> deviceAccountId = null;
        //string mobileNumber = "";
        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
            
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //GetCurrentDeviceInfo();
            textBoxPhone.Text = "+380662279723";//mobileNumber;
           
            //if (mobileNumber.Length > 12) textBoxPhone.Text = mobileNumber.Substring(0, 13);

#if DEBUG
            textBoxNumber.Text = "20450082809284";
            
#endif    
        }

        //async void GetCurrentDeviceInfo()
        //{
        //    try
        //    {
        //        deviceAccountId = MobileBroadbandAccount.AvailableNetworkAccountIds; 
        //        string accountId = null;
        //        if (deviceAccountId.Count != 0)
        //        {
        //            accountId = deviceAccountId[0];
        //        }
        //        var mobileBroadbandAccount = MobileBroadbandAccount.CreateFromNetworkAccountId(accountId);
        //        var deviceInformation = mobileBroadbandAccount.CurrentDeviceInformation;
        //        if (deviceInformation != null)
        //        {
        //            if (deviceInformation.TelephoneNumbers.Count > 0)
        //            {
        //                mobileNumber = deviceInformation.TelephoneNumbers[0];
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await NotifyAndSchedule.NotifyUser("Error:" + ex.Message, NotifyAndSchedule.NotifyType.ErrorMessage,StatusBorder,StatusBlock);
        //    }
        //}

        private async Task Find(string number, string phone)
        {
            string postData =
            "{\"modelName\":\"TrackingDocument\",\"calledMethod\":\"getStatusDocuments\",\"methodProperties\":{\"Documents\":[{\"DocumentNumber\": \"" +
            number + "\",\"Phone\":\"" + phone + "\"}]}}";

            //@"{""modelName"":""TrackingDocument"",""calledMethod"":""getStatusDocuments"",""methodProperties"":{""Documents"":[{""DocumentNumber"": ""59000218034909"",""Phone"":""380662279723""}]}}";
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage resp = await client.PostAsync(new Uri(SERVER),
                    new StringContent(postData, Encoding.UTF8, "application/json"));
                resp.EnsureSuccessStatusCode();
                response = await resp.Content.ReadAsStringAsync();
                client.Dispose();
                npt = JsonConvert.DeserializeObject<NPTracking>(response);
                if (npt.warnings.Count!=0)
                {
                    JObject wrng = (JObject)npt.warnings[0];
                    if (wrng.HasValues)
                    {
                        await NotifyAndSchedule.NotifyUser(wrng.First.ToString(), NotifyAndSchedule.NotifyType.ErrorMessage, StatusBorder, StatusBlock, 3);
                    }
                }
                //throw new NotImplementedException(wrng.First.ToString());
            }
            catch (Exception ex)
            {
                MessageDialog d = new MessageDialog(ex.Message);
                await d.ShowAsync();
            }
        }
        //@"{""modelName"": ""ScanSheet"",
        //   ""calledMethod"": ""getScanSheetList"",
        //   ""apiKey"": ""e146daad199cc7e79525b66c89661ec8""}";
        //@"{""modelName"":""TrackingDocument"",""calledMethod"":""getStatusDocuments"",""methodProperties"":{""Documents"":[{""DocumentNumber"":""59000218034909"",""Phone"":""380662279723""}]}}";


        private async void btnFind_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await NotifyAndSchedule.NotifyUser("Поиск...", NotifyAndSchedule.NotifyType.StatusMessage, StatusBorder, StatusBlock);
            await Find(textBoxNumber.Text, textBoxPhone.Text);
            listView.DataContext = npt;
            await NotifyAndSchedule.NotifyUser("", NotifyAndSchedule.NotifyType.StatusMessage, StatusBorder, StatusBlock);
        }

        private async void StatusBorder_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            await NotifyAndSchedule.NotifyUser("", NotifyAndSchedule.NotifyType.StatusMessage, StatusBorder, StatusBlock);
        }

    }
}
