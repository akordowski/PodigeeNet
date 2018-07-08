using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ContributorLinkTest : TestBase<ContributorLink>
    {
        #region Constructor
        public ContributorLinkTest()
            : base("contributor_link.json")
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
                Assert.That(Item.Icon, Is.EqualTo("icon"), "Icon");
                Assert.That(Item.Url, Is.EqualTo("url"), "Url");
                Assert.That(Item.Text, Is.EqualTo("text"), "Text");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"icon\":"), Is.True, "icon");
                Assert.That(json.Contains("\"url\":"), Is.True, "url");
                Assert.That(json.Contains("\"text\":"), Is.True, "text");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            ContributorLink contributorLink = null;

            Assert.That(() => contributorLink = new ContributorLink(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(contributorLink.Icon, Is.Null, "Icon");
                Assert.That(contributorLink.Url, Is.Null, "Url");
                Assert.That(contributorLink.Text, Is.Null, "Text");
            });
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var contributorLink = new ContributorLink
            {
                Text = "Text"
            };

            Assert.That(contributorLink.ToString(), Is.EqualTo(contributorLink.Text));
        }
        #endregion
    }
}