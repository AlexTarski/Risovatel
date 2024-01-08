using System;
using System.Drawing;
using System.Reflection;
using NUnit.Framework;

namespace RefactorMe
{
    [TestFixture]
    public class DrawingProgram_Tests
    {
        [Test]
        public void DrawExpectedImage()
        {
            const int width = 800;
            const int height = 600;
            var actual = new Bitmap(width, height);
            ImpossibleSquare.Draw(width, height, 0, Graphics.FromImage(actual));
			//actual.Save(TestContext.CurrentContext.TestDirectory + "/expected-image.bmp");

			using (var stream = Assembly.GetExecutingAssembly()
				       .GetManifestResourceStream(typeof(DrawingProgram_Tests), "expected-image.bmp"))
			{
				Assume.That(stream, Is.Not.Null);
				var expectedImage = (Bitmap)Image.FromStream(stream);
				AssertImageEquals(expectedImage, actual);
			}
		}

        public void AssertImageEquals(Bitmap expected, Bitmap actual)
        {
            var diffCount = 0.0;

            for (var x = 0; x < expected.Width; x++)
            {
                for (var y = 0; y < expected.Height; y++)
                {
                    Color expectedPixel = expected.GetPixel(x, y);
                    Color actualPixel = actual.GetPixel(x, y);
                    if (Math.Abs(expectedPixel.GetBrightness() - actualPixel.GetBrightness()) > 0.1)
                        diffCount++;
                }
            }

            // Изображение, которое рисует метод Draw, должно в точности совпадать с изображением expected-image
            Assert.Less(diffCount, 100);
        }
    }
}
