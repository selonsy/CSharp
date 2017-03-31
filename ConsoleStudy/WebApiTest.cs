using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin;

namespace WebApi.WebApiTests.WebApi
{
    public class WebApiTests
    {
        public void WebApiTest()
        {
            int tokenid = 9527;
            string tokenurl = "http://test.shenjinlong.com:8002/api/auth/gettoken/";
            //var tokenResult = WebApiHelper.GetSignToken(tokenurl, tokenid);
            Dictionary<string, string> parames = new Dictionary<string, string>();
            parames.Add("Id", "1024");
            parames.Add("UserName", "wahaha");
            Tuple<string, string> parameters = WebApiHelper.GetQueryString(parames);
            //UsersModel user1 = WebApiHelper.Get<UsersModel>("http://test.shenjinlong.com:8002/api/user/getuser/", tokenurl, parameters.Item1, parameters.Item2, tokenid);
            //UsersModel user2 = new UsersModel() { Id = "9528", UserName = "安慕希" };
            //UsersModel user3 = WebApiHelper.Post<UsersModel>("http://test.shenjinlong.com:8002/api/user/adduser/", tokenurl,Newtonsoft.Json.JsonConvert.SerializeObject(user2), tokenid);

            //测试
            //bool issuccess = true;
            //if (!(user1.Id == "1024") || !(user1.UserName == "wahaha"))
            //{
            //    issuccess = false;
            //}
            //if (!(user3.Id == "9528") || !(user3.UserName == "安慕希"))
            //{
            //    issuccess = false;
            //}
            //Assert.IsTrue(issuccess);
        }
    }

    public class UsersModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
