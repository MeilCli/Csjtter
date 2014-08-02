using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csjtter.test {
    public class OauthTest {
        public void mainTest() {
            AccountKey key=new AccountKey("秘密","");
            Csjtter csj=new Csjtter(key, new CsjtterConfig() { isLog=2 });
            csj.getRequestToken();
            Console.Out.WriteLine("OauthTest.cs authorizeURL");
            Console.Out.WriteLine(csj.getAuthorizeURL());
            AccountData data=csj.getOauthToken(Console.ReadLine());
            Console.Out.WriteLine(data.ToString());
            csj.statusesUpdate("oauthライブラリtest4 #CS $CS");
            //AccountKey key2=new AccountKey("","","","");
            //CsjtterBase csj=new CsjtterBase(key2, new CsjtterConfig() { isLog=2 });
            // csj.test();
        }
    }
}
