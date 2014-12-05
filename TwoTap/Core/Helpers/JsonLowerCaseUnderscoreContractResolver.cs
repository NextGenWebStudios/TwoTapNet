using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TwoTap.Core.Helpers
{
    internal class JsonLowerCaseUnderscoreContractResolver : DefaultContractResolver
    {
        private Regex regex = new Regex("(?!(^[A-Z]))([A-Z])");

        protected override string ResolvePropertyName(string propertyName)
        {
            // HACKS
            if (propertyName == "NoauthCheckout")
            {
                return "noauthCheckout";
            }
            else if (propertyName == "AuthCheckout")
            {
                return "authCheckout";
            }
            else if(char.IsLower(propertyName[0]))
            {
                return propertyName;
            }
            return regex.Replace(propertyName, "_$2").ToLower();
        }
    }
}
