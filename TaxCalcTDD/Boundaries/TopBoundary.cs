using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.Bands
{
    public class TopBoundary : ITaxSystem
    {
        double MinBoundary;
        double TaxRate;

        private double purchasePrice;
        private double total;
        private double effectiveRate;

        public TopBoundary(double min, double taxRate)
        {
            MinBoundary = min;
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
            convertedVal = convertedVal < MinBoundary ? 0 : convertedVal - MinBoundary;
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

