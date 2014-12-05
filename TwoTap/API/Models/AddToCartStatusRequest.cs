using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class AddToCartStatusRequest : RequestAbstract
    {
        public string CartId { get; set; }
    }
}
