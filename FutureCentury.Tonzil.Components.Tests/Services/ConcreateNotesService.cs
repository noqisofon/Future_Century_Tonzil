using Misskey.Interfaces;
using Misskey.Requests;

namespace FutureCentury.Tonzil.Components.Tests.Services;

/// <summary>
///
/// </summary>
internal class ConcreateNotesService : INotesService {

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Note>> GetNotesAsync(NotesRequest? request = null) {
        return await Task.Run( () => new Note[] {
                new Note {
                    CreatedAt = DateTime.Now,
                    Text = "レターパックでとんじる送れは全部詐欺です",
                    UserId = "hogepiyo"
                },
                new Note {
                    CreatedAt = DateTime.Now,
                    Text = "ホットソースで食卓の世界が広がります",
                    UserId = "hogepiyo"
                }
            } );
    }
}