using TaxCalcTDD.Interfaces;
using TaxCalcTDD.Boundaries;

namespace TaxCalcTDD.TaxStrategies
{
    public class TaxSystemFactory
    {

        private List<ITaxSystem> straegyList = new List<ITaxSystem>();
        public TaxSystemFactory() { }


        public List<ITaxSystem> GenerateTaxSystem(string taxSystemName)
        {
            return straegyList = new Boundary().GenerateBoundaryList(taxSystemName);
        }
    }
}
