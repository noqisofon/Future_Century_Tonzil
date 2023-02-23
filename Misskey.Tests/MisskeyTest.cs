namespace Misskey.Tests;

public class MisskeyTest {
    /* この Public Methods のような #region .. #endregion は CodeMaid で付けてるものなので、必須ではないです。 */

    #region Public Methods

    [TestCase( "notes/children" )]
    [TestCase( "notes" )]
    public void エンドポイントからURLを生成できること(string? endpoint) {
        var misskey = new Misskey( "misskey.example.com" );

        var url = misskey.GetApiUrl( endpoint );

        Assert.That( url, Is.Not.Null );
        Assert.That( url.Scheme, Is.EqualTo( "https" ) );
        Assert.That( url.Host, Is.EqualTo( misskey.Host ) );
        Assert.That( url.AbsolutePath, Is.EqualTo( "/api/" + endpoint ) );
    }

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
    /// <param name="token"></param>
    [TestCase( "misskey.send-cash-by-letter-pack.example.net", "hogepiyo" )]
    public void トークンも一緒に渡せること(string? hostname, string? token) {
        var misskey = new Misskey( hostname, token );

        Assert.That( misskey.Host, Is.EqualTo( hostname ) );
        Assert.That( misskey.Token, Is.EqualTo( token ) );
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
}