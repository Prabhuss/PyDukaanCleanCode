using System;
using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models.History
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class CustomerOrders
    {
        [JsonProperty("status")]
        [DataMember(Name = "status")]

        public string Status { get; set; }

        [JsonProperty("data")]
        [DataMember(Name = "data")]

        public Data Data { get; set; }
    }
    public partial class Data
    {
        [JsonProperty("customerInvoiceData")]
        [DataMember(Name = "customerInvoiceData")]
        public CustomerInvoiceDatum[] CustomerInvoiceData { get; set; }

        [JsonProperty("invocieLineItems")]
        [DataMember(Name = "invocieLineItems")]
        public InvocieLineItem[] InvocieLineItems { get; set; }
    }

    public partial class CustomerInvoiceDatum
    {
        [JsonProperty("CustomerInvoiceId")]
        [DataMember(Name = "CustomerInvoiceId")]

        public long CustomerInvoiceId { get; set; }

        [JsonProperty("StoreCustomerId")]
        [DataMember(Name = "StoreCustomerId")]
        public long StoreCustomerId { get; set; }

        [JsonProperty("MerchantBranchId")]
        [DataMember(Name = "MerchantBranchId")]
        public long MerchantBranchId { get; set; }

        [JsonProperty("CustomerVehicleId")]
        [DataMember(Name = "CustomerVehicleId")]
        public object CustomerVehicleId { get; set; }

        [JsonProperty("PosId")]
        [DataMember(Name = "PosId")]
        public object PosId { get; set; }

        [JsonProperty("BranchId")]
        [DataMember(Name = "BranchId")]
        public object BranchId { get; set; }

        [JsonProperty("InvoiceId")]
        [DataMember(Name = "InvoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("InvoiceDate")]
        [DataMember(Name = "InvoiceDate")]
        public string InvoiceDate { get; set; }

        [JsonProperty("LabourAmount")]
        [DataMember(Name = "LabourAmount")]
        public object LabourAmount { get; set; }

        [JsonProperty("PartsAmount")]
        [DataMember(Name = "PartsAmount")]
        public object PartsAmount { get; set; }

        [JsonProperty("TotalInvoiceAmount")]
        [DataMember(Name = "TotalInvoiceAmount")]
        public double TotalInvoiceAmount { get; set; }

        [JsonProperty("DiscountAmount")]
        [DataMember(Name = "DiscountAmount")]
        public string DiscountAmount { get; set; }

        [JsonProperty("TaxAmount")]
        [DataMember(Name = "TaxAmount")]
        public double TaxAmount { get; set; }

        [JsonProperty("CouponCode")]
        [DataMember(Name = "CouponCode")]

        public object CouponCode { get; set; }

        [JsonProperty("TypeOfRoom")]
        [DataMember(Name = "TypeOfRoom")]

        public object TypeOfRoom { get; set; }

        [JsonProperty("TotalDays")]
        [DataMember(Name = "TotalDays")]

        public object TotalDays { get; set; }

        [JsonProperty("PDFPath")]
        [DataMember(Name = "PDFPath")]

        public object PdfPath { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember(Name = "CreatedDate")]

        public DateTime CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember(Name = "CreatedBy")]

        public object CreatedBy { get; set; }

        [JsonProperty("InvoiceType")]
        [DataMember(Name = "InvoiceType")]

        public string InvoiceType { get; set; }

        [JsonProperty("PayableAmount")]
        [DataMember(Name = "PayableAmount")]

        public string PayableAmount { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember(Name = "ModifiedDate")]

        public string ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember(Name = "ModifiedBy")]

        public object ModifiedBy { get; set; }

        [JsonProperty("EarnedPoints")]
        [DataMember(Name = "EarnedPoints")]

        public string EarnedPoints { get; set; }

        [JsonProperty("RedeemedPoints")]
        [DataMember(Name = "RedeemedPoints")]

        public string RedeemedPoints { get; set; }

        [JsonProperty("Deliveryboy_id")]
        [DataMember(Name = "Deliveryboy_id")]

        public string DeliveryboyId { get; set; }

        [JsonProperty("OrderStatus")]

        [DataMember(Name = "OrderStatus")]
        public string OrderStatus { get; set; }
        //[JsonProperty("PaymentMode")]
        [DataMember(Name = "PaymentMode")]
        public string PaymentMode { get; set; }

        //[JsonProperty("DeliverAddressId")]
        [DataMember(Name = "DeliverAddressId")]
        public int? DeliverAddressId { get; set; }

        [DataMember(Name = "PaymentOrderId")]
        public string PaymentOrderId { get; set; }
    }

    public partial class InvocieLineItem
    {

        [JsonProperty("CustomerInvoiceLineItemId")]
        [DataMember(Name = "CustomerInvoiceLineItemId")]

        public long CustomerInvoiceLineItemId { get; set; }

        [JsonProperty("CustomerInvoiceId")]
        [DataMember(Name = "CustomerInvoiceId")]

        public long CustomerInvoiceId { get; set; }

        [JsonProperty("MerchantBranchId")]
        [DataMember(Name = "MerchantBranchId")]

        public long MerchantBranchId { get; set; }

        [JsonProperty("ProductId")]
        [DataMember(Name = "ProductId")]

        public string ProductId { get; set; }

        [JsonProperty("ProductName")]
        [DataMember(Name = "ProductName")]

        public string ProductName { get; set; }

        [JsonProperty("UnitPrice")]
        [DataMember(Name = "UnitPrice")]

        public string UnitPrice { get; set; }

        [JsonProperty("Quantity")]
        [DataMember(Name = "Quantity")]

        public long Quantity { get; set; }

        [JsonProperty("Discount")]
        [DataMember(Name = "Discount")]

        public long? Discount { get; set; }

        [JsonProperty("UnitPriceAfterDiscount")]
        [DataMember(Name = "UnitPriceAfterDiscount")]

        public string UnitPriceAfterDiscount { get; set; }

        [JsonProperty("TotalPrice")]
        [DataMember(Name = "TotalPrice")]

        public string TotalPrice { get; set; }

        [JsonProperty("CouponCode")]
        [DataMember(Name = "CouponCode")]

        public string CouponCode { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember(Name = "CreatedDate")]

        public string CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember(Name = "CreatedBy")]

        public string CreatedBy { get; set; }

        [JsonProperty("ProductName2")]
        [DataMember(Name = "ProductName2")]
        public string ProductName2 { get; set; }

        [JsonProperty("ProductImage")]
        [DataMember(Name = "ProductImage")]
        public string ProductImage { get; set; }
    }

    public enum CouponCode { Null };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CouponCodeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CouponCodeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CouponCode) || t == typeof(CouponCode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "NULL")
            {
                return CouponCode.Null;
            }
            throw new Exception("Cannot unmarshal type CouponCode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CouponCode)untypedValue;
            if (value == CouponCode.Null)
            {
                serializer.Serialize(writer, "NULL");
                return;
            }
            throw new Exception("Cannot marshal type CouponCode");
        }

        public static readonly CouponCodeConverter Singleton = new CouponCodeConverter();
    }
}

