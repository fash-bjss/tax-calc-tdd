using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class SecondBand : ITaxStrategies
    {
        public double TaxRate { get; } = 0.02;

        public BoundaryStruct Boundaries
        {
            get
            {
                BoundaryStruct boundaries = new BoundaryStruct(145_000, 250_000);
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
