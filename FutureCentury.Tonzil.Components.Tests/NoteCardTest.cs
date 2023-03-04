using FutureCentury.Tonzil.Components.Shared;

namespace FutureCentury.Tonzil.Components.Tests;

public class NoteCardTest : BunitTestContext {

    [Test]
    public void 要素が存在すること() {
        var aNote = new Note {
            Id = Guid.NewGuid().ToString( "N" ),
            Text = "レターパックで現金送れはすべて詐欺です。",
            CreatedAt = DateTime.Now
        };

        var cut = RenderComponent<NoteCard>( parameters => parameters
                                             .Add( p => p.Model, aNote ) );

        var founds = cut.FindAll( ".card .col-md-8 p.card-text" );
        Assert.That( founds, Has.Exactly( 2 ).Items );
        founds[0].MarkupMatches( $"<p class=\"card-text\">{aNote.Text}</p>" );

        Assert.That( founds[1].Children, Has.Exactly( 1 ).Items );
        founds[1].Children[0].MarkupMatches( $"<small class=\"text-muted\">{aNote.CreatedAt}</small>" );
    }
}
