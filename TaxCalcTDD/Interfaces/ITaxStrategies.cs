using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalcTDD.Interfaces
{
    public interface ITaxStrategies
    {
        public double TaxRate { get; }
        public double CalculateTax(string value);

        BoundaryStruct Boundaries { get; }
    }
}
