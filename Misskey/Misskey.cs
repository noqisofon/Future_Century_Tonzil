namespace Misskey;

/// <summary>
///
/// </summary>
public sealed class Misskey {

	/// <summary>
	/// ホスト名
	/// </summary>
	public string? Host { get; init; }

	/// <summary>
	/// トークン
	/// </summary>
	public string? Token { get; init; }

	/// <summary>
	/// 指定されたエンドポイントから <see cref="Uri" /> オブジェクトを作成して返します。
	/// </summary>
	/// <param name="endPoint">エンドポイント</param>
	/// <returns></returns>
	public Uri GetApiUrl(string endPoint) => new UriBuilder( "https", this.Host ) {
		Path = $"/api/${endPoint}"
	}.Uri;
}