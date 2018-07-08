using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class ContributorTest : TestBase<Contributor>
    {
        #region Constructor
        public ContributorTest()
            : base("contributor.json")
        {
        }
        #endregion

        #region Tests
        [Test, Order(1)]
        public void Deserialize_Returns_Valid_Result()
        {
            Deserialize();

            Assert.Multiple(() =>
            {
                Assert.That(Item.Id, Is.EqualTo(123), "Id");
                Assert.That(Item.PodcastId, Is.EqualTo(456), "PodcastId");
                Assert.That(Item.UserId, Is.EqualTo(789), "UserId");
                Assert.That(Item.Name, Is.EqualTo("name"), "Name");
                Assert.That(Item.Email, Is.EqualTo("email"), "Email");
                Assert.That(Item.Biography, Is.EqualTo("biography"), "Biography");
                Assert.That(Item.AvatarUrl, Is.EqualTo("avatar_url"), "AvatarUrl");
                Assert.That(Item.Links.Count, Is.EqualTo(0), "Links");
                Assert.That(Item.CreatedAt, Is.EqualTo(new DateTime(2018, 1, 1, 0, 12, 34)), "CreatedAt");
                Assert.That(Item.UpdatedAt, Is.EqualTo(new DateTime(2018, 2, 2, 01, 23, 45)), "UpdatedAt");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.Multiple(() =>
            {
                Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
                Assert.That(json.Contains("\"id\":"), Is.False, "Id");
                Assert.That(json.Contains("\"podcast_id\":"), Is.True, "PodcastId");
                Assert.That(json.Contains("\"user_id\":"), Is.False, "UserId");
                Assert.That(json.Contains("\"name\":"), Is.True, "Name");
                Assert.That(json.Contains("\"email\":"), Is.True, "Email");
                Assert.That(json.Contains("\"biography\":"), Is.True, "Biography");
                Assert.That(json.Contains("\"avatar_url\":"), Is.True, "AvatarUrl");
                Assert.That(json.Contains("\"links\":"), Is.False, "Links");
                Assert.That(json.Contains("\"created_at\":"), Is.False, "CreatedAt");
                Assert.That(json.Contains("\"updated_at\":"), Is.False, "UpdatedAt");
            });
        }

        [Test]
        public void Initialize_Constructor_1()
        {
            Contributor contributor = null;

            Assert.That(() => contributor = new Contributor(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(contributor.Id, Is.EqualTo(0), "Id");
                Assert.That(contributor.PodcastId, Is.EqualTo(0), "PodcastId");
                Assert.That(contributor.UserId, Is.Null, "UserId");
                Assert.That(contributor.Name, Is.Null, "Name");
                Assert.That(contributor.Email, Is.Null, "Email");
                Assert.That(contributor.Biography, Is.Null, "Biography");
                Assert.That(contributor.AvatarUrl, Is.Null, "AvatarUrl");
                Assert.That(contributor.Links, Is.Null, "Links");
                Assert.That(contributor.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                Assert.That(contributor.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
            });
        }

        [Test]
        public void Initialize_Constructor_2(
            [Values(0, 1)] long podcastId,
            [Values(null, "", "  ", "name")] string name)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (podcastId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(podcastId);
            }
            else if (String.IsNullOrWhiteSpace(name))
            {
                expectedException = name == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(name);
            }

            if (expectedException == null)
            {
                Contributor contributor = null;

                Assert.That(() => contributor = new Contributor(podcastId, name), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(contributor.Id, Is.EqualTo(0), "Id");
                    Assert.That(contributor.PodcastId, Is.EqualTo(podcastId), "PodcastId");
                    Assert.That(contributor.UserId, Is.Null, "UserId");
                    Assert.That(contributor.Name, Is.EqualTo(name), "Name");
                    Assert.That(contributor.Email, Is.Null, "Email");
                    Assert.That(contributor.Biography, Is.Null, "Biography");
                    Assert.That(contributor.AvatarUrl, Is.Null, "AvatarUrl");
                    Assert.That(contributor.Links, Is.Null, "Links");
                    Assert.That(contributor.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(contributor.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                });
            }
            else
            {
                Assert.That(() => new Contributor(podcastId, name), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Initialize_Constructor_3(
            [Values(0, 1)] long podcastId,
            [Values(null, "", "  ", "name")] string name,
            [Values("email")] string email,
            [Values("biography")] string biography,
            [Values("avatarUrl")] string avatarUrl)
        {
            Type expectedException = null;
            string expectedParamName = null;

            if (podcastId < 1)
            {
                expectedException = typeof(ArgumentOutOfRangeException);
                expectedParamName = nameof(podcastId);
            }
            else if (String.IsNullOrWhiteSpace(name))
            {
                expectedException = name == null ? typeof(ArgumentNullException) : typeof(ArgumentException);
                expectedParamName = nameof(name);
            }

            if (expectedException == null)
            {
                Contributor contributor = null;

                Assert.That(() => contributor = new Contributor(podcastId, name, email, biography, avatarUrl), Throws.Nothing);
                Assert.Multiple(() =>
                {
                    Assert.That(contributor.Id, Is.EqualTo(0), "Id");
                    Assert.That(contributor.PodcastId, Is.EqualTo(podcastId), "PodcastId");
                    Assert.That(contributor.UserId, Is.Null, "UserId");
                    Assert.That(contributor.Name, Is.EqualTo(name), "Name");
                    Assert.That(contributor.Email, Is.EqualTo(email), "Email");
                    Assert.That(contributor.Biography, Is.EqualTo(biography), "Biography");
                    Assert.That(contributor.AvatarUrl, Is.EqualTo(avatarUrl), "AvatarUrl");
                    Assert.That(contributor.Links, Is.Null, "Links");
                    Assert.That(contributor.CreatedAt, Is.EqualTo(DateTime.MinValue), "CreatedAt");
                    Assert.That(contributor.UpdatedAt, Is.EqualTo(DateTime.MinValue), "UpdatedAt");
                });
            }
            else
            {
                Assert.That(() => new Contributor(podcastId, name, email, biography, avatarUrl), Throws
                    .Exception.TypeOf(expectedException)
                    .With.Property("ParamName").EqualTo(expectedParamName));
            }
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var contributor = new Contributor
            {
                Name = "Name"
            };

            Assert.That(contributor.ToString(), Is.EqualTo(contributor.Name));
        }
        #endregion
    }
}