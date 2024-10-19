using TaxCalcTDD;
using TaxCalcTDD.Bands;
using TaxCalcTDD.Boundaries;
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
        JsonBoundaryList boundaryList;
        TaxSystemFactory taxSystemFactory;


        [SetUp]
        public void Setup()
        {
            inputReader = new InputReader();
            outputWriter = new OutputWriter();
            taxCalc = new TaxCalculator(inputReader, outputWriter);
            taxSystem = new TaxSystem();
            boundaryList = new JsonBoundaryList();
            taxSystemFactory = new TaxSystemFactory();
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
        public void TestThatTotalIsBeingCalculated(string purchasePrice, string systemChosen, double expected)
        {

            // Act
            taxSystem.ChooseTaxSystem(systemChosen);
            taxSystem.Calculate(purchasePrice);
            double got = taxSystem.TaxResult.Total;

            // Assert
            Assert.That(got, Is.EqualTo(expected));

        }

        [TestCase("800000", "Scotland", 6.79)]
        [TestCase("146000", "Scotland", 0.01)]
        [TestCase("800000", "Wales", 5.22)]
        [TestCase("147890", "Wales", 0)]

        public void TestThatEffectiveRateValueIsBeingCalculated(string purchasePrice, string systemChosen, double expected)
        {

            // Act
            taxSystem.ChooseTaxSystem(systemChosen);
            taxSystem.Calculate(purchasePrice);
            double got = taxSystem.TaxResult.EffectiveRate;

            // Assert
            Assert.That(got, Is.EqualTo(expected));
        }

        [Test]
        public void TestThatCorrectJsonIsReturned()
        {

            // Act
            string got = boundaryList.GetJsonBoundariesBySystem("scotland");

            string expected = @"
                    [
                        { ""Limit"": 750000, ""TaxRate"": 0.12 },
                        { ""Limit"": 145000, ""TaxRate"": 0.02 },
                        { ""Limit"": 250000, ""TaxRate"": 0.05 },
                        { ""Limit"": 325000, ""TaxRate"": 0.1 }
                    ]";

            // Assert
            Assert.That(got, Is.EqualTo(expected));
        }

        [Test]
        public void TestThatJsonIsSerializedAndReturnedAsBoundaryClass()
        {
            // Arrange
            string stringJson = @"
                    [
                        { ""Limit"": 750000, ""TaxRate"": 0.12 },
                        { ""Limit"": 145000, ""TaxRate"": 0.02 },
                        { ""Limit"": 250000, ""TaxRate"": 0.05 },
                        { ""Limit"": 325000, ""TaxRate"": 0.1 }
                    ]";


            // Act
            List<Boundary> expected = new List<Boundary> {
                {new Boundary{ Limit=145000, TaxRate=0.02} },
                {new Boundary{ Limit=250000, TaxRate=0.05} },
                {new Boundary{ Limit=325000, TaxRate=0.1} },
                {new Boundary{ Limit=750000, TaxRate=0.12} }
            };

            List<Boundary> got = taxSystemFactory.SerializeJsonData(stringJson);
            

            // Assert
            Assert.That(got, Is.TypeOf(typeof(List<Boundary>)));
            Assert.That(expected, Is.TypeOf(typeof(List<Boundary>)));

            for (int i = 0; i < got.Count; i++)
            {
                Assert.That(got[i].Limit, Is.EqualTo(expected[i].Limit));
                Assert.That(got[i].TaxRate, Is.EqualTo(expected[i].TaxRate));
            }

        }

    }
}