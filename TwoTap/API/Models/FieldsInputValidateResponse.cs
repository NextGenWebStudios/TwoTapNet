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
    public class FieldsInputValidateResponseData
    {
        public string Message { get; set; }
        public string Description { get; set; }
    }

    public class FieldsInputValidateResponse : ResponseAbstract<FieldsInputValidateResponseData>
    {
    }
}
