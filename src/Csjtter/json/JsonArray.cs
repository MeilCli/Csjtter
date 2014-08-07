using Newtonsoft.Json.Linq;

namespace Csjtter.json {
    public class JsonArray {

        private JArray ar;

        public JsonArray(JArray ar) {
            this.ar=ar;
        }
        public JsonArray(string ar) {
            this.ar=JArray.Parse(ar);
        }

        public int count() {
            return ar.Count;
        }

        public JsonArray getJsonArray(int index) {
            object res=ar[index];
            if(res!=null&&res is JArray) {
                return new JsonArray((JArray)res);
            }
            return null;
        }

        public JsonObject getJsonObject(int index) {
            object res=ar[index];
            if(res!=null&&res is JObject) {
                return new JsonObject((JObject)res);
            }
            return null;
        }

        public string getString(int index, string defaultValue="") {
            if(ar[index]==null) {
                return defaultValue;
            }
            return ar[index].ToObject<string>();
        }

        public bool getBoolean(int index, bool defaultValue=false) {
            if(ar[index]==null) {
                return defaultValue;
            }
            return ar[index].ToObject<bool>();
        }

        public int getInt(int index, int defaultValue=0) {
            if(ar[index]==null) {
                return defaultValue;
            }
            return ar[index].ToObject<int>();
        }

        public long getLong(int index, long defaultValue=0) {
            if(ar[index]==null) {
                return defaultValue;
            }
            return ar[index].ToObject<long>();
        }

        public float getFloat(int index, float defaultValue = 0) {
            if(ar[index] == null) {
                return defaultValue;
            }
            return ar[index].ToObject<float>();
        }

        public double getDouble(int index, double defaultValue = 0) {
            if(ar[index] == null) {
                return defaultValue;
            }
            return ar[index].ToObject<double>();
        }
    }
}
