using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class ThirdBand : ITaxStrategies
    {
        public double TaxRate { get; } = 0.05;
        public BoundaryStruct Boundaries
        {
            get
            {
                BoundaryStruct boundaries = new BoundaryStruct(250_000, 325_000);
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
