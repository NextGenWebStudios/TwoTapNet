using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.API.Models.Data;
using TwoTap.Core.Models;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace TwoTap.API.Models
{
    public class PurchaseInfoRequest : RequestAbstract
    {
        public class GiftCardData
        {
            public string Number { get; set; }
            public string Pin { get; set; }
        }
        public class FieldInputData
        {
            public enum eShippingOption
            {
                cheapest,
                fastest
            }

            [JsonProperty(PropertyName="addToCart")]
            public IDictionary<string, IDictionary<string, string>> AddToCart { get; set; }
            public IDictionary<string, string> NoauthCheckout { get; set; }
            public IDictionary<string, string> AuthCheckout { get; set; }
            public string Coupon { get; set; }
            public string GiftCard { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public eShippingOption? ShippingOption { get; set; }
        }

        public string CartId { get; set; }
        public IDictionary<string, FieldInputData> FieldsInput { get; set; }
        public bool TestMode { get; set; }
        public IList<string> Products { get; set; }
    }
}
