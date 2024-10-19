using TaxCalcTDD.Interfaces;
using TaxCalcTDD.Boundaries;
using System.Text.Json;
using TaxCalcTDD.Bands;

namespace TaxCalcTDD.TaxStrategies
{
    public class TaxSystemFactory
    {

        List<ITaxSystem> _taxStrategies;
        JsonBoundaryList _jsonBoundaryList;

        public TaxSystemFactory() 
        {
            _taxStrategies = new List<ITaxSystem>();
            _jsonBoundaryList = new JsonBoundaryList();
        }

        public List<ITaxSystem> GenerateTaxSystem(string taxSystemName)
        {
            string jsonStringData = _jsonBoundaryList.GetJsonBoundariesBySystem(taxSystemName);
            List<Boundary> jsonSerializedList = SerializeJsonData(jsonStringData);
            

            if (jsonSerializedList != null)
            {
                PopulateBoundariesList(jsonSerializedList);
                return _taxStrategies;
            }
            return null;
        }

        public List<Boundary> SerializeJsonData(string jsonString)
        {
            List<Boundary> jsonDataList = JsonSerializer.Deserialize<List<Boundary>>(jsonString);
            List<Boundary> sortedSerializedList = jsonDataList.OrderBy(boundary => boundary.Limit).ToList();

            if (jsonDataList == null || jsonDataList.Count == 0)
            {
                Console.WriteLine("No data found or file is empty.");
                return null;
            }

            return sortedSerializedList;
        }

        private void PopulateBoundariesList(List<Boundary> jsonDataList)
        {
            for (int i = 0; i < jsonDataList.Count; i++)
            {
                Boundary current = jsonDataList[i];
                bool lastItem = i == jsonDataList.Count - 1;
                if (lastItem)
                {
                    _taxStrategies.Add(new TopBoundary(current.Limit, current.TaxRate));
                }
                else
                {
                    Boundary next = jsonDataList[i + 1];
                    _taxStrategies.Add(new MidBoundary(current.Limit, next.Limit, current.TaxRate));
                }
            }
        }
    }
}
