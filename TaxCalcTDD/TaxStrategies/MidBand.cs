using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class MidBand : ITaxStrategies
    {
        double MinBoundary;
        double MaxBoundary;
        double _TaxRate;
        public MidBand(double min, double max, double taxRate) {
            this.MinBoundary = min;
            this.MaxBoundary = max;
            _TaxRate = taxRate;
        }

        // Can potentially remove both TaxRate and BoundaryStruct
        public double TaxRate { get; }
        public BoundaryStruct Boundaries => throw new NotImplementedException();


        public double CalculateTax(string value)
        {
            double convertedVal = Double.Parse(value);
            convertedVal = Math.Clamp(convertedVal, MinBoundary, MaxBoundary) - MinBoundary;
            return convertedVal * _TaxRate;
        }
    }
}

