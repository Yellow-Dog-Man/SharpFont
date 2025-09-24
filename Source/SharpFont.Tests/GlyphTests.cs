namespace SharpFont.Tests;

public class GlyphTests : SharpFontTest
{
    private Face _face;
    private uint _glyphIndex;

    [SetUp]
    public new void Setup()
    {
        this._face = new Face(this.Library, "Cousine-Regular-Latin.ttf");
        this._face.SetPixelSizes(0, 48);
        this._face.SelectCharmap(Encoding.Unicode);
        
        const uint codepoint = 'A';
        
        this._glyphIndex = _face.GetCharIndex(codepoint);
        this._face.LoadGlyph(this._glyphIndex, LoadFlags.Default, LoadTarget.Normal);
    }

    [TearDown]
    public new void TearDown()
    {
        this._face.Dispose();
    }

    [Test]
    public void GlyphMetricsAreReasonable()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this._face.Glyph.Metrics.Width.ToInt32(), Is.GreaterThan(0));
            Assert.That(this._face.Glyph.Metrics.Height.ToInt32(), Is.GreaterThan(0));
        });
    }

    [Test]
    public void GlyphRenders()
    {
        this._face.Glyph.RenderGlyph(RenderMode.Normal);
        
        FTBitmap? bitmap = this._face.Glyph.Bitmap;
        Assert.That(bitmap, Is.Not.Null);
        
        byte[]? buf = bitmap.BufferData;
        Assert.That(buf, Is.Not.Null);
        
        Assert.That(buf, Is.Not.Empty);
        Assert.That(buf.Any(b => b != 0));
    }
}