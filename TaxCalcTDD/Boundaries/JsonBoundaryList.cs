namespace TaxCalcTDD.Boundaries
{
    public class JsonBoundaryList
    {
        public JsonBoundaryList() { }

        public string GetJsonBoundariesBySystem(string taxSystem)
        {
            switch (taxSystem.ToLower())
            {
                case "scotland":

                    return @"
                    [
                        { ""BottomBoundary"": 145000, ""TaxRate"": 0.02 },
                        { ""BottomBoundary"": 250000, ""TaxRate"": 0.05 },
                        { ""BottomBoundary"": 325000, ""TaxRate"": 0.1 },
                        { ""BottomBoundary"": 750000, ""TaxRate"": 0.12 }
                    ]";

                case "wales":

                    return @"
                    [
                        { ""BottomBoundary"": 225000, ""TaxRate"": 0.06 },
                        { ""BottomBoundary"": 400000, ""TaxRate"": 0.075 },
                        { ""BottomBoundary"": 750000, ""TaxRate"": 0.1 },
                        { ""BottomBoundary"": 1500000, ""TaxRate"": 0.12 }
                    ]";

            }

            return "";

        }
    }
}
