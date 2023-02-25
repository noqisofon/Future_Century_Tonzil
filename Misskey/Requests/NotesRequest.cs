using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Misskey.Requests;

/// <summary>
///
/// </summary>
public class NotesRequest {

    /// <summary>
    /// ローカルで作成されたノートのみを取得するかどうかを表します。
    /// </summary>
    /// <value>真ならローカルで作成されたノートのみを取得。偽ならそれ以外も取得</value>
    [JsonPropertyName( "local" )]
    public bool Local { get; set; }

    /// <summary>
    /// 返信(リプライ)だけを取得するかどうかを表します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "reply" )]
    public bool? Reply { get; set; }

    /// <summary>
    /// リノートだけを取得するかどうかを表します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "renote" )]
    public bool? Renote { get; set; }

    /// <summary>
    /// 添付ファイルのあるノートだけを取得するかどうかを表します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "withFiles" )]
    public bool? WithFiles { get; set; }

    /// <summary>
    /// 投票を含むノートだけを取得するかどうかを表します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "pull" )]
    public bool? Poll { get; set; }

    /// <summary>
    /// 取得するノートの最大数を指定します。
    /// </summary>
    /// <value>最小値は 1、最大値は 100。デフォルト値は 10。</value>
    [Range( 1, 100 )]
    [JsonPropertyName( "limit" )]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// 指定すると <c>id</c> がその値よりも大きいノートを返します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "sinceId" )]
    public string? SinceId { get; set; }

    /// <summary>
    /// 指定すると <c>id</c> がその値よりも小さいノートを返します。
    /// </summary>
    /// <value></value>
    [JsonPropertyName( "untilId" )]
    public string? UntilId { get; set; }
}
