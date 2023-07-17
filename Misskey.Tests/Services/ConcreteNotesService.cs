using Misskey.Domain;
using Misskey.Interfaces;
using Misskey.Requests;

namespace Misskey.Tests.Services;

/// <summary>
///
/// </summary>
public class ConcreteNotesService : INotesService {

    /// <summary>
    /// ノート一覧を取得します。
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<IEnumerable<Note>> GetNotesAsync(NotesRequest? request = null) {
        return await Task.Run( () => new Note[] {
                new Note {
                    Id = Guid.NewGuid().ToString("N"),
                    CreatedAt = DateTime.Now,
                    Text = "レターパックでとんじる送れは全部詐欺です",
                    UserId = "hogepiyo"
                }
            } );
    }
}