using System.Text.Json.Serialization;

namespace Misskey.Domain;

/// <summary>
///
/// </summary>
[JsonConverter( typeof( JsonStringEnumConverter ) )]
public enum NoteVisibility {

	/// <summary>
	///
	/// </summary>
	Public,

	/// <summary>
	///
	/// </summary>
	Home,

	/// <summary>
	///
	/// </summary>
	Followers,

	/// <summary>
	///
	/// </summary>
	Specfied
}