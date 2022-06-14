using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HW_8.Task1.entity
{
    class Appartment
    {
        #region fields
        private int number;
        private string ownerName;
        private ElectricMeterData meterData;
        #endregion

        #region constructors
        public Appartment(): this(default, default, default)
        {
        }

        public Appartment(int number, string ownerName, ElectricMeterData quarter)
        {
            this.Number = number;
            this.OwnerName = ownerName;
            this.MeterData = quarter;
        }
        #endregion

        #region properties
        public int Number { 
            get => number;
            set 
            {
                if (value<0)
                {
                    throw new Exception("Invalid appartment number");
                }
                number = value;
            } 
        }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        internal ElectricMeterData MeterData { get => meterData; set => meterData = value; }
        #endregion

        #region hw 6 part
        public double GetExpenses(double energyCost)
        {
            return (meterData.LastMeterDisplay - meterData.OriginalMeterDisplay) * energyCost;
        }

        public int GetDayQuantityAfterLastRead()
        {
            
            return (DateTime.Now - meterData.DatesOfMeterReading[^1]).Days;

        }
        #endregion

        #region overrides
        public override string ToString()
        {
            return $"{{{nameof(Number)}={Number.ToString()}, {nameof(OwnerName)}={OwnerName}}}";
        }

        public override bool Equals(object obj)
        {
            return obj is Appartment appartment &&
                   number == appartment.number &&
                   ownerName == appartment.ownerName;
        }

        #endregion
    }


}
