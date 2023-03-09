namespace FutureCentury.Tonzil.Components.Tests;

using FutureCentury.Tonzil.Components.Tests.Services;

using Misskey.Services;

using BUnitTestContext = Bunit.TestContext;

/// <summary>
/// Test context wrapper for bUnit.
/// Read more about using <see cref="BunitTestContext"/> <seealso href="https://bunit.dev/docs/getting-started/writing-tests.html#remove-boilerplate-code-from-tests">here</seealso>.
/// </summary>
public abstract class BunitTestContext : TestContextWrapper {

    [SetUp]
    public void Setup() {
        TestContext = new BUnitTestContext();

        TestContext.Services.AddSingleton<INotesService, ConcreateNotesService>();
    }

    [TearDown]
    public void TearDown() => TestContext?.Dispose();
}