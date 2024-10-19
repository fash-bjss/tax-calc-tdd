using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class TaxSystem : ITaxSystem
    {
        private double total;
        private double effectiveRate ;

        private List<ITaxSystem> straegyList;
        TaxSystemFactory taxSystemFactory;

        public TaxSystem() {
            straegyList = new List<ITaxSystem>();
            taxSystemFactory = new TaxSystemFactory();
        }

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

        public void Calculate(string value)
        {
            foreach (ITaxSystem taxSystem in straegyList)
            {
                taxSystem.Calculate(value);

                total += taxSystem.TaxResult.Total;
                effectiveRate += taxSystem.TaxResult.EffectiveRate;
            }
            total = Math.Floor(total);
            effectiveRate = Math.Round(effectiveRate, 2);
        }

        public void Clear()
        {
            straegyList.Clear();
            total = 0.0;
            effectiveRate = 0.0;
        }

    }
}
