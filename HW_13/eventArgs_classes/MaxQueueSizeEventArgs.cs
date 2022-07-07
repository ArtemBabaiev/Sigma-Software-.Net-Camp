using System;
using HW_13.entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.eventArgs_classes
{
    internal class MaxQueueSizeEventArgs
    {
        public MaxQueueSizeEventArgs(string message, CashRegister register)
        {
            Message = message;
            Register = register;
        }
        public string Message { get; }
        public CashRegister Register { get; }
    }
}
