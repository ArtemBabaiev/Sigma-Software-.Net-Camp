using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6.Task1.entity
{
    class Report
    {
        private int quarterNumber;
        List<Appartment> appartments;
        private double energyCost;

        public Report()
        {
        }

        public Report(int quarterNumber, List<Appartment> appartments)
        {
            this.quarterNumber = quarterNumber;
            this.appartments = appartments;
            EnergyCost = default;
        }

        public Report(int quarterNumber, List<Appartment> appartments, double energyCost) : this(quarterNumber, appartments)
        {
            EnergyCost = energyCost;
        }

        public int QuarterNumber { get => quarterNumber; set => quarterNumber = value; }

        internal List<Appartment> Appartments { get => appartments; set => appartments = value; }

        public double EnergyCost
        {
            get => energyCost;
            set
            {
                if (value<0)
                {
                    throw new Exception("Energy cost cant be below zero");
                }
                energyCost = value;
            }
        }

        public string getOwnerWithLargestDebt()
        {
            if (EnergyCost == 0)
            {
                throw new Exception("Debt cant be evaluated");
            }
            Appartment appartment = appartments.OrderByDescending(app => app.GetExpenses(energyCost)).FirstOrDefault();

            return appartment.OwnerName;
        }

        public IEnumerable<Appartment> GetAppartmentWithNoUsage()
        {
            IEnumerable<Appartment> noUsage = appartments.Where(app => (app.MeterData.LastMeterDisplay - app.MeterData.OriginalMeterDisplay) == 0);
            return noUsage;
        }

        

        public override string ToString()
        {
            string apps = "[";
            for (int i = 0; i < Appartments.Count; i++)
            {
                Appartment appartment = Appartments[i];
                apps += "{" + appartment.ToString() + "}";
                if (i != Appartments.Count - 1)
                {
                    apps += ", ";
                }
                else
                {
                    apps += "]";
                }
            }
            return $"{nameof(quarterNumber)}: {quarterNumber}, {nameof(appartments)}: {apps}, {nameof(energyCost)}: {energyCost}";
        }

        
    }
}
