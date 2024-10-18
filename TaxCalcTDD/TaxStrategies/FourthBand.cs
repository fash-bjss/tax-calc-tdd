using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class FourthBand :ITaxStrategies
    {
        public double TaxRate { get; } = 0.1;

        public BoundaryStruct Boundaries
        {
            get
            {
                BoundaryStruct boundaries = new BoundaryStruct(325_000, 750_000);
                return boundaries;
            }
        }

        public double CalculateTax(string value)
        {
            double convertedVal = Double.Parse(value);
            convertedVal = Math.Clamp(convertedVal, Boundaries.Bottom, Boundaries.Top) - Boundaries.Bottom;
            return convertedVal * TaxRate;
        }
    }
}
