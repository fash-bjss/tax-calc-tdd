using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.Bands
{
    public class MidBoundary : ITaxSystem
    {
        double MinBoundary;
        double MaxBoundary;
        double TaxRate;

        private double purchasePrice;
        private double total;
        private double effectiveRate;

        public MidBoundary(double min, double max, double taxRate)
        {
            MinBoundary = min;
            MaxBoundary = max;
            TaxRate = taxRate;
        }

        public TaxResultStruct TaxResult
        {
            get
            {
                TaxResultStruct result = new TaxResultStruct(total, effectiveRate);
                return result;
            }
        }

        public void Calculate(string price)
        {
            purchasePrice = double.Parse(price);

            double convertedVal = double.Parse(price);
            convertedVal = Math.Clamp(convertedVal, MinBoundary, MaxBoundary) - MinBoundary;
            total = convertedVal * TaxRate;
            CalculateEffectiveRate(total);
        }

        public void CalculateEffectiveRate(double total)
        {
            double result = (total / purchasePrice) * 100;
            effectiveRate = result;
        }

    }
}

