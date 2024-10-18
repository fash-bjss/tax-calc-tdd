using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.Bands
{
    public class TopBoundary : ITaxSystem
    {
        double MinBoundary;
        double TaxRate;
        public TopBoundary(double min, double taxRate)
        {
            MinBoundary = min;
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
            convertedVal = convertedVal < MinBoundary ? 0 : convertedVal - MinBoundary;
            return convertedVal * TaxRate;
        }

        public void ChooseTaxSystem(string taxSystemName)
        {
            throw new NotImplementedException();
        }
    }
}

