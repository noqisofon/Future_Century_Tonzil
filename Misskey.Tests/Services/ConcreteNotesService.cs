using Misskey.Domain;
using Misskey.Services;

namespace Misskey.Tests.Services;

/// <summary>
///
/// </summary>
public class ConcreteNotesService : INotesService {

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<IEnumerable<Note>> GetNotesAsync() {
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