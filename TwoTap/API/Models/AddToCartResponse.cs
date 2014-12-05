using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class DataDef
    {
        public string CartId { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }

    public class AddToCartResponse : ResponseAbstract<DataDef>
    {
    }
}
