using TaxCalcTDD.Interfaces;
using TaxCalcTDD.TaxStrategies;

namespace TaxCalcTDD
{
    public class TaxCalculator
    {
        InputReader _inputReader;
        OutputWriter _outputWriter;
        TaxSystem taxStrategy;

        bool stillCalculating;
        double total;
        double effectiveRate;

        public TaxCalculator(InputReader reader, OutputWriter writer) { 
            _inputReader = reader;
            _outputWriter = writer;
            taxStrategy = new TaxSystem();
            stillCalculating = true;
        }

        public void Run()
        {

            while (stillCalculating)
            {
                _outputWriter.Write("\nPlease enter your region");
                string taxSystemChosen = _inputReader.Read();

                _outputWriter.Write("\nPlease input your house price");
                string purchasePrice = _inputReader.Read();

                taxStrategy.Clear();
                taxStrategy.ChooseTaxSystem(taxSystemChosen);
                taxStrategy.Calculate(purchasePrice);

                total = taxStrategy.TaxResult.Total;
                effectiveRate = taxStrategy.TaxResult.EffectiveRate;

                _outputWriter.Write($"\nYou will pay £{total} at an effective rate of {effectiveRate}%");
                _outputWriter.Write("\nWould you like to continue? Y or N");
                string response = _inputReader.Read();
                stillCalculating = response.ToLower() != "n";
            }
        }
    }
}
