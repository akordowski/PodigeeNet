using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ProductionFileTest : TestBase<ProductionFile>
    {
        #region Constructor
        public ProductionFileTest()
            : base("production_file.json")
        {
        }
        #endregion

        #region Tests
        [Test, Order(1)]
        public void Deserialize_Returns_Valid_Result()
        {
            Deserialize();

            Assert.That(Item, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
                Assert.That(Item.ContributorId, Is.EqualTo(123), "ContributorId");
                Assert.That(Item.CustomName, Is.EqualTo("custom_name"), "CustomName");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"url\":"), Is.True, "url");
                Assert.That(json.Contains("\"contributor_id\":"), Is.True, "contributor_id");
                Assert.That(json.Contains("\"custom_name\":"), Is.True, "custom_name");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            ProductionFile productionFile = null;

            Assert.That(() => productionFile = new ProductionFile(), Throws.Nothing);
            Assert.That(productionFile.Url, Is.Null);
            Assert.That(productionFile.ContributorId, Is.EqualTo(0));
            Assert.That(productionFile.CustomName, Is.Null);
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(null, "", "  ", "url")] string url)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (String.IsNullOrWhiteSpace(url))
            {
                expectedException = url == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(url);
            }

            if (expectedException == null)
            {
                ProductionFile productionFile = null;

                Assert.That(() => productionFile = new ProductionFile(url), Throws.Nothing);
                Assert.That(productionFile.Url, Is.EqualTo(url));
                Assert.That(productionFile.ContributorId, Is.EqualTo(0));
                Assert.That(productionFile.CustomName, Is.Null);
            }
            else
            {
                Assert.That(() => new ProductionFile(url), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Initialize_Constructor_3(
            [Values(null, "", "  ", "url")] string url,
            [Values(0)] int contributorId,
            [Values("customName")] string customName)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (String.IsNullOrWhiteSpace(url))
            {
                expectedException = url == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(url);
            }

            if (expectedException == null)
            {
                ProductionFile productionFile = null;

                Assert.That(() => productionFile = new ProductionFile(url, contributorId, customName), Throws.Nothing);
                Assert.That(productionFile.Url, Is.EqualTo(url));
                Assert.That(productionFile.ContributorId, Is.EqualTo(contributorId));
                Assert.That(productionFile.CustomName, Is.EqualTo(customName));
            }
            else
            {
                Assert.That(() => new ProductionFile(url, contributorId, customName), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var productionFile = new ProductionFile
            {
                Url = "Url"
            };

            Assert.That(productionFile.ToString(), Is.EqualTo(productionFile.Url));
        }
        #endregion
    }
}