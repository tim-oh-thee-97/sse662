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
    }
}