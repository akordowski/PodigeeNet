using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ProductionTest : TestBase<Production>
    {
        #region Constructor
        public ProductionTest()
            : base("production.json")
        {
        }
        #endregion

        #region Tests
        [Test, Order(1)]
        public void Deserialize_Production_Returns_Valid_Result()
        {
            Deserialize();

            Assert.Multiple(() =>
            {
                Assert.That(Item.Id, Is.EqualTo(123), "Id");
                Assert.That(Item.EpisodeId, Is.EqualTo(456), "EpisodeId");
                Assert.That(Item.Files.Count, Is.EqualTo(0), "Files");
                Assert.That(Item.State, Is.EqualTo(ProductionState.Initial), "State");
                Assert.That(Item.TranscriptionUrl, Is.EqualTo("transcription_url"), "TranscriptionUrl");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 2, 2, 01, 23, 45)), "UpdatedAt");
            });
        }

        [Test, Order(2)]
        public void Serialize_Production_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.Multiple(() =>
            {
                Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
                Assert.That(json.Contains("\"id\":"), Is.False, "Id");
                Assert.That(json.Contains("\"episode_id\":"), Is.True, "EpisodeId");
                Assert.That(json.Contains("\"files\":"), Is.False, "Files");
                Assert.That(json.Contains("\"state\":"), Is.True, "State");
                Assert.That(json.Contains("\"transcription_url\":"), Is.False, "TranscriptionUrl");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "CreatedAt");
                Assert.That(json.Contains("\"updated_at\":"), Is.False, "UpdatedAt");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            Production production = null;

            Assert.That(() => production = new Production(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(production.Id, Is.EqualTo(0), "Id");
                Assert.That(production.EpisodeId, Is.EqualTo(0), "EpisodeId");
                Assert.That(production.Files, Is.Null, "Files");
                Assert.That(production.State, Is.EqualTo(ProductionState.Null), "State");
                Assert.That(production.TranscriptionUrl, Is.Null, "TranscriptionUrl");
                Assert.That(production.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(production.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(0, 1)] long episodeId)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (episodeId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(episodeId);
            }

            if (expectedException == null)
            {
                Production production = null;

                Assert.That(() => production = new Production(episodeId), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(production.Id, Is.EqualTo(0), "Id");
                    Assert.That(production.EpisodeId, Is.EqualTo(episodeId), "EpisodeId");
                    Assert.That(production.Files, Is.Null, "Files");
                    Assert.That(production.State, Is.EqualTo(ProductionState.Null), "State");
                    Assert.That(production.TranscriptionUrl, Is.Null, "TranscriptionUrl");
                    Assert.That(production.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(production.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                });
            }
            else
            {
                Assert.That(() => new Production(episodeId), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }
        #endregion
    }
}