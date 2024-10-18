using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalcTDD.TaxStrategies;

namespace TaxCalcTDD
{
    public class TaxCalculator
    {
        InputReader _inputReader;
        OutputWriter _outputWriter;
        public TaxCalculator() { 
            _inputReader = new InputReader();
            _outputWriter = new OutputWriter();
        }
        public void Run()
        {
            Strategies strategies = new Strategies();

            strategies.Add(new FithBand());
            //strategies.Add(new FourthBand());
            strategies.Add(new MidBand(325_000, 750_000, 0.1));
            //strategies.Add(new ThirdBand());
            strategies.Add(new MidBand(250_000, 325_000, 0.05));
            //strategies.Add(new SecondBand());
            strategies.Add(new MidBand(145_000, 250_000, 0.02));
            strategies.Add(new FirstBand());

            bool stillCalculating = true;
            while (stillCalculating)
            {
                _outputWriter.Write("Please input your house price");
                string purchasePrice = _inputReader.Read();

                double res = strategies.CalculateTax(purchasePrice);

                _outputWriter.Write($"\nYou will pay £{res}");

                _outputWriter.Write("\nWould you like to continue? Y or N");
                string response = _inputReader.Read();

                if (response.ToLower() == "n"){ stillCalculating = false; }
            }
        }
    }
}
