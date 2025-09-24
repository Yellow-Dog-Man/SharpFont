namespace SharpFont.Tests;

public class SharpFontTest
{
    protected Library Library;
    
    [SetUp]
    public void Setup()
    {
        this.Library = new Library();
    }

    [TearDown]
    public void TearDown()
    {
        this.Library.Dispose();
    }
}