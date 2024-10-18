using System.Text.Json;
using TaxCalcTDD.Interfaces;
using TaxCalcTDD.Bands;

namespace TaxCalcTDD.Boundaries
{
    public class Boundary
    {
        List<ITaxSystem> _taxStrategies;
        JsonBoundaryList _jsonBoundaryList;
        public double BottomBoundary { get; set; }
        public double TaxRate { get; set; }
        public Boundary()
        {
            _taxStrategies = new List<ITaxSystem>();
            _jsonBoundaryList = new JsonBoundaryList();
        }


        public List<ITaxSystem> GenerateBoundaryList(string taxSystem)
        {
            string jsonStringData = _jsonBoundaryList.GetJsonBoundariesBySystem(taxSystem);
            CreateAndPopulateBoundariesList(jsonStringData);

            return _taxStrategies;
        }
        public void CreateAndPopulateBoundariesList(string jsonString)
        {

            List<Boundary> jsonData = JsonSerializer.Deserialize<List<Boundary>>(jsonString);

            if (jsonData == null || jsonData.Count == 0)
            {
                Console.WriteLine("No data found or file is empty.");
                return;
            }


            for (int i = 0; i < jsonData.Count; i++)
            {
                Boundary current = jsonData[i];
                if (i == jsonData.Count - 1)
                {
                    _taxStrategies.Add(new TopBoundary(current.BottomBoundary, current.TaxRate));
                }
                else
                {
                    Boundary next = jsonData[i + 1];
                    _taxStrategies.Add(new MidBoundary(current.BottomBoundary, next.BottomBoundary, current.TaxRate));
                }
            }

        }

    }
}
