using Misskey.Domain;
using Misskey.Interfaces;
using Misskey.Requests;

namespace Misskey.Services;

/// <summary>
/// <c>/notes</c> から始まるエンドポイント用のサービスです。
/// </summary>
/// <remarks>
///     <para>
///     <see cref="NotesService"/> は <see cref="Misskey.Interfaces.INotesService" /> を実装したもの。
///     <c>Timeline</c> と <c>NoteCard</c> のテストのためのとりあえずの実装。
///     </para>
/// </remarks>
public class NotesService : INotesService
{

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Note>> GetNotesAsync(NotesRequest? request = null)
    {
        return await Task.Run(() => new Note[] {
                new Note {
                    CreatedAt = DateTime.Now,
                    Text = "レターパックでとんじる送れは全部詐欺です",
                    UserId = "hogepiyo"
                }
            });
    }
}