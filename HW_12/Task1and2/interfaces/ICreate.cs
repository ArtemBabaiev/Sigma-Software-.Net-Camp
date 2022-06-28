using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.interfaces
{
    interface ICreate<T>
    {
        public static T CreateFrom(params string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
