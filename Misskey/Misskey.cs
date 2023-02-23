namespace Misskey;

/// <summary>
///
/// </summary>
public sealed class Misskey {

	#region Public Constructors

	/// <summary>
	///
	/// </summary>
	public Misskey() { }

	/// <summary>
	///
	/// </summary>
	/// <param name="host"></param>
	public Misskey(string? host) {
		this.Host = host;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="host"></param>
	/// <param name="token"></param>
	public Misskey(string? host, string? token) : this( host ) {
		this.Token = token;
	}

	#endregion Public Constructors

	#region Public Properties

	/// <summary>
	/// ホスト名
	/// </summary>
	public string? Host { get; init; }

	/// <summary>
	/// トークン
	/// </summary>
	public string? Token { get; init; }

	#endregion Public Properties

	#region Public Methods

	/// <summary>
	/// 指定されたエンドポイントから <see cref="Uri" /> オブジェクトを作成して返します。
	/// </summary>
	/// <param name="endPoint">エンドポイント</param>
	/// <returns></returns>
	public Uri GetApiUrl(string? endPoint) => new UriBuilder( "https", this.Host ) {
		Path = $"/api/{endPoint}"
	}.Uri;

	#endregion Public Methods
}