using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.API.Models.Data;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class PurchaseInfoStatusResponseData
    {
        public class SiteData
        {
            public enum eStatus 
            {
                still_processing,
                done,
                failed
            }
            public class PriceData
            {
                public string FinalPrice {get; set;}
                public string SalesTax {get; set;}
                public string ShippingPrice {get; set;}
                public string CouponValue { get; set; }
                public string GiftCardValue { get; set; }
            }
            public class DetailsData
            {
                public string ShippingEstimate { get; set; }
                public string ActivePaymentMethod { get; set; } // (only for authenticated checkouts)
                public string ActiveShippingAddress { get; set; } // (only for authenticated checkouts)
            }
            public SiteInfoData Info { get; set; }
            [JsonConverter(typeof(StringEnumConverter))]
            public eStatus Status { get; set; }
            public IList<string> StatusMessages { get; set; }
            public string LastMessage { get; set; }
            public double? PercentDone { get; set; }
            public PriceData EstimatedPrices { get; set; }
            public PriceData Prices { get; set; }
            public DetailsData Details { get; set; }
        }

        public class CheckoutInterfaceOptionsData
        {
            public IList<string> Products { get; set; }
        }
        public string Message { get; set; }
        public string UserId { get; set; }
        public string PurchaseId { get; set; }
        public double SessionFinishesAt { get; set; }
        public IDictionary<string, SiteData> Sites { get; set; }
        public CheckoutInterfaceOptionsData CheckoutInterfaceOptions { get; set; }
    }

    public class PurchaseInfoStatusResponse : ResponseAbstract<PurchaseInfoStatusResponseData>
    {
    }
}
