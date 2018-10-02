using NUnit.Framework;

namespace FileData.Tests
{
    [TestFixture]
    public class FileVersionTests
    {
        //The 3rd party tools wrapper
        IWrapper SUT;

        string filename;

        [SetUp]
        protected void SetUp()
        {
            SUT = new FileDetailsExtended();
            filename = "somefilename";
        }

        [Test]
        public void ValidVersionActionReturnsValidString([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = SUT.Action<string>(actionParameter, filename);
            Assert.AreNotEqual(default(string), result); 
        }

        [Test]
        public void ValidVersionActionReturnsMinimumStringLength([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = SUT.Action<string>(actionParameter, filename);
            Assert.IsTrue(result.Length > 4);
        }
        [Test]
        public void ValidVersionActionReturnsCorrectFormattedString([Values("-v", "--v", "/v", "--version")] string actionParameter)
        {
            var result = SUT.Action<string>(actionParameter, filename);
            Assert.IsTrue(result[1] == '.');
            Assert.IsTrue(result[3] == '.');
        }

        [Test]
        public void InvalidActionReturnsDefault([Values("d", "", "++v")] string actionParameter)
        {
            var result = SUT.Action<string>(actionParameter, filename);
            Assert.AreEqual(default(string), result);
        }
    }
}