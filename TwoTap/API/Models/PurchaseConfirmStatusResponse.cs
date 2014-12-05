using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class PurchaseConfirmInfoResponseData
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string PurchaseId { get; set; }
    }

    public class PurchaseConfirmStatusResponse : ResponseAbstract<PurchaseConfirmInfoResponseData>
    {
    }
}
