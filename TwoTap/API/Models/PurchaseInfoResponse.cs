using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class PurchaseInfoResponseData
    {
        public string Message { get; set; }
        public string Description { get; set; }
        public string PurchaseId { get; set; }
    }

    public class PurchaseInfoResponse : ResponseAbstract<PurchaseInfoResponseData>
    {
    }
}
