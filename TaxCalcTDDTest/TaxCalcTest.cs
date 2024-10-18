using TaxCalcTDD;
using TaxCalcTDD.Interfaces;
using TaxCalcTDD.TaxStrategies;
namespace TaxCalcTDDTest
{
    public class Tests
    {
        TaxCalculator taxCalc;
        InputReader inputReader;
        OutputWriter outputWriter;
        TaxSystem taxSystem;


        [SetUp]
        public void Setup()
        {
            inputReader = new InputReader();
            outputWriter = new OutputWriter();
            taxCalc = new TaxCalculator(inputReader, outputWriter);
            taxSystem = new TaxSystem();
        }

        [Test]
        public void TestThatWriterDisplaysWelcomeMessage() {
            // Arrange
            string welcomeMessage = "Welcome to the Tax Calculator";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            outputWriter.Write(welcomeMessage);

            // Assert
            string output = stringWriter.ToString().Trim();
            StringAssert.Contains(welcomeMessage, output);

        }

        [Test]
        public void TestThatWriterDisplaysRequestToEnterCountry()
        {
            // Arrange
            string enterCountry = "Please enter your country?";
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            outputWriter.Write(enterCountry);

            // Assert
            string output = stringWriter.ToString().Trim();
            StringAssert.Contains(enterCountry, output);
        }

        [Test]
        public void TestThatUserCanEnterText()
        {
            // Arrange
            string mockGot = "Scotland";
            StringReader stringReader = new StringReader(mockGot);
            Console.SetIn(stringReader);

            // Act
            string expected = inputReader.Read();

            // Assert
            Assert.That(mockGot, Is.EqualTo(expected));
        }

        [TestCase("800000", "Scotland", 54350.0)]
        [TestCase("147890", "Scotland", 57)]
        [TestCase("800000", "Wales", 41750)]
        [TestCase("147890", "Wales", 0)]
        public void TestThatTotalIsBeingCalculated(string purchasePrice, string countryChosen, double expected)
        {

            // Act
            taxSystem.ChooseTaxSystem(countryChosen);
            taxSystem.CalculateTax(purchasePrice);
            double got = taxSystem.TaxResult.Total;

            // Assert
            Assert.That(got, Is.EqualTo(expected));

        }

        [TestCase("800000", "Scotland", 6.79)]
        [TestCase("146000", "Scotland", 0.01)]
        [TestCase("800000", "Wales", 5.22)]
        [TestCase("147890", "Wales", 0)]

        public void TestThatEffectiveRateValueIsBeingCalculated(string purchasePrice, string countryChosen, double expected)
        {

            // Act
            taxSystem.ChooseTaxSystem(countryChosen);
            taxSystem.CalculateTax(purchasePrice);
            double got = taxSystem.TaxResult.EffectiveRate;

            // Assert
            Assert.That(got, Is.EqualTo(expected));
        }

    }
}