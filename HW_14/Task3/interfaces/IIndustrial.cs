using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.interfaces
{
    internal interface IIndustrial:IProduct
    {
        Dictionary<string, string> Characteristic { get; }
    }
}
