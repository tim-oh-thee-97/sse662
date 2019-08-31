using NUnit.Framework;
using SSE662_Proj1.ViewModels;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = null;

            Assert.AreEqual(Model.SubmitCommand.CanExecute(Model.Input), false);
        }

        [Test]
        public void WrongInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "Wrong Input";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.IsNotNull(Model.ErrorText);
        }

        [Test]
        public void PositiveIntInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "15";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "15");
            Assert.AreEqual(Model.StrOutput, "fifteen");
            Assert.AreEqual(Model.RomanOutput, "XV");
            Assert.AreEqual(Model.DecOutput, "15");
            Assert.AreEqual(Model.BinOutput, "0b1111");
            Assert.AreEqual(Model.HexOutput, "0xF");
        }

        [Test]
        public void BigPositiveIntInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "123456789";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "123456789");
            Assert.AreEqual(Model.StrOutput, "one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine");
            Assert.AreEqual(Model.RomanOutput, "Number too large.");
            Assert.AreEqual(Model.DecOutput, "123456789");
            Assert.AreEqual(Model.BinOutput, "0b111010110111100110100010101");
            Assert.AreEqual(Model.HexOutput, "0x75BCD15");
        }

        [Test]
        public void NegativeIntInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "-15";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "-15");
            Assert.AreEqual(Model.StrOutput, "negative fifteen");
            Assert.AreEqual(Model.RomanOutput, "-XV");
            Assert.AreEqual(Model.DecOutput, "-15");
            Assert.AreEqual(Model.BinOutput, "0b11111111111111111111111111110001");
            Assert.AreEqual(Model.HexOutput, "0xFFFFFFF1");
        }

        [Test]
        public void BigNegativeIntInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "-123456789";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "-123456789");
            Assert.AreEqual(Model.StrOutput, "negative one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine");
            Assert.AreEqual(Model.RomanOutput, "Number too large.");
            Assert.AreEqual(Model.DecOutput, "-123456789");
            Assert.AreEqual(Model.BinOutput, "0b11111000101001000011001011101011");
            Assert.AreEqual(Model.HexOutput, "0xF8A432EB");
        }

        [Test]
        public void BinaryInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "0b10101";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "0b10101");
            Assert.AreEqual(Model.StrOutput, "twenty-one");
            Assert.AreEqual(Model.RomanOutput, "XXI");
            Assert.AreEqual(Model.DecOutput, "21");
            Assert.AreEqual(Model.BinOutput, "0b10101");
            Assert.AreEqual(Model.HexOutput, "0x15");
        }

        [Test]
        public void HexInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "0xABC";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "0xABC");
            Assert.AreEqual(Model.StrOutput, "two thousand seven hundred forty-eight");
            Assert.AreEqual(Model.RomanOutput, "MMDCCXLVIII");
            Assert.AreEqual(Model.DecOutput, "2748");
            Assert.AreEqual(Model.BinOutput, "0b101010111100");
            Assert.AreEqual(Model.HexOutput, "0xABC");
        }

        [Test]
        public void RomanInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "MCMXCVII";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "MCMXCVII");
            Assert.AreEqual(Model.StrOutput, "one thousand nine hundred ninety-seven");
            Assert.AreEqual(Model.RomanOutput, "MCMXCVII");
            Assert.AreEqual(Model.DecOutput, "1997");
            Assert.AreEqual(Model.BinOutput, "0b11111001101");
            Assert.AreEqual(Model.HexOutput, "0x7CD");
        }

        [Test]
        public void StringInputTest()
        {
            MainViewModel Model = new MainViewModel();
            Model.Input = "one hundred forty-seven";
            Model.SubmitCommand.Execute(Model.Input);

            Assert.AreEqual(Model.Input, "one hundred forty-seven");
            Assert.AreEqual(Model.StrOutput, "one hundred forty-seven");
            Assert.AreEqual(Model.RomanOutput, "CXLVII");
            Assert.AreEqual(Model.DecOutput, "147");
            Assert.AreEqual(Model.BinOutput, "0b10010011");
            Assert.AreEqual(Model.HexOutput, "0x93");
        }
    }
}