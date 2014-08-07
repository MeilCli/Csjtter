using Newtonsoft.Json.Linq;

namespace Csjtter.json {
    public class JsonObject {

        private JObject obj;

        public JsonObject(JObject obj) {
            this.obj=obj;
        }

        public JsonObject(string obj) {
            this.obj=JObject.Parse(obj);
        }

        public bool containsKey(string key) {
            return obj[key]!=null;
        }

        public JsonArray getJsonArray(string key) {
            object res=obj[key];
            if(res!=null&&res is JArray) {
                return new JsonArray((JArray)res);
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("JsonObject#getJsonArray null field "+key);
            }
            return null;
        }

        public JsonObject getJsonObject(string key) {
            object res=obj[key];
            if(res!=null&&res is JObject) {
                return new JsonObject((JObject)res);
            } else if(CsjtterConfig.isTest==true) {
                System.Console.Out.WriteLine("JsonObject#getJsonObject null field "+key);
            }
            return null;
        }

        public string getString(string key, string defaultValue="") {
            if(obj[key]==null||obj[key].Type==JTokenType.Null) {
                if(CsjtterConfig.isTest==true) {
                    System.Console.Out.WriteLine("JsonObject#getString null field "+key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<string>();
        }

        public bool getBoolean(string key, bool defaultValue=false) {
            if(obj[key]==null||obj[key].Type==JTokenType.Null) {
                if(CsjtterConfig.isTest==true) {
                    System.Console.Out.WriteLine("JsonObject#getBoolean null field "+key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<bool>();
        }

        public int getInt(string key, int defaultValue=0) {
            if(obj[key]==null||obj[key].Type==JTokenType.Null) {
                if(CsjtterConfig.isTest==true) {
                    System.Console.Out.WriteLine("JsonObject#getInt null field "+key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<int>();
        }

        public long getLong(string key, long defaultValue=0) {
            if(obj[key]==null||obj[key].Type==JTokenType.Null) {
                if(CsjtterConfig.isTest==true) {
                    System.Console.Out.WriteLine("JsonObject#getLong null field "+key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<long>();
        }

        public float getFloat(string key, float defaultValue = 0) {
            if(obj[key] == null || obj[key].Type == JTokenType.Null) {
                if(CsjtterConfig.isTest == true) {
                    System.Console.Out.WriteLine("JsonObject#getFloat null field " + key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<float>();
        }

        public double getDouble(string key, double defaultValue = 0) {
            if(obj[key] == null || obj[key].Type == JTokenType.Null) {
                if(CsjtterConfig.isTest == true) {
                    System.Console.Out.WriteLine("JsonObject#getDouble null field " + key);
                }
                return defaultValue;
            }
            return obj[key].ToObject<double>();
        }
    }
}
