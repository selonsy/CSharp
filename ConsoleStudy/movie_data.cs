using Devin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    public class movie_data
    {
        public void Excute(int page)
        {
            //豆瓣Top250
            HttpItem request = new HttpItem();
            request.URL = "https://api.douban.com/v2/movie/top250?count=10";
            HttpResult result = new HttpHelper().GetHtml(request);
            
            string str = result.Html;

            var mJObj = JObject.Parse(str);
            var data = mJObj["subjects"].ToString();
            var data_arr = JArray.Parse(data);
            string pic = string.Empty;
            string _id = string.Empty;
            foreach (var item in data_arr)
            {
                try
                {
                    if (((JObject)item)["个人信息"]["data"]["个人照片"].ToString() != "" && ((JObject)item)["_id"].ToString() != "")
                    {
                        pic = ((JObject)item)["个人信息"]["data"]["个人照片"].ToString();
                        _id = ((JObject)item)["_id"].ToString();
                    }
                    if (pic.IsNotNullOrEmpty() && _id.IsNotNullOrEmpty())
                    {
                        download_pic(pic, _id);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
