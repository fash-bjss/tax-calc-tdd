namespace TaxCalcTDD.Interfaces
{
    public interface ITaxSystem
    {
        public double CalculateTax(string value);
        public void CalculateEffectiveRate(double total);

        public void ChooseTaxSystem(string taxSystemName);

        TaxResultStruct TaxResult { get; }
    }
}
