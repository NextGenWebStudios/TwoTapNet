using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TwoTap.API.Models;
using TwoTap.Core;

namespace TwoTap.API.Impl
{
    public class TwoTapClient : APIClient, ITwoTapClient
    {
        public enum eMode
        {
            LIVE,
            DUMMY_DATA,
            FAKE_CONFIRM
        }

        protected override string GetApiUrl() 
        {
            return "https://api.twotap.com/v1.0";
        }

        private string ApiKey = null;
        protected override void AddDefaultParams(Dictionary<string, string> parms)
        {
            parms["public_token"] = ApiKey;
            switch(Mode)
            {
                case eMode.DUMMY_DATA:
                {
                    parms["test_mode"] = "dummy_data";
                    break;
                }
                case eMode.FAKE_CONFIRM:
                {
                    parms["test_mode"] = "fake_confirm";
                    break;
                }
            }
        }

        private string PrivateApiToken { get; set; }
        private eMode Mode { get; set; }

        public TwoTapClient(string apiKey, string privateApiToken, eMode mode)
        {
            ApiKey = apiKey;
            PrivateApiToken = privateApiToken;
            Mode = mode;
        }

        public AddToCartResponse AddToCart(AddToCartRequest request)
        {
            return PostSingle<AddToCartResponse>("add_to_cart", request);
        }

        public AddToCartStatusResponse AddToCartStatus(AddToCartStatusRequest request)
        {
            var parms = new Dictionary<string, string>();
            parms["cart_id"] = request.CartId;
            return GetSingle<AddToCartStatusResponse>("add_to_cart/status", parms);
        }

        public PurchaseInfoResponse PurchaseInfo(PurchaseInfoRequest request)
        {
            return PostSingle<PurchaseInfoResponse>("purchase_info", request);
        }

        public PurchaseInfoStatusResponse PurchaseInfoStatus(PurchaseInfoStatusRequest request)
        {
            var parms = new Dictionary<string, string>();
            parms["purchase_id"] = request.PurchaseId;
            return GetSingle<PurchaseInfoStatusResponse>("purchase_info/status", parms);
        }

        public PurchaseConfirmResponse PurchaseConfirm(PurchaseConfirmRequest request)
        {
            var parms = new Dictionary<string, string>();
            parms["private_token"] = PrivateApiToken;
            return PostSingle<PurchaseConfirmResponse>("purchase_confirm", request, parms);
        }

        public PurchaseConfirmStatusResponse PurchaseConfirmStatus(PurchaseConfirmStatusRequest request)
        {
            var parms = new Dictionary<string, string>();
            parms["purchase_id"] = request.PurchaseId;
            return GetSingle<PurchaseConfirmStatusResponse>("purchase_confirm/status", parms);
        }

        public FieldsInputValidateResponse FieldsInputValidate(FieldsInputValidateRequest request)
        {
            return PostSingle<FieldsInputValidateResponse>("fields_input_validate", request);
        }
    }
}
