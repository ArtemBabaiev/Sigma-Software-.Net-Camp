using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8.Task1.entity
{
    class Report
    {
        #region fields
        private int quarterNumber;
        List<Appartment> appartments;
        private double energyCost;
        #endregion

        #region constructors
        public Report()
        {
            quarterNumber = default;
            appartments = new List<Appartment>();
            energyCost = default;
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
        #endregion

        #region propeties
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
        #endregion

        #region hw 8 part
        public static Report operator +(Report a, Report b)
        {
            Report c = new Report();
            foreach (var item in a.Appartments)
            {
                c.AddAppartmentToReport(item);
            }
            foreach (var item in b.Appartments)
            {
                c.AddAppartmentToReport(item);
            }
            return c;
        }
        //У методах Contains<Appartment>(item) та Remove(item) використовується 
        //Equals з класу Appartment
        public static Report operator -(Report a, Report b)
        {
            Report c = new Report();
            foreach (var item in a.Appartments)
            {
                c.AddAppartmentToReport(item);
            }
            foreach (Appartment item in b.Appartments)
            {
                if (c.Appartments.Contains<Appartment>(item))
                {
                    c.Appartments.Remove(item);
                }
            }
            return c;
        }

        public void AddAppartmentToReport(Appartment appartment)
        {
            Appartments.Add(appartment);
        }
        #endregion

        #region hw 6 part
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
        #endregion


        #region overrides
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
        #endregion

    }
}
