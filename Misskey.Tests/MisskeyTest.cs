namespace Misskey.Tests;

public class MisskeyTest {
	/* この Public Methods のような #region .. #endregion は CodeMaid で付けてるものなので、必須ではないです。 */

	#region Public Methods

	/// <summary>
	///
	/// </summary>
	/// <remarks>`misskey.send-cash-by-letter-pack.example.net` は架空のドメインなので、アクセスしないようにしてください。</remarks>
	/// <param name="hostname"></param>
	[Test]
	public void コンストラクタ風味にNewできたほうがいいかな([Values( "misskey.send-cash-by-letter-pack.example.net" )] string? hostname) {
		var misskey = new Misskey( hostname );

		Assert.That( misskey.Host, Is.EqualTo( hostname ) );
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="hostname"></param>
	[Test]
	public void 名前は忘れたけどプロパティに値を設定する形式でもMisskeyオブジェクトを初期化できること([Values( "misskey.io", "shshi.ski", "submarin.oneline", "drdr.club" )] string? hostname) {
		/* via: https://gihyo.jp/article/2023/02/misskey-01 */
		var misskey_instance = new Misskey { Host = hostname };

		Assert.That( misskey_instance.Host, Is.EqualTo( hostname ) );
	}

	#endregion Public Methods

	// TODO: あとトークン
	// TODO: URL がうにゃうにゃできること[何が？]
}