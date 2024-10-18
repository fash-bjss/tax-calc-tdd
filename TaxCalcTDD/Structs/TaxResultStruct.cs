public struct TaxResultStruct
{
    public double EffectiveRate { get; private set; }
    public double Total { get; private set; }

    public TaxResultStruct(double total, double effectiveRate)
    {
        Total = total;
        EffectiveRate = effectiveRate;
        
    }

}