using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11.Task2
{
    class MyList<T> : IList<T>
    {
        List<T> lst;

        public MyList()
        {
            this.lst = new List<T>();
        }

        public MyList(List<T> lst)
        {
            this.lst = lst;
        }

        public T this[int index]
        {
            get
            {
                if (index > 0 && index < lst.Count)
                {
                    return lst[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index > 0 && index < lst.Count)
                {
                    lst[index] = value;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public int Count
        {
            get
            {
                return lst.Count;
            }
        }

        public bool IsReadOnly => ((ICollection<T>)lst).IsReadOnly;

        public void Add(T item)
        {
            if (item is not null)
            {
                lst.Add(item);
            }
            throw new ArgumentNullException();
        }

        public void Clear()
        {
            lst.Clear();
        }

        public bool Contains(T item)
        {
            return lst.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lst.CopyTo(array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return lst.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (index > 0 && index < lst.Count)
            {
                lst.Insert(index, item);
            }
            throw new IndexOutOfRangeException();
        }

        public bool Remove(T item)
        {
            return lst.Remove(item);
        }

        public void RemoveAt(int index)
        {
            if (index > 0 && index < lst.Count)
            {
                lst.RemoveAt(index);

            }
            throw new IndexOutOfRangeException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return lst.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return lst.GetEnumerator();
        }
    }
}
