using NUnit.Framework;
using PodigeeNet.Data;
using System;

namespace PodigeeNet.Tests.Data
{
    [TestFixture]
    public class UploadTest : TestBase<Upload>
    {
        #region Constructor
        public UploadTest()
            : base("upload.json")
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
                Assert.That(Item.UploadUrl, Is.EqualTo("upload_url"), "UploadUrl");
                Assert.That(Item.ContentType, Is.EqualTo("content_type"), "ContentType");
                Assert.That(Item.FileUrl, Is.EqualTo("file_url"), "FileUrl");
            });
        }

        [Test, Order(2)]
        public void Serialize_Returns_Valid_Result()
        {
            var json = Serialize();

            Assert.That(String.IsNullOrWhiteSpace(json), Is.False);
            Assert.Multiple(() =>
            {
                Assert.That(json.Contains("\"upload_url\":"), Is.True, "upload_url");
                Assert.That(json.Contains("\"content_type\":"), Is.True, "content_type");
                Assert.That(json.Contains("\"file_url\":"), Is.True, "file_url");
            });
        }

        [Test]
        public void Initialize_Constructor()
        {
            Upload upload = null;

            Assert.That(() => upload = new Upload(), Throws.Nothing);
            Assert.Multiple(() =>
            {
                Assert.That(upload.UploadUrl, Is.Null, "UploadUrl");
                Assert.That(upload.ContentType, Is.Null, "ContentType");
                Assert.That(upload.FileUrl, Is.Null, "FileUrl");
            });
        }

        [Test]
        public void Invoke_ToString_Returns_Valid_Result()
        {
            var upload = new Upload
            {
                FileUrl = "FileUrl"
            };

            Assert.That(upload.ToString(), Is.EqualTo(upload.FileUrl));
        }
        #endregion
    }
}