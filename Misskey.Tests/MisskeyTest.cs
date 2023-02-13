namespace Misskey.Tests;

public class MisskeyTest {

	[Test]
	public void コンストラクタ風味にNewできたほうがいいかな() {
		/* `misskey.send-cash-by-letter-pack.example.net` は架空のドメインなので、アクセスしないようにしてください。 */
		const string __HOST_NAME = "misskey.send-cash-by-letter-pack.example.net";

		var misskey = new Misskey( __HOST_NAME );

		Assert.That( misskey.Host, Is.EqualTo( __HOST_NAME ) );
	}

	[Test]
	public void 名前は忘れたけどプロパティに値を設定する形式でもMisskeyオブジェクトを初期化できること() {
		/* via: https://gihyo.jp/article/2023/02/misskey-01 */
		var hostnames = new[]{
			"misskey.io",
			"shshi.ski",
			"submarin.oneline",
			"drdr.club"
		};

		foreach ( var hostname in hostnames ) {
			var misskey_instance = new Misskey { Host = hostname };

			Assert.That( misskey_instance.Host, Is.EqualTo( hostname ) );
		}
	}
}
