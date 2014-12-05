using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTap.Core.Helpers;

namespace TwoTap.Core.Models
{
    public class ResponseAbstract<T> : IResponseAbstract
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }

        public void HandleResult(string result)
        {
            // Convert result to object
            Data = JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings() { Formatting = Formatting.Indented, ContractResolver = new JsonLowerCaseUnderscoreContractResolver() });

            IsSuccess = Data != null;
        }
    }
}