/*using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models.History
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CustomerOrders 
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
       
    }
    public partial class Data
    {
        [JsonProperty("customerInvoiceData")]
        public CustomerInvoiceDatum[] CustomerInvoiceData { get; set; }

        [JsonProperty("invocieLineItems")]
        public InvocieLineItem[] InvocieLineItems { get; set; }
    }

    public partial class CustomerInvoiceDatum
    {
        [JsonProperty("CustomerInvoiceId")]
        public long CustomerInvoiceId { get; set; }

        [JsonProperty("StoreCustomerId")]
        public long StoreCustomerId { get; set; }

        [JsonProperty("MerchantBranchId")]
        public long MerchantBranchId { get; set; }

        [JsonProperty("CustomerVehicleId")]
        public object CustomerVehicleId { get; set; }

        [JsonProperty("PosId")]
        public object PosId { get; set; }

        [JsonProperty("BranchId")]
        public object BranchId { get; set; }

        [JsonProperty("InvoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("InvoiceDate")]
        public DateTimeOffset InvoiceDate { get; set; }

        [JsonProperty("LabourAmount")]
        public object LabourAmount { get; set; }

        [JsonProperty("PartsAmount")]
        public object PartsAmount { get; set; }

        [JsonProperty("TotalInvoiceAmount")]
        public double TotalInvoiceAmount { get; set; }

        [JsonProperty("DiscountAmount")]
        public long DiscountAmount { get; set; }

        [JsonProperty("TaxAmount")]
        public double TaxAmount { get; set; }

        [JsonProperty("CouponCode")]
        public object CouponCode { get; set; }

        [JsonProperty("TypeOfRoom")]
        public object TypeOfRoom { get; set; }

        [JsonProperty("TotalDays")]
        public object TotalDays { get; set; }

        [JsonProperty("PDFPath")]
        public object PdfPath { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        public object CreatedBy { get; set; }

        [JsonProperty("InvoiceType")]
        public string InvoiceType { get; set; }

        [JsonProperty("PayableAmount")]
        public long PayableAmount { get; set; }

        [JsonProperty("ModifiedDate")]
        public DateTimeOffset ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        public object ModifiedBy { get; set; }

        [JsonProperty("EarnedPoints")]
        public object EarnedPoints { get; set; }

        [JsonProperty("RedeemedPoints")]
        public object RedeemedPoints { get; set; }

        [JsonProperty("Deliveryboy_id")]
        public long DeliveryboyId { get; set; }

        [JsonProperty("OrderStatus")]
        public string OrderStatus { get; set; }
    }

    public partial class InvocieLineItem
    {
        [JsonProperty("CustomerInvoiceLineItemId")]
        public long CustomerInvoiceLineItemId { get; set; }

        [JsonProperty("CustomerInvoiceId")]
        public long CustomerInvoiceId { get; set; }

        [JsonProperty("MerchantBranchId")]
        public long MerchantBranchId { get; set; }

        [JsonProperty("ProductId")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public int ProductId { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("UnitPrice")]
        public long? UnitPrice { get; set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; set; }

        [JsonProperty("Discount")]
        public long? Discount { get; set; }

        [JsonProperty("UnitPriceAfterDiscount")]
        public long? UnitPriceAfterDiscount { get; set; }

        [JsonProperty("TotalPrice")]
        public long? TotalPrice { get; set; }

        [JsonProperty("CouponCode")]
        public object CouponCode { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        public object CreatedBy { get; set; }

        [JsonProperty("ProductName2")]
        public object ProductName2 { get; set; }
    }

   
}
*/
