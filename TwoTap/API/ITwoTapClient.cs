using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.API.Models;

namespace TwoTap.API
{
    public interface ITwoTapClient
    {
        AddToCartResponse AddToCart(AddToCartRequest request);
        AddToCartStatusResponse AddToCartStatus(AddToCartStatusRequest request);
        PurchaseInfoResponse PurchaseInfo(PurchaseInfoRequest request);
        PurchaseInfoStatusResponse PurchaseInfoStatus(PurchaseInfoStatusRequest request);
        PurchaseConfirmResponse PurchaseConfirm(PurchaseConfirmRequest request);
        PurchaseConfirmStatusResponse PurchaseConfirmStatus(PurchaseConfirmStatusRequest request);
        FieldsInputValidateResponse FieldsInputValidate(FieldsInputValidateRequest request);
    }
}
