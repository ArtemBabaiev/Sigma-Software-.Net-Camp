using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma_Software.HM_3
{
    class Pair
    {
        int number;
        int frequency;

        public Pair()
        {
        }

        public Pair(int number, int frequency)
        {
            this.Number = number;
            this.Frequency = frequency;
        }

        public int Number { get => number; set => number = value; }
        public int Frequency { get => frequency; set => frequency = value; }

        public override string ToString()
        {
            return $"number: {number}, frequency: {frequency}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj is not Pair)
            {
                return false;
            }
            Pair pair2 = (Pair)obj;
            return this.Frequency == pair2.Frequency && this.Number == pair2.Number;
        }
        public static bool operator==(Pair pair1, object obj)
        {
            return true;
        }
        public static bool operator !=(Pair pair1, object obj)
        {
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
