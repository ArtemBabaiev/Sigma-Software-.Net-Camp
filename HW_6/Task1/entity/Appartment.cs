using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HW_6.Task1.entity
{
    class Appartment
    {
        private int number;
        private string ownerName;
        private ElectricMeterData meterData;

        public Appartment(): this(default, default, default)
        {
        }

        public Appartment(int number, string ownerName, ElectricMeterData quarter)
        {
            this.Number = number;
            this.OwnerName = ownerName;
            this.MeterData = quarter;
        }

        public int Number { 
            get => number;
            set 
            {
                if (value<=0)
                {
                    throw new Exception("Invalid appartment number");
                }
                number = value;
            } 
        }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        internal ElectricMeterData MeterData { get => meterData; set => meterData = value; }

        public double GetExpenses(double energyCost)
        {
            return (meterData.LastMeterDisplay - meterData.OriginalMeterDisplay) * energyCost;
        }

        public int GetDayQuantityAfterLastRead()
        {
            
            return (DateTime.Now - meterData.DatesOfMeterReading[^1]).Days;

        }

        public override string ToString()
        {
            return $"{nameof(number)}: {number}, {nameof(ownerName)}: {ownerName}, {nameof(meterData)}: {meterData}";
        }
    }


}
