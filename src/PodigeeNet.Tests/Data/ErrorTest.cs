using NUnit.Framework;
using PodigeeNet.Data;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ErrorTest
    {
        #region Tests
        [Test]
        public void Initialize_Constructor()
        {
            Error error = null;

            Assert.That(() => error = new Error(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(error.Code, Is.EqualTo(0), "Code");
                Assert.That(error.Message, Is.Null, "Message");
            });
        }
        #endregion
    }
}