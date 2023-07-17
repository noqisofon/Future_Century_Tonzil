using Misskey.Domain;
using Misskey.Requests;

namespace Misskey.Interfaces;

/// <summary>
/// <c>/notes</c> から始まるエンドポイント用のサービスのインターフェースです。
/// </summary>
/// <remarks>
/// みすきー API に対応するサービスはインターフェイスがカテゴリごとに分かれている。
/// </remarks>
public interface INotesService {

    /// <summary>
    /// ノート一覧を取得します。
    /// </summary>
    /// <param name="request">ノート一覧取得リクエスト</param>
    /// <returns>取得したノートのシーケンス</returns>
    Task<IEnumerable<Note>> GetNotesAsync(NotesRequest? request = null);

    ///// <summary>
    ///// ノートを作成します。
    ///// </summary>
    ///// <remarks>返信や <c>Renote</c> もこのメソッド(API)で行います。</remarks>
    ///// <param name="request">ノート作成リクエスト</param>
    ///// <returns>作成されたノート</returns>
    //Task<Note> Create(NoteCreationRequest request);
}