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
    }
}