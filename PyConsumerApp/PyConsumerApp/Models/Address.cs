using Newtonsoft.Json;
using System;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    /// <summary>
    /// Model for address.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class Address
    {
        public int Id { get; set; }
        public int StoreCustomerId { get; set; }
        public int MerchantBranchId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }

        public string TagName { get; set; }

        public string FirstName { get; set; }

        public string PrimaryPhone { get; set; }

        public string AlternatePhone { get; set; }

        public string SocietyBuildingNo { get; set; }

        public string FlatNoDoorNo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Area { get; set; }

        public string PostalCodeZipCode { get; set; }
        /*
        public int ID { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string DoorNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string AddressType { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }*/
    }
}
