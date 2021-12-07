using Newtonsoft.Json;

namespace ChessApp.Applications.Helpers
{
    public class GameHelper
    {
        public static T ParseObject<T>(string serializedString){
            return JsonConvert.DeserializeObject<T>(serializedString);
        }
        public string SerializedObject<T>(T subject){
            return JsonConvert.SerializeObject(subject);
        }
    }
}