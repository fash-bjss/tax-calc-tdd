using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class FithBand : ITaxStrategies
    {
        public double TaxRate { get; } = 0.12;

        public BoundaryStruct Boundaries
        {
            get
            {
                BoundaryStruct boundaries = new BoundaryStruct(750_000, Int32.MaxValue);
                return boundaries;
            }
        }

        public double CalculateTax(string value)
        {
            double convertedVal = Double.Parse(value);
            convertedVal = convertedVal < Boundaries.Bottom ? 0 : convertedVal - Boundaries.Bottom;
            return convertedVal * TaxRate;
        }

    }
}
