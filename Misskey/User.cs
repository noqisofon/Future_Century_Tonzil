namespace Misskey.Domain;

/// <summary>
/// ユーザー
/// </summary>
public class User {

	/// <summary>
	/// (ユーザー)ID
	/// </summary>
	public string? Id { get; set; }

	/// <summary>
	/// (ユーザー)作成日
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	/// (ユーザー)名前…？
	/// </summary>
	public string? UserName { get; set; }

	/// <summary>
	/// どっちの名前…？
	/// </summary>
	public string? Name { get; set; }

	/// <summary>
	/// オンラインステータス
	/// </summary>
	public OnlineStatus OnlineStatus { get; set; }

	/// <summary>
	/// あばたーURL
	/// </summary>
	public string? AvatarUrl { get; set; }

	/// <summary>
	/// あばたー？？？？
	/// </summary>
	public string? AvatarBlurHash { get; set; }
}