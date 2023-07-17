using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Misskey.Domain;

/// <summary>
///
/// </summary>
[DataContract]
public class Note {

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "id" )]
	[JsonPropertyName( "id" )]
	public string? Id { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "createdAt" )]
	[JsonPropertyName( "createdAt" )]
	public DateTime CreatedAt { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "text" )]
	[JsonPropertyName( "text" )]
	public string? Text { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "cw" )]
	[JsonPropertyName( "cw" )]
	public string? Cw { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "user" )]
	[JsonPropertyName( "user" )]
	public User? User { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "userId" )]
	[JsonPropertyName( "userId" )]
	public string? UserId { get; set; }

	/// <summary>
	///
	/// </summary>
	[DataMember( Name = "visibility" )]
	[JsonPropertyName( "visibility" )]
	public NoteVisibility Visibility { get; set; }
}