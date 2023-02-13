using System.Text.Json;
using System.Text.Json.Serialization;

namespace Misskey.Services;

/// <summary>
/// ドメインオブジェクトを JSON にシリアライズしたり、デシリアライズしたりするやつ。
/// </summary>
public class JsonService {

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="_T"></typeparam>
	/// <param name="that"></param>
	/// <returns></returns>
	public string? Serialize<_T>(_T? that) {
		var options = GetDefaultJsonSerializerOptions();

		return JsonSerializer.Serialize( that, options );
	}

	/// <summary>
	///
	/// </summary>
	/// <typeparam name="_T"></typeparam>
	/// <param name="jsonDocumentOrNull"></param>
	/// <returns></returns>
	public _T? Deserialize<_T>(string? jsonDocumentOrNull) where _T : class {
		if ( jsonDocumentOrNull is not string jsonDocument ) {
			return default;
		}
		var options = GetDefaultJsonSerializerOptions();

		return JsonSerializer.Deserialize<_T>( jsonDocument, options );
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	public JsonSerializerOptions GetDefaultJsonSerializerOptions() => new JsonSerializerOptions {
		// プロパティは型の既定値と等しい場合にのみ無視されるよ。
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
		Converters = {
				// 列挙体な値を全部小文字な文字列にするよ
				new JsonStringEnumConverter( JsonNamingPolicy.CamelCase )
			}
	};
}
