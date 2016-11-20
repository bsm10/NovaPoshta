using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NovaPoshta.DataModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

        public MainPage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
#if DEBUG
            textBoxNumber.Text = "59000218034909";
            textBoxPhone.Text = "380662279723";
#endif    

        }
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
                JObject wrng = (JObject)npt.warnings[0];
                if(wrng.HasValues) throw new NotImplementedException(wrng.First.ToString());
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
            await Find(textBoxNumber.Text, textBoxPhone.Text);
            listView.DataContext = npt;
        }

        //    public class User
        //    {
        //        public User(string json)
        //        {
        //            JObject jObject = JObject.Parse(json);
        //            JToken jUser = jObject["user"];
        //            name = (string)jUser["name"];
        //            teamname = (string)jUser["teamname"];
        //            email = (string)jUser["email"];
        //            players = jUser["players"].ToArray();
        //        }

        //        public string name { get; set; }
        //        public string teamname { get; set; }
        //        public string email { get; set; }
        //        public Array players { get; set; }
        //    }

        //    // Use
        //    private void Run()
        //    {
        //        string json = @"{""user"":{""name"":""asdf"",""teamname"":""b"",""email"":""c"",""players"":[""1"",""2""]}}";
        //        User user = new User(json);

        //        Console.WriteLine("Name : " + user.name);
        //        Console.WriteLine("Teamname : " + user.teamname);
        //        Console.WriteLine("Email : " + user.email);
        //        Console.WriteLine("Players:");

        //        foreach (var player in user.players)
        //            Console.WriteLine(player);
        //    }
    }
}
