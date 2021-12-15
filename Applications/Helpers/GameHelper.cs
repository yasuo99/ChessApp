using Newtonsoft.Json;

namespace ChessApp.Applications.Helpers
{
    public class GameHelper
    {
        public static T ParseObject<T>(string serializedString){
            return JsonConvert.DeserializeObject<T>(serializedString);
        }
        public static string SerializedObject<T>(T subject){
            var jsonSerializeSettings = new JsonSerializerSettings();
            jsonSerializeSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return JsonConvert.SerializeObject(subject, jsonSerializeSettings);
        }
    }
}