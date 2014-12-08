using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTap.API.Models.Data
{
    public class GenericArrayData<T>
    {
        public IList<T> Data { get; set; }

        public GenericArrayData()
        {

        }

        public GenericArrayData(T data)
        {
            Data = new List<T>();
            Data.Add(data);
        }
    }
}
