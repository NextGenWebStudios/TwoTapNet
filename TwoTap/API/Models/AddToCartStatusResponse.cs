using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.API.Models.Data;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class StatusResponseData
    {
        public class SitesData
        {
            public class FieldData
            {
                public string FieldType { get; set; }
                public string InputName { get; set; }
                public string InputType { get; set; }
                public IList<InputValueData> InputValues { get; set; }
            }
            public class InputValueData
            {
                public IDictionary<string, IList<InputValueData>> Dep { get; set; }
                public string Value { get; set; }
                public string Text { get; set; }
            }
            public class RequiredFieldData
            {
                public object Login { get; set; }
                public IDictionary<string, GenericArrayData<FieldData>> NoauthCheckout { get; set; }
                public object AuthCheckout { get; set; }
            }
            public class ProductData
            {
                public string Image { get; set; }
                public string OriginalUrl { get; set; }
                public string Price { get; set; }
                public IList<string> RequiredFieldNames { get; set; }
                public IDictionary<string, IList<InputValueData>> RequiredFieldValues { get; set; }
                public IDictionary<string, GenericArrayData<FieldData>> RequiredFields { get; set; }
                public string Title { get; set; }
                public string Url { get; set; }
            }
            public IDictionary<string, ProductData> AddToCart { get; set; }
            public IDictionary<string, ProductData> FailedToAddToCart { get; set; }
            public RequiredFieldData RequiredFields { get; set; }
            public bool CouponSupport { get; set; }
            public bool GiftCardSupport { get; set; }
            public SiteInfoData Info { get; set; }
            public IDictionary<string, string> ShippingOptions { get; set; }
        }

        public string CartId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
        public IDictionary<string, SitesData> Sites { get; set; }
        public object StoredFieldValues { get; set; }
        public IList<string> UnknownUrls { get; set; }
    }

    public class AddToCartStatusResponse : ResponseAbstract<StatusResponseData>
    {
    }
}
