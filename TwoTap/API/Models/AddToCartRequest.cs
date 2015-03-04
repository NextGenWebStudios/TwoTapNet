using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Models;

namespace TwoTap.API.Models
{
    public class AddToCartRequest : RequestAbstract
    {
        public IList<string> Products { get; set; }
        public string FinishedUrl { get; set; }
    }
}
