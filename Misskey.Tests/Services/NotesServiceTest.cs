using Misskey.Services;

namespace Misskey.Tests.Services;

public class NotesServiceTest {

    [OneTimeSetUp]
    public void Setup() {
        service = new ConcreteNotesService();
    }

    [Test]
    public async Task ノートが取得できること() {
        var notes = await service.GetNotesAsync();

        Assert.That( notes, Is.Not.Null );
        Assert.That( notes, Has.Exactly( 1 ).Items );
    }

    private INotesService service;
}
