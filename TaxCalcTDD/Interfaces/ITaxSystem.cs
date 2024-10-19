namespace TaxCalcTDD.Interfaces
{
    public interface ITaxSystem
    {
        public void Calculate(string price);

        TaxResultStruct TaxResult { get; }
    }
}
