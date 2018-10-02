using NUnit.Framework;

namespace FileData.Tests
{
    [TestFixture]
    public class FileSizeTests
    {
        //The 3rd party tools wrapper
        IWrapper SUT;

        string filename;
        const int minValue = 100000;
        const int maxValue = 200000;

        [SetUp]
        protected void SetUp()
        {
            SUT = new FileDetailsExtended();
            filename = "somefilename";
        }

        [Test]
        public void ValidSizeActionReturnsMinimumNumber([Values("-s", "--s", "/s", "--size")] string actionParameter)
        {
            var result = SUT.Action<int>(actionParameter, filename);
            Assert.IsTrue(result >= minValue);
        }

        [Test]
        public void ValidSizeActionReturnsMaximumNumber([Values("-s", "--s", "/s", "--size")] string actionParameter)
        {
            var result = SUT.Action<int>(actionParameter, filename);
            Assert.IsTrue(result <= maxValue);
        }

        [Test]
        public void InvalidActionReturnsDefault([Values("d", "", "++v")] string actionParameter)
        {
            var result = SUT.Action<int>(actionParameter, filename);
            Assert.AreEqual(default(int), result);
        }
    }
}