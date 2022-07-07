using System;
using HW_13.enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_13.eventArgs_classes;

namespace HW_13.entities
{
    internal class CashRegister
    {
        private int number;
        private Position position;
        Person servedPerson; // персона яка вже розпочала роботу з касою
        PriorityQueue<Person, int> queuePersons;
        private bool isWorking;
        private bool isAccepting;

        public delegate void MaxQueueHandler(MaxQueueSizeEventArgs e);
        public event MaxQueueHandler OnMaxSizeAdding;

        public delegate void StopWorkHandler(StopWorkingEventArgs e);
        public event StopWorkHandler OnStopWorking;

        public CashRegister(int number, Position position)
        {
            this.number = number;
            this.position = position;
            queuePersons = new();
            isWorking = true;
            isAccepting = true;
        }

        public int QueueLength
        {
            get => queuePersons.Count;
        }

        public bool IsNoQueue
        {
            get => queuePersons.Count == 0;
        }

        public int Number { get => number; set => number = value; }
        internal Position Position { get => position; set => position = value; }
        internal Person ServedPerson { get => servedPerson; set => servedPerson = value; }
        public bool IsWorking
        {
            get => isWorking;
            set
            {
                if (value == false)
                {
                    isWorking = value;
                    OnStopWorking?.Invoke(new($"register number {number} stopped working", this));
                }
            }
        }

        public bool IsAccepting { get => isAccepting; set => isAccepting = value; }

        public void Enqueue(Person person)
        {
            if (isAccepting)
            {
                if (IsNoQueue && servedPerson == null)
                {//якщо черга порожня та ніхто не обслуговується ставимо людину біля каси
                    servedPerson = person;
                }
                else
                {
                    if (queuePersons.Count >= (int)Conf.MAX_QUEUE_LENGTH)
                    {
                        OnMaxSizeAdding?.Invoke(new("Cant add to this queue. Limit reached", this));
                    }
                    else
                    {
                        queuePersons.Enqueue(person, (int)person.Status);
                    }

                }
            }
        }

        public void Next()
        {
            if (queuePersons.Count != 0)
            {
                servedPerson = queuePersons.Dequeue();
            }
        }

        public Person Dequeue()
        {
            return queuePersons.Dequeue();
        }

        public Person Peek()
        {
            return queuePersons.Peek();
        }
    }
}
