using System.Text.Json;
using System.Text.Json.Serialization;

using Misskey.Domain;

namespace Misskey.Tests.Domain;

public class NoteTest {

	[Test]
	public void Id�݂̂ɒl��ݒ肵�ăV���A���C�Y�����Ƃ���id�������V���A���C�Y����邱��() {
		var note = new Note {
			Id = "114514"
		};

		var options = new JsonSerializerOptions {
			// �v���p�e�B�͌^�̊���l�Ɠ������ꍇ�ɂ̂ݖ���������B
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		Assert.That( jsonedNote, Is.Not.Empty, "�߂�l���󕶎���łȂ�����" );
		Assert.Multiple( () => {
			Assert.That( jsonedNote, Does.Contain( "id" ), "`id' �Ƃ��������񂪊܂܂�Ă��邱��" );
			Assert.That( jsonedNote, Does.Not.Contain( "Id" ), "`�v���p�e�B�̖��O���̂܂܂� `Id' �Ƃ��������񂪊܂܂�Ă��Ȃ�����" );
		} );
		Assert.That( jsonedNote, Does.Contain( note.Id.ToString() ), "note.Id �̒l���܂܂�Ă��邱��" );
	}

	[Test]
	public void ���C�x�e�X�g() {
		var note = new Note {
			Id = "114514",
			CreatedAt = new DateTime( 2003, 11, 4 ),
			Text = "���^�[�p�b�N�Ō�������",
			Cw = "�͑S�č��\",
			UserId = "1145141919",
			Visibility = NoteVisibility.Public  /* Visibility �� Public ���f�t�H���g�l�Ȃ̂ŁA�V���A���C�Y����Ȃ� */
		};

		var options = new JsonSerializerOptions {
			// �v���p�e�B�͌^�̊���l�Ɠ������ꍇ�ɂ̂ݖ���������B
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		var deserializedNote = JsonSerializer.Deserialize( jsonedNote, typeof( Note ) ) as Note;

		Assert.That( deserializedNote, Is.Not.Null, "�f�V���A���C�Y���ꂽ Note �I�u�W�F�N�g�����݂��邱��" );
		Assert.That( deserializedNote.Id, Is.EqualTo( note.Id ), "���R `Id' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.CreatedAt, Is.EqualTo( note.CreatedAt ), "���R `CreatedAt' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Text, Is.EqualTo( note.Text ), "���R `Text' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Cw, Is.EqualTo( note.Cw ), "���R `Cw' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.UserId, Is.EqualTo( note.UserId ), "���R `UserId' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Visibility, Is.EqualTo( note.Visibility ), "���R `Visibility' ���ꏏ�Ȃ���" );
	}

	[Test]
	public void NoteVisibility���ăV���A���C�Y�����Ƃǂ��Ȃ��() {
		var note = new Note {
			Id = "114514",
			CreatedAt = new DateTime( 2003, 11, 4 ),
			Text = "���^�[�p�b�N�Ō�������",
			Cw = "�͑S�č��\",
			UserId = "1145141919",
			Visibility = NoteVisibility.Home
		};

		var options = new JsonSerializerOptions {
			// �v���p�e�B�͌^�̊���l�Ɠ������ꍇ�ɂ̂ݖ���������B
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			Converters = {
				// �񋓑̂Ȓl��S���������ȕ�����ɂ����
				new JsonStringEnumConverter( JsonNamingPolicy.CamelCase )
			}
		};

		var jsonedNote = JsonSerializer.Serialize( note, options );

		Assert.That( jsonedNote, Does.Contain( "\"visibility\":\"home\"" ), "`Vibility' �̒l�� 1 �ł͂Ȃ� `home' �ł��邱��" );

		var deserializedNote = JsonSerializer.Deserialize( jsonedNote, typeof( Note ) ) as Note;

		Assert.That( deserializedNote, Is.Not.Null, "�f�V���A���C�Y���ꂽ Note �I�u�W�F�N�g�����݂��邱��" );
		Assert.That( deserializedNote.Id, Is.EqualTo( note.Id ), "���R `Id' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.CreatedAt, Is.EqualTo( note.CreatedAt ), "���R `CreatedAt' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Text, Is.EqualTo( note.Text ), "���R `Text' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Cw, Is.EqualTo( note.Cw ), "���R `Cw' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.UserId, Is.EqualTo( note.UserId ), "���R `UserId' ���ꏏ�Ȃ���" );
		Assert.That( deserializedNote.Visibility, Is.EqualTo( note.Visibility ), "���R `Visibility' ���ꏏ�Ȃ���" );
	}
}