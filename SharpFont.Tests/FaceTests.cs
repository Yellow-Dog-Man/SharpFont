namespace SharpFont.Tests;

public class FaceTests : SharpFontTest
{
    [Test]
    public void LoadsFace()
    {
        using Face face = new(this.Library, "Cousine-Regular-Latin.ttf");
        Assert.That(face.GlyphCount, Is.GreaterThan(0));
    }
}