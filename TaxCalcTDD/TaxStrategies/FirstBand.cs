using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class FirstBand : ITaxStrategies
    {
        public double TaxRate { get; } = 0.0;

        public BoundaryStruct Boundaries
        {
            get
            {
                BoundaryStruct boundaries = new BoundaryStruct(0, 145_000);
                return boundaries;
            }
        }

        public double CalculateTax(string value)
        {
            return 0.0;
        }

    }
}
