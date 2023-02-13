using System.Text.Json;
using System.Text.Json.Nodes;

using Misskey.Domain;
using Misskey.Services;

namespace Misskey.Tests.Services;

public class JsonServiceTest {

	[Test]
	public void シリアライズしたりデシリアライズできること() {
		var note = new Note {
			Id = "114514",
			CreatedAt = new DateTime( 2013, 7, 19 ),
			Text = "七味唐辛子で食事の世界が広がります。",
			UserId = "1145141919",
			Visibility = NoteVisibility.Home
		};

		var jsonedNoteOrNull = service.Serialize( note );

		Assume.That( jsonedNoteOrNull, Is.Not.Null, "シリアライズ後のオブジェクト `jsonedNoteOrNull` は `null` じゃないはず" );
		if ( jsonedNoteOrNull is not string jsonedNote ) {
			Assert.Fail( "シリアライズ後のやつが null だよ" );

			/* Assert.Fail() を呼ぶと、ここへは来ないはずだが、`return` を書いとかないと怒られるので書いてる。 */
			return;
		}
		var rootOrNull = JsonNode.Parse( jsonedNote );

		Assert.That( rootOrNull, Is.Not.Null, "`rootOrNull` が `null` でないこと" );
		if ( rootOrNull is not JsonNode root ) {
			Assert.Fail( "`rootOrNull` が `null` だよ" );

			/* Assert.Fail() を呼ぶと、ここへは来ないはずだが、`return` を書いとかないと怒られるなので書いてる。 */
			return;
		}

		var properties = root.Root;

		IDictionary<string, object?> exceptedMap = new Dictionary<string, object?> {
			["id"] = "114514",
			["createdAt"] = new DateTime( 2013, 7, 19 ).ToString( "yyyy-MM-ddTHH:mm:ss" ),
			["text"] = JsonEncodedText.Encode( "七味唐辛子で食事の世界が広がります。" ),
			["userId"] = "1145141919",
			["visibility"] = "home"
		};

		foreach ( var (key, value) in exceptedMap ) {
			var node = properties[key]?.AsValue();

			Assert.That( node, Is.Not.Null, $"`{key}` が `null` でないこと" );
			Assert.That( node.ToJsonString(), Does.Contain( value!.ToString() ), $"`{key}` の値に `{value}` が含まれていること" );
		}

		var deserializedNote = service.Deserialize<Note>( jsonedNote );
		Assert.That( deserializedNote, Is.Not.Null, "`deserializedNote` が `null` ではないこと" );

		Assert.That( deserializedNote, Is.Not.Null, $"デシリアライズされた {nameof( Note )} オブジェクトが `null` でないこと" );
		Assert.Multiple( () => {
			Assert.That( deserializedNote.Id, Is.EqualTo( note.Id ), $"当然 `{nameof( note.Id )}` が一緒なこと" );
			Assert.That( deserializedNote.CreatedAt, Is.EqualTo( note.CreatedAt ), $"当然 `{nameof( note.CreatedAt )}` が一緒なこと" );
			Assert.That( deserializedNote.Text, Is.EqualTo( note.Text ), $"当然 `{nameof( note.Text )}` が一緒なこと" );
			Assert.That( deserializedNote.Cw, Is.EqualTo( note.Cw ), $"当然 `{nameof( note.Cw )}` が一緒なこと" );
			Assert.That( deserializedNote.UserId, Is.EqualTo( note.UserId ), $"当然 `{nameof( note.UserId )}` が一緒なこと" );
			Assert.That( deserializedNote.Visibility, Is.EqualTo( note.Visibility ), $"当然 `{nameof( note.Visibility )}` が一緒なこと" );
		} );
	}

	private readonly JsonService service = new();
}