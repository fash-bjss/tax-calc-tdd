using TaxCalcTDD;
using TaxCalcTDD.Interfaces;
using TaxCalcTDD.TaxStrategies;
namespace TaxCalcTDDTest
{
    public class Tests
    {
        TaxCalculator taxCalc;
        string purchasePrice;

        [SetUp]
        public void Setup()
        {
            InputReader inputReader = new InputReader();
            taxCalc = new TaxCalculator();
            purchasePrice = "800000";

        }

        //[Test]
        //public void TestThatCalculatorRuns()
        //{
        //    // Act
        //    taxCalc.Run();

        //    // Assert
        //    Assert.Pass();

        //    // Exit after test
        //    Environment.Exit(0);
        //}

        [Test]
        public void TestThatWriterDisplaysWelcomeMessage() {
            // Arrange
            OutputWriter outputWriter = new OutputWriter();
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
            OutputWriter outputWriter = new OutputWriter();
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
            InputReader userInputReader = new InputReader();
            string mockInput = "Scotland";
            StringReader stringReader = new StringReader(mockInput);
            Console.SetIn(stringReader);

            // Act
            string expected = userInputReader.Read();

            // Assert
            Assert.That(expected, Is.EqualTo(mockInput));
        }

        [Test]
        public void TestFirstBandGivesCorrectValueForEigthHundredThousand() { 
        
            // Arrange
            ITaxStrategies firstBand = new FirstBand();

            // Act
            double expected = 0.0;
            double got = firstBand.CalculateTax(purchasePrice);

            // Assert
            Assert.That(expected, Is.EqualTo(got));
        }

        [Test]
        public void TestSecondBandGivesCorrectValueForEigthHundredThousand()
        {

            // Arrange
            ITaxStrategies secondBand = new SecondBand();

            // Act
            double expected = 2100;
            double got = secondBand.CalculateTax(purchasePrice);

            // Assert
            Assert.That(expected, Is.EqualTo(got));

        }

        [Test]
        public void TestThirdBandGivesCorrectValueForEigthHundredThousand() {
        
            // Arrange
            ITaxStrategies thirdBand = new ThirdBand();

            // Act
            double expected = 3750.0;
            double got = thirdBand.CalculateTax(purchasePrice);

            // Assert
            Assert.That(expected, Is.EqualTo(got));
        
        }

        [Test]
        public void TestFourthBandGivesCorrectValueForEigthHundredThousand()
        {
            // Arrange
            ITaxStrategies fourthBand = new FourthBand();

            // Act
            double expected = 42500;
            double got = fourthBand.CalculateTax(purchasePrice);
            
            // Assert
            Assert.That(expected, Is.EqualTo(got));

        }

        [Test]
        public void TestFithBandGivesCorrectValueForEigthHundredThousand()
        {
            // Arrange
            ITaxStrategies fithBand = new FithBand();

            // Act
            double expected = 6000;
            double got = fithBand.CalculateTax(purchasePrice);

            // Assert
            Assert.That(expected, Is.EqualTo(got));
        }

        [Test]
        public void TestStrategiesOutputCorrectResultForEigthHundredThousand()
        {
            // Arrange
            Strategies allStrategies = new Strategies();

            allStrategies.Add(new FithBand());
            allStrategies.Add(new FourthBand());
            allStrategies.Add(new ThirdBand());
            allStrategies.Add(new SecondBand());
            allStrategies.Add(new FirstBand());

            // Act
            double expected = 54350.0;
            double got = allStrategies.CalculateTax(purchasePrice);

            // Assert
            Assert.That(expected, Is.EqualTo(got));

        }

        [Test]
 
        public void TestThatTheRightValueIsReturnFor147890()
        {
            // Arrange
            Strategies allStrategies = new Strategies();

            allStrategies.Add(new FithBand());
            allStrategies.Add(new FourthBand());
            allStrategies.Add(new ThirdBand());
            allStrategies.Add(new SecondBand());
            allStrategies.Add(new FirstBand());

            // Act
            double expected = 57;
            double got = allStrategies.CalculateTax("147890");

            // Assert
            Assert.That(expected, Is.EqualTo(got));

        }

        [Test]
        public void TestThatTheRightValueIsReturnFor147890WithMidBandClass()
        {
            // Arrange
            Strategies allStrategies = new Strategies();

            allStrategies.Add(new FithBand());
            allStrategies.Add(new MidBand(325_000, 750_000, 0.1));
            allStrategies.Add(new MidBand(250_000, 325_000, 0.05));
            allStrategies.Add(new MidBand(145_000, 250_000, 0.02));
            allStrategies.Add(new FirstBand());

            // Act
            double expected = 57;
            double got = allStrategies.CalculateTax("147890");

            // Assert
            Assert.That(expected, Is.EqualTo(got));
        }

    }
}