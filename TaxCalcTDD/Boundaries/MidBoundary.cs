using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.Bands
{
    public class MidBoundary : ITaxSystem
    {
        double MinBoundary;
        double MaxBoundary;
        double TaxRate;
        public MidBoundary(double min, double max, double taxRate)
        {
            MinBoundary = min;
            MaxBoundary = max;
            TaxRate = taxRate;
        }

        public TaxResultStruct TaxResult => throw new NotImplementedException();

        public void CalculateEffectiveRate(double total)
        {
            throw new NotImplementedException();
        }

        public double CalculateTax(string value)
        {
            double convertedVal = double.Parse(value);
            convertedVal = Math.Clamp(convertedVal, MinBoundary, MaxBoundary) - MinBoundary;
            return convertedVal * TaxRate;
        }

        public void ChooseTaxSystem(string taxSystemName)
        {
            throw new NotImplementedException();
        }
    }
}

