using HW_12.Task1.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12.Task1.eventArgs
{
    class ExpiredEventArgs
    {
        public ExpiredEventArgs(string message, Diary diary)
        {
            Message = message;
            Diary = diary;
        }
        public string Message { get; }
        public Diary Diary { get; }
    }
}
