﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using JsonCSharpClassGenerator;

namespace NovaPoshta
{

    public class Datum
    {
        public Datum(JObject obj)
        {
            this.Number = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "Number"));
            this.Redelivery = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "Redelivery"));
            this.RedeliverySum = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "RedeliverySum"));
            this.RedeliveryNum = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "RedeliveryNum"));
            this.RedeliveryPayer = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "RedeliveryPayer"));
            this.OwnerDocumentType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "OwnerDocumentType"));
            this.LastCreatedOnTheBasisDocumentType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastCreatedOnTheBasisDocumentType"));
            this.LastCreatedOnTheBasisPayerType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastCreatedOnTheBasisPayerType"));
            this.LastCreatedOnTheBasisDateTime = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastCreatedOnTheBasisDateTime"));
            this.LastTransactionStatusGM = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastTransactionStatusGM"));
            this.LastTransactionDateTimeGM = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastTransactionDateTimeGM"));
            this.DateCreated = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "DateCreated"));
            this.DocumentWeight = JsonClassHelper.ReadFloat(JsonClassHelper.GetJToken<JValue>(obj, "DocumentWeight"));
            this.CheckWeight = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "CheckWeight"));
            this.DocumentCost = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "DocumentCost"));
            this.SumBeforeCheckWeight = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "SumBeforeCheckWeight"));
            this.PayerType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "PayerType"));
            this.RecipientFullName = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "RecipientFullName"));
            this.RecipientDateTime = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "RecipientDateTime"));
            this.ScheduledDeliveryDate = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "ScheduledDeliveryDate"));
            this.PaymentMethod = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "PaymentMethod"));
            this.CargoDescriptionString = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CargoDescriptionString"));
            this.CargoType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CargoType"));
            this.CitySender = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CitySender"));
            this.CityRecipient = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CityRecipient"));
            this.WarehouseRecipient = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "WarehouseRecipient"));
            this.CounterpartyType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CounterpartyType"));
            this.AfterpaymentOnGoodsCost = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "AfterpaymentOnGoodsCost"));
            this.ServiceType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "ServiceType"));
            this.UndeliveryReasonsSubtypeDescription = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "UndeliveryReasonsSubtypeDescription"));
            this.WarehouseRecipientNumber = JsonClassHelper.ReadInteger(JsonClassHelper.GetJToken<JValue>(obj, "WarehouseRecipientNumber"));
            this.LastCreatedOnTheBasisNumber = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "LastCreatedOnTheBasisNumber"));
            this.PhoneSender = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "PhoneSender"));
            this.SenderFullNameEW = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "SenderFullNameEW"));
            this.WarehouseRecipientInternetAddressRef = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "WarehouseRecipientInternetAddressRef"));
            this.MarketplacePartnerToken = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "MarketplacePartnerToken"));
            this.ClientBarcode = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "ClientBarcode"));
            this.SenderAddress = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "SenderAddress"));
            this.CounterpartySenderDescription = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CounterpartySenderDescription"));
            this.CounterpartySenderType = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "CounterpartySenderType"));
            this.DateScan = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "DateScan"));
            this.PaymentStatus = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "PaymentStatus"));
            this.PaymentStatusDate = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "PaymentStatusDate"));
            this.AmountToPay = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "AmountToPay"));
            this.AmountPaid = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "AmountPaid"));
            this.Status = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "Status"));
            this.StatusCode = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "StatusCode"));
            this.RefEW = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "RefEW"));
            this.BackwardDeliverySubTypesServices = (IList<object>)JsonClassHelper.ReadArray<object>(JsonClassHelper.GetJToken<JArray>(obj, "BackwardDeliverySubTypesServices"), JsonClassHelper.ReadObject, typeof(IList<object>));
            this.BackwardDeliverySubTypesActions = (IList<object>)JsonClassHelper.ReadArray<object>(JsonClassHelper.GetJToken<JArray>(obj, "BackwardDeliverySubTypesActions"), JsonClassHelper.ReadObject, typeof(IList<object>));
            this.UndeliveryReasons = JsonClassHelper.ReadString(JsonClassHelper.GetJToken<JValue>(obj, "UndeliveryReasons"));
        }

        public readonly string Number;
        public readonly int Redelivery;
        public readonly int RedeliverySum;
        public readonly string RedeliveryNum;
        public readonly string RedeliveryPayer;
        public readonly string OwnerDocumentType;
        public readonly string LastCreatedOnTheBasisDocumentType;
        public readonly string LastCreatedOnTheBasisPayerType;
        public readonly string LastCreatedOnTheBasisDateTime;
        public readonly string LastTransactionStatusGM;
        public readonly string LastTransactionDateTimeGM;
        public readonly string DateCreated;
        public readonly double DocumentWeight;
        public readonly int CheckWeight;
        public readonly int DocumentCost;
        public readonly int SumBeforeCheckWeight;
        public readonly string PayerType;
        public readonly string RecipientFullName;
        public readonly string RecipientDateTime;
        public readonly string ScheduledDeliveryDate;
        public readonly string PaymentMethod;
        public readonly string CargoDescriptionString;
        public readonly string CargoType;
        public readonly string CitySender;
        public readonly string CityRecipient;
        public readonly string WarehouseRecipient;
        public readonly string CounterpartyType;
        public readonly int AfterpaymentOnGoodsCost;
        public readonly string ServiceType;
        public readonly string UndeliveryReasonsSubtypeDescription;
        public readonly int WarehouseRecipientNumber;
        public readonly string LastCreatedOnTheBasisNumber;
        public readonly string PhoneSender;
        public readonly string SenderFullNameEW;
        public readonly string WarehouseRecipientInternetAddressRef;
        public readonly string MarketplacePartnerToken;
        public readonly string ClientBarcode;
        public readonly string SenderAddress;
        public readonly string CounterpartySenderDescription;
        public readonly string CounterpartySenderType;
        public readonly string DateScan;
        public readonly string PaymentStatus;
        public readonly string PaymentStatusDate;
        public readonly string AmountToPay;
        public readonly string AmountPaid;
        public readonly string Status;
        public readonly string StatusCode;
        public readonly string RefEW;
        public readonly IList<object> BackwardDeliverySubTypesServices;
        public readonly IList<object> BackwardDeliverySubTypesActions;
        public readonly string UndeliveryReasons;
    }

}
