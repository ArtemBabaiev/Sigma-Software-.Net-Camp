using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task1.entity
{
    
    class ElectricMeterData
    {
        private double originalMeterDisplay = default;
        private double lastMeterDisplay = default;
        DateTime[] datesOfMeterReading;

        public ElectricMeterData():this(default, default, default)
        {
        }

        public ElectricMeterData(double originalMeterDisplay, double lastMeterDisplay, DateTime[] datesOfMeterReading)
        {
            OriginalMeterDisplay = originalMeterDisplay;
            LastMeterDisplay = lastMeterDisplay;
            DatesOfMeterReading = datesOfMeterReading;
        }

        public double OriginalMeterDisplay { get => originalMeterDisplay; set => originalMeterDisplay = value; }
        public double LastMeterDisplay { get => lastMeterDisplay; set => lastMeterDisplay = value; }
        public DateTime[] DatesOfMeterReading 
        { 
            get => datesOfMeterReading;
            set
            {
                if (value is null)
                {
                    throw new Exception("data error");
                }
                if (value.Length > 3)
                {
                    throw new Exception("to many Dates");
                }
                foreach (var item in value)
                {
                    if (DateTime.Compare(item, DateTime.Now) > 0)
                    {
                        throw new Exception("Meter display cant be later than now");
                    }
                }
                Array.Sort(value);
                datesOfMeterReading = value;
            }
        }

        public override string ToString()
        {
            string dates = "";
            for (int i = 0; i < DatesOfMeterReading.Length; i++)
            {
                dates += "{" + datesOfMeterReading[i].ToString("dd.MM.yyyy") + "}";
                if (i != DatesOfMeterReading.Length - 1)
                {
                    dates += ", ";
                }
                else
                {
                    dates += "]";
                }
            }
            return $"{{{nameof(OriginalMeterDisplay)}={OriginalMeterDisplay.ToString()}, {nameof(LastMeterDisplay)}={LastMeterDisplay.ToString()}, {nameof(DatesOfMeterReading)}={dates}}}";
        }


    }
}
