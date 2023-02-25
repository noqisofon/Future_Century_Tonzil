using Misskey.Domain;

namespace FutureCentury.Tonzil.Data;

/// <summary>
/// <c>/notes</c> から始まるエンドポイント用のサービスです。
/// </summary>
/// <remarks>
///     <para>
///     <see cref="NotesService"/> は <c>Misskey.Services.INotesService</c> を実装したもの。
///     <c>Timeline</c> と <c>NoteCard</c> のテストのためのとりあえずの実装。
///     </para>
/// </remarks>
public class NotesService /* : INotesService */ {
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Note>> GetNotesAsync() {
        return await Task.Run( () => new Note[] {
                new Note {
                    CreatedAt = DateTime.Now,
                    Text = "レターパックでとんじる送れは全部詐欺です",
                    UserId = "hogepiyo"
                }
            } );
    }
}
