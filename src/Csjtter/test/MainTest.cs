using Csjtter.http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.test {
    public class MainTest {
        public void mainTest() {
            string json="{\"errors\":[{\"message\":\"Sorry, that page does not exist\",\"code\":34}],\"ni\":null,\"ni2\":2}";
            JObject obj=JObject.Parse(json);
            System.Console.Out.WriteLine(obj["errors"]!=null);
            System.Console.Out.WriteLine(obj["error"]!=null);
            System.Console.Out.WriteLine(obj["ni"]!=null);
            System.Console.Out.WriteLine(obj["ni"].HasValues);
        }
    }
}
