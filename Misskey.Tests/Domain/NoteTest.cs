using System.Text.Json;
using System.Text.Json.Serialization;

using Misskey.Domain;

namespace Misskey.Tests.Domain;

public class NoteTest {

	[Test]
	public void Idのみに値を設定してシリアライズしたときにidだけがシリアライズされること() {
		var note = new Note {
			Id = "114514"
		};

		var options = new JsonSerializerOptions {
			// プロパティは型の既定値と等しい場合にのみ無視されるよ。
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		Assert.That( jsonedNote, Is.Not.Empty, "戻り値が空文字列でないこと" );
		Assert.Multiple( () => {
			Assert.That( jsonedNote, Does.Contain( "id" ), "`id' という文字列が含まれていること" );
			Assert.That( jsonedNote, Does.Not.Contain( "Id" ), "`プロパティの名前そのままの `Id' という文字列が含まれていないこと" );
		} );
		Assert.That( jsonedNote, Does.Contain( note.Id.ToString() ), "note.Id の値が含まれていること" );
	}

	[Test]
	public void 正気度テスト() {
		var note = new Note {
			Id = "114514",
			CreatedAt = new DateTime( 2003, 11, 4 ),
			Text = "レターパックで現金送れ",
			Cw = "は全て詐欺",
			UserId = "1145141919",
			Visibility = NoteVisibility.Public  /* Visibility は Public がデフォルト値なので、シリアライズされない */
		};

		var options = new JsonSerializerOptions {
			// プロパティは型の既定値と等しい場合にのみ無視されるよ。
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		var deserializedNote = JsonSerializer.Deserialize( jsonedNote, typeof( Note ) ) as Note;

		Assert.That( deserializedNote, Is.Not.Null, "デシリアライズされた Note オブジェクトが存在すること" );
		Assert.That( deserializedNote.Id, Is.EqualTo( note.Id ), "当然 `Id' が一緒なこと" );
		Assert.That( deserializedNote.CreatedAt, Is.EqualTo( note.CreatedAt ), "当然 `CreatedAt' が一緒なこと" );
		Assert.That( deserializedNote.Text, Is.EqualTo( note.Text ), "当然 `Text' が一緒なこと" );
		Assert.That( deserializedNote.Cw, Is.EqualTo( note.Cw ), "当然 `Cw' が一緒なこと" );
		Assert.That( deserializedNote.UserId, Is.EqualTo( note.UserId ), "当然 `UserId' が一緒なこと" );
		Assert.That( deserializedNote.Visibility, Is.EqualTo( note.Visibility ), "当然 `Visibility' が一緒なこと" );
	}

	[Test]
	public void NoteVisibilityってシリアライズされるとどうなるの() {
		var note = new Note {
			Id = "114514",
			CreatedAt = new DateTime( 2003, 11, 4 ),
			Text = "レターパックで現金送れ",
			Cw = "は全て詐欺",
			UserId = "1145141919",
			Visibility = NoteVisibility.Home
		};

		var options = new JsonSerializerOptions {
			// プロパティは型の既定値と等しい場合にのみ無視されるよ。
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			Converters = {
				// 列挙体な値を全部小文字な文字列にするよ
				new JsonStringEnumConverter( JsonNamingPolicy.CamelCase )
			}
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		Assert.That( jsonedNote, Does.Contain( "\"visibility\":\"home\"" ), "`Vibility' の値が 1 ではなく `home' であること" );

		var deserializedNote = JsonSerializer.Deserialize( jsonedNote, typeof( Note ) ) as Note;

		Assert.That( deserializedNote, Is.Not.Null, "デシリアライズされた Note オブジェクトが存在すること" );
		Assert.That( deserializedNote.Id, Is.EqualTo( note.Id ), "当然 `Id' が一緒なこと" );
		Assert.That( deserializedNote.CreatedAt, Is.EqualTo( note.CreatedAt ), "当然 `CreatedAt' が一緒なこと" );
		Assert.That( deserializedNote.Text, Is.EqualTo( note.Text ), "当然 `Text' が一緒なこと" );
		Assert.That( deserializedNote.Cw, Is.EqualTo( note.Cw ), "当然 `Cw' が一緒なこと" );
		Assert.That( deserializedNote.UserId, Is.EqualTo( note.UserId ), "当然 `UserId' が一緒なこと" );
		Assert.That( deserializedNote.Visibility, Is.EqualTo( note.Visibility ), "当然 `Visibility' が一緒なこと" );
	}
}