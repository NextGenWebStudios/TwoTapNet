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
    public class PurchaseInfoStatusRequest : RequestAbstract
    {
        public string PurchaseId { get; set; }
    }
}
