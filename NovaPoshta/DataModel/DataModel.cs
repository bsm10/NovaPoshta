using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace NovaPoshta.DataModel
{
    public class Datum
    {
        public string Number { get; set; }
        public string Redelivery { get; set; }
        public string RedeliverySum { get; set; }
        public string RedeliveryNum { get; set; }
        public string RedeliveryPayer { get; set; }
        public string OwnerDocumentType { get; set; }
        public string LastCreatedOnTheBasisDocumentType { get; set; }
        public string LastCreatedOnTheBasisPayerType { get; set; }
        public string LastCreatedOnTheBasisDateTime { get; set; }
        public string LastTransactionStatusGM { get; set; }
        public string LastTransactionDateTimeGM { get; set; }
        public string DateCreated { get; set; }
        public string DocumentWeight { get; set; }
        public string CheckWeight { get; set; }
        public string DocumentCost { get; set; }
        public string SumBeforeCheckWeight { get; set; }
        public string PayerType { get; set; }
        public string RecipientFullName { get; set; }
        public string RecipientDateTime { get; set; }
        public string ScheduledDeliveryDate { get; set; }
        public string PaymentMethod { get; set; }
        public string CargoDescriptionString { get; set; }
        public string CargoType { get; set; }
        public string CitySender { get; set; }
        public string CityRecipient { get; set; }
        public string WarehouseRecipient { get; set; }
        public string CounterpartyType { get; set; }
        public string AfterpaymentOnGoodsCost { get; set; }
        public string ServiceType { get; set; }
        public string UndeliveryReasonsSubtypeDescription { get; set; }
        public string WarehouseRecipientNumber { get; set; }
        public string LastCreatedOnTheBasisNumber { get; set; }
        public string PhoneSender { get; set; }
        public string SenderFullNameEW { get; set; }
        public string WarehouseRecipientInternetAddressRef { get; set; }
        public string MarketplacePartnerToken { get; set; }
        public string ClientBarcode { get; set; }
        public string SenderAddress { get; set; }
        public string CounterpartySenderDescription { get; set; }
        public string CounterpartySenderType { get; set; }
        public string DateScan { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentStatusDate { get; set; }
        public string AmountToPay { get; set; }
        public string AmountPaid { get; set; }
        public string Status { get; set; }
        public string StatusCode { get; set; }
        public string RefEW { get; set; }
        public List<object> BackwardDeliverySubTypesServices { get; set; }
        public List<object> BackwardDeliverySubTypesActions { get; set; }
        public string UndeliveryReasons { get; set; }
        public override string ToString()
        {
            return "№" + Number + "/r/nПолучатель" + RecipientFullName;
        }
    }
    //public class Warning
    //{
    //    private List<string> ListWarnings;
    //    public Warning()
    //    {
    //        ListWarnings = new List<string>();
    //    }
    //}
    public class NPTracking
    {
        public bool success { get; set; }
        public List<Datum> data { get; set; }
        public List<object> errors { get; set; }
        public IList warnings { get; set; }
        public List<object> info { get; set; }
        public List<object> messageCodes { get; set; }
        public List<object> errorCodes { get; set; }
        public IList<string> warningCodes { get; set; }
        public List<object> infoCodes { get; set; }
        public override string ToString()
        {
            return success.ToString() + ", " + data[0].RecipientFullName;
        }
    }
    public sealed class DataModel1
    {
        public static NPTracking _dataTracking;
        public static DataModel1 _DataModel = new DataModel1();
        public static async Task GetDataAsync()
        {
            Uri dataUri = new Uri("ms-appx:///DataModel/Data.json");
            var folder = ApplicationData.Current.LocalFolder;
            try
            {

                StorageFile file = (StorageFile)await folder.TryGetItemAsync("Data.json");
                if (file == null) file = await StorageFile.GetFileFromApplicationUriAsync(dataUri);
                string jsonText = string.Empty;
                if (file != null)
                {
                    IBuffer buffer = await FileIO.ReadBufferAsync(file);
                    DataReader reader = DataReader.FromBuffer(buffer);
                    byte[] fileContent = new byte[reader.UnconsumedBufferLength];
                    reader.ReadBytes(fileContent);
                    Encoding encoding = Portable.Text.Encoding.GetEncoding(1251);
                    jsonText = encoding.GetString(fileContent, 0, fileContent.Length);
                }
                _dataTracking =
                    JsonConvert.DeserializeObject<NPTracking>(jsonText);
            }
            catch (Exception e)
            {
#if DEBUG
                MessageDialog d = new MessageDialog(e.Message + " appx:///DataModel/Data.json");
                await d.ShowAsync();
#endif
                // file not found
            }
        }
    }

}
