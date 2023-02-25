using Misskey.Domain;

namespace Misskey.Services;

/// <summary>
/// <c>/notes</c> から始まるエンドポイント用のサービスのインターフェースです。
/// </summary>
public interface INotesService {

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Note>> GetNotesAsync();
}