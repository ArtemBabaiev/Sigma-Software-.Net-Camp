using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_14.Task3.interfaces
{
    public interface IFood:IProduct
    {
        public DateTime ExpireDate { get; }
    }
}
