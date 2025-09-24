namespace SharpFont.Tests;

public class FaceTests : SharpFontTest
{
    [Test]
    [TestCase("Cousine-Regular-Latin.ttf")]
    [TestCase("AlexBrush-Regular.ttf")]
    [TestCase("Alegreya-Regular.otf")]
    public void LoadsFace(string font)
    {
        using Face face = new(this.Library, font);
        Assert.That(face.GlyphCount, Is.GreaterThan(0));
        TestContext.Out.WriteLine($"Loaded {face.FamilyName} (style: {face.StyleName})");
    }
}