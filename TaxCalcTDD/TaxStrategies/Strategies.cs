using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.Interfaces;

namespace TaxCalcTDD.TaxStrategies
{
    public class Strategies : ITaxStrategies
    {
        private List<ITaxStrategies> straegyList = new List<ITaxStrategies>();

        public double TaxRate => throw new NotImplementedException();

        public double Boundary => throw new NotImplementedException();

        public BoundaryStruct Boundaries => throw new NotImplementedException();

        public void Add(ITaxStrategies taxStrategy)
        {
            straegyList.Add(taxStrategy);
        }

        public double CalculateTax(string value)
        {
            double result = 0.0;

            foreach (ITaxStrategies taxStrategy in straegyList)
            {
                result += taxStrategy.CalculateTax(value);
            }

            return Math.Floor(result);
        }
    }
}
