using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class TaxSystem : ITaxSystem
    {
        private double total;
        private double effectiveRate;
        private double purchasePrice;
        private List<ITaxSystem> straegyList = new List<ITaxSystem>();
        TaxSystemFactory taxSystemFactory = new TaxSystemFactory();

        public TaxResultStruct TaxResult
        {
            get
            {
                TaxResultStruct result = new TaxResultStruct(total, effectiveRate);
                return result;
            }
        }


        public void ChooseTaxSystem(string taxSystemName)
        {
            straegyList = taxSystemFactory.GenerateTaxSystem(taxSystemName);
        }

        public double CalculateTax(string value)
        {
            double result = 0.0;
            purchasePrice = Double.Parse(value);

            foreach (ITaxSystem taxStrategy in straegyList)
            {
                result += taxStrategy.CalculateTax(value);
            }
            total = Math.Floor(result);
            CalculateEffectiveRate(total);
            
            // Below return value could definitely be removed in future implementations
            return Math.Floor(result);
        }

        public void CalculateEffectiveRate(double total) {
            double result = (total / purchasePrice) * 100;
            effectiveRate = Math.Round(result, 2);
        }
    }
}
