public struct BoundaryStruct
{
    public double Bottom { get; private set; }
    public double Top { get; private set; }

    public BoundaryStruct(double bottom, double top)
    {
        if (bottom >= top)
        {
            throw new ArgumentException("Bottom must be less than Top.");
        }

        Bottom = bottom;
        Top = top; 
    }

}