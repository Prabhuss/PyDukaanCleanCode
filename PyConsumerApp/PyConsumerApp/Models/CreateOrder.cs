using System;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class CreateOrder
    {
        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "access_key")]
        public string access_key { get; set; }

        [DataMember(Name = "merchant_id")]
        public int merchant_id { get; set; }

        [DataMember(Name = "orderpayment_id")]
        public string orderpayment_id { get; set; }

        /* [JsonProperty("order_details")]
         public OrderDetails OrderDetails { get; set; }*/
        [DataMember(Name = "order_details")]
        public OrderDetails order_details { get; set; }
    }
    public partial class OrderDetails
    {
        /*
        [JsonProperty("Invoice")]
        public Invoice Invoice { get; set; }

        [JsonProperty("InvoiceItem")]
        public InvoiceItem[] InvoiceItem { get; set;}

        */
        [DataMember(Name = "Invoice")]
        public Invoice Invoice { get; set; }

        [DataMember(Name = "InvoiceItem")]
        public InvoiceItem[] InvoiceItem { get; set; }
    }
    [Serializable]
    public partial class Invoice
    {
        //[JsonProperty("DiscountAmount")]
        [DataMember(Name = "DiscountAmount")]
        public double? DiscountAmount { get; set; }

        //[JsonProperty("TaxAmount")]
        [DataMember(Name = "TaxAmount")]
        public double? TaxAmount { get; set; }

        //[JsonProperty("TotalInvoiceAmount")]
        [DataMember(Name = "TotalInvoiceAmount")]
        public double? TotalInvoiceAmount { get; set; }

        //[JsonProperty("CouponCode")]
        [DataMember(Name = "CouponCode")]
        public string CouponCode { get; set; }

        //[JsonProperty("PayableAmount")]
        [DataMember(Name = "PayableAmount")]
        public double? PayableAmount { get; set; }

        //[JsonProperty("InvoiceType")]
        [DataMember(Name = "InvoiceType")]
        public string InvoiceType { get; set; }

       // [JsonProperty("OrderStatus")]
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
    [Serializable]
    public partial class InvoiceItem
    {
        //[JsonProperty("ProductId")]
        [DataMember(Name = "ProductId")]

        public int ProductId { get; set; }

        //[JsonProperty("quantity")]
        [DataMember(Name = "quantity")]

       // public int Quantity { get; set; }
        public int quantity { get; set; }

        //[JsonProperty("ProductName")]
        [DataMember(Name = "ProductName")]

        public string ProductName { get; set; }

        [DataMember(Name = "Category")]

        public string Category { get; set; }


        //[JsonProperty("UnitPrice")]

        [DataMember(Name = "UnitPrice")]

        public double? UnitPrice { get; set; }

        //[JsonProperty("Discount")]
        [DataMember(Name = "Discount")]

        public double? Discount { get; set; }

        //[JsonProperty("UnitPriceAfterDiscount")]
        [DataMember(Name = "UnitPriceAfterDiscount")]

        public double? UnitPriceAfterDiscount { get; set; }

        //[JsonProperty("TotalPrice")]
        [DataMember(Name = "TotalPrice")]
        public double? TotalPrice { get; set; }

        [DataMember(Name = "ProductImage")]
        public string ProductImage { get; set; }


    }
}
