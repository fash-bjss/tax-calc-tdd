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

        string filePath;
        string jsonString;
        public TaxCalculator(InputReader reader, OutputWriter writer) { 
            _inputReader = reader;
            _outputWriter = writer;
            taxStrategy = new TaxSystem();
            stillCalculating = true;

            filePath = string.Empty;
            jsonString = string.Empty;
        }
        List<ITaxSystem> dd = new List<ITaxSystem>();
        public void Run()
        {

            while (stillCalculating)
            {
                _outputWriter.Write("\nPlease enter your region");
                string taxSystemChosen = _inputReader.Read();

                _outputWriter.Write("\nPlease input your house price");
                string purchasePrice = _inputReader.Read();

                taxStrategy.ChooseTaxSystem(taxSystemChosen);
                taxStrategy.CalculateTax(purchasePrice);

                double total = taxStrategy.TaxResult.Total;
                double effectiveRate = taxStrategy.TaxResult.EffectiveRate;

                _outputWriter.Write($"\nYou will pay £{total} at an effective rate of {effectiveRate}%");

                ContinueCalculatingOrClose();
            }
        }
        public void ContinueCalculatingOrClose()
        {
            _outputWriter.Write("\nWould you like to continue? Y or N");
            string response = _inputReader.Read();
            stillCalculating = response.ToLower() != "n";
        }
    }
}
