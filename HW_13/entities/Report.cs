using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_13.entities
{
    internal class Report
    {
        StringBuilder report;

        public Report()
        {
            this.report = new();
        }

        public void AddLine(string line)
        {
            report.AppendLine(line);
        }

        public override string? ToString()
        {
            return report.ToString();
        }
    }
}
