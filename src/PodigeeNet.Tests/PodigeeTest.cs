using NUnit.Framework;
using System;

namespace PodigeeNet
{
    [TestFixture]
    public class PodigeeTest
    {
        #region Tests
        [Test]
        public void Initialize_Constructor(
            [Values(null, "", "  ", "apiToken")] string apiToken)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (String.IsNullOrWhiteSpace(apiToken))
            {
                expectedException = apiToken == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(apiToken);
            }

            if (expectedException == null)
            {
                Podigee podigee = null;

                Assert.Multiple(() =>
                {
                    Assert.That(() => podigee = new Podigee(apiToken), Throws.Nothing);
                    Assert.That(podigee.ApiToken, Is.EqualTo(apiToken));
                    Assert.That(podigee.BaseUrl, Is.EqualTo("https://app.podigee.com/api/v1/"));
                });
            }
            else
            {
                Assert.That(() => new Podigee(apiToken), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }
        #endregion
    }
}