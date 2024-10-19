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
                        { ""Limit"": 750000, ""TaxRate"": 0.12 },
                        { ""Limit"": 145000, ""TaxRate"": 0.02 },
                        { ""Limit"": 250000, ""TaxRate"": 0.05 },
                        { ""Limit"": 325000, ""TaxRate"": 0.1 }
                    ]";

                case "wales":

                    return @"
                    [
                        { ""Limit"": 225000, ""TaxRate"": 0.06 },
                        { ""Limit"": 400000, ""TaxRate"": 0.075 },
                        { ""Limit"": 750000, ""TaxRate"": 0.1 },
                        { ""Limit"": 1500000, ""TaxRate"": 0.12 }
                    ]";
                default:
                    return null;
            }

        }
    }
}
