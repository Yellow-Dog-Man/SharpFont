namespace SharpFont.Tests;

public class LibraryTests
{
    [Test]
    public void InitializeLibraryTest()
    {
        using Library library = new();
        TestContext.Out.WriteLine($"Library version: {library.Version}");
    }
}