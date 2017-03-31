using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Devin;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;


namespace CommonTest
{
    public class HttpHelperTest1
    {

        public void handle_pic(string str)
        {
            //string str = "{ \"Code\" : 0, \"Succeed\" : true, \"total\" : 29085, \"exresume\" : true, \"Data\" : [{\"个人信息\":{data:{\"个人照片\":\"/upload/headpic/2017-01-07/small_5e4685c69325450390414f0a93e90da1.jpg\"}}}]}";

            var mJObj = JObject.Parse(str);
            var data = mJObj["Data"].ToString();
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

        public void download_pic(string pic,string id)
        {
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = "http://zpm.hr.duoyi.com" + pic,//URL      必需项
                Encoding = null,//编码格式（utf-8,gb2312,gbk）     可选项 默认类会自动识别
                                //Encoding = Encoding.Default,
                ResultType = ResultType.Byte,                
                Method = "Get",
                Cookie = "ASP.NET_SessionId=vqaf2ces4xdgqsfhpjf12woq; BB554C9A4669DDD0814768708F3C70E1FBAABC0DA15B785466AA0BE673811EA612ED66EC5AB7D741=526CA2D636B66911E2F7DC3F2A59A5F5A4577BFE340229C974777DE58D39EFC5; Dy_zhaopin_sys_ck=BB554C9A4669DDD0814768708F3C70E1FBAABC0DA15B785466AA0BE673811EA612ED66EC5AB7D741; __VERSION__=1484102849372; userInfo=%7B%22user_acct%22%3A%22shenjinlong%40henhaoji.com%22%2C%22user_name%22%3A%22%E6%B2%88%E9%87%91%E9%BE%99%22%7D; Hm_lvt_e05750f7254f66ecb2bd6a43ab5369ef=1484126259; Hm_lpvt_e05750f7254f66ecb2bd6a43ab5369ef=1484127112",
                Postdata = "t=1482892805383&page_index=1&page_in_line=5000&where=%7B%22%E5%85%A8%E9%83%A8%E7%AE%80%E5%8E%86%22%3A1%7D&filter=_id%7Ccode%7Cdelive_time%7C%E4%B8%AA%E4%BA%BA%E4%BF%A1%E6%81%AF%7C%E6%B1%82%E8%81%8C%E6%84%8F%E5%90%91%7C%E6%93%8D%E4%BD%9C%E8%AF%A6%E6%83%85%7C%E6%93%8D%E4%BD%9C%E8%AE%B0%E5%BD%95%7C%E7%AE%80%E5%8E%86%E7%8A%B6%E6%80%81%7C%E8%80%83%E8%AF%95%E6%88%90%E7%BB%A9%7C%E9%9D%A2%E8%AF%95%E6%95%B0%E6%8D%AE%7Ctype%7C%E6%8F%8F%E8%BF%B0%E6%A0%87%E7%AD%BE%7CHR%E9%9D%A2%E8%AF%95%E8%AF%84%E4%BB%B7%7C%E4%B8%93%E4%B8%9A%E9%9D%A2%E8%AF%95%E8%AF%84%E4%BB%B7%7C%E9%87%8D%E5%A4%8D%E7%AE%80%E5%8E%86%7Cposition_id%7Ccampus_id%7Cis_submit%7Cdata_state%7Cuser_id%7C%E7%8A%B6%E6%80%81%E6%A0%87%E7%AD%BE%E6%9F%A5%E8%AF%A2%7C%E7%8A%B6%E6%80%81%E6%A0%87%E7%AD%BE%7C%E8%96%AA%E8%B5%84%E5%AE%A1%E6%A0%B8%7Cpaper_link"
            };
            //得到HTML代码
            HttpResult result = http.GetHtml(item);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //表示访问成功，具体的大家就参考HttpStatusCode类
            }
            //表示StatusCode的文字说明与描述
            string statusCodeDescription = result.StatusDescription;
            //把得到的Byte转成图片
            Image img = byteArrayToImage(result.ResultByte);
            string l = (pic.Split('.'))[1].ToString();
            string filename = "image/" + id + "." + l;
            Bitmap map = new Bitmap(img);
            map.Save(filename);
        }
                private Image byteArrayToImage(byte[] Bytes)
        {
            Image photo = null;
            using (MemoryStream ms = new MemoryStream(Bytes, 0, Bytes.Length))
            {
                ms.Write(Bytes, 0, Bytes.Length);
                ms.Position = 0;
                //Bitmap image = new Bitmap(ms);
                photo = Image.FromStream(ms);
                //image.Save("a.jpg");
            }
            return photo;
        }

        public static byte[] GetByteImage(Image img)

        {

            byte[] bt = null;

            if (!img.Equals(null))
            {
                using (MemoryStream mostream = new MemoryStream())
                {
                    Bitmap bmp = new Bitmap(img);

                    bmp.Save(mostream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图像以指定的格式存入缓存内存流

                    bt = new byte[mostream.Length];

                    mostream.Position = 0;//设置留的初始位置

                    mostream.Read(bt, 0, Convert.ToInt32(bt.Length));

                }

            }
            return bt;
        }
    }
}

public class Downloader
{
    /// <summary>
    /// 下载图片
    /// </summary>
    /// <param name="picUrl">图片Http地址</param>
    /// <param name="savePath">保存路径</param>
    /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
    /// <returns></returns>
    public static bool DownloadPicture(string picUrl, string savePath, int timeOut)
    {
        bool value = false;
        WebResponse response = null;
        Stream stream = null;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(picUrl);
            if (timeOut != -1) request.Timeout = timeOut;
            response = request.GetResponse();
            stream = response.GetResponseStream();
            if (!response.ContentType.ToLower().StartsWith("text/"))
                value = SaveBinaryFile(response, savePath);
        }
        finally
        {
            if (stream != null) stream.Close();
            if (response != null) response.Close();
        }
        return value;
    }
    private static bool SaveBinaryFile(WebResponse response, string savePath)
    {
        bool value = false;
        byte[] buffer = new byte[1024];
        Stream outStream = null;
        Stream inStream = null;
        try
        {
            if (File.Exists(savePath)) File.Delete(savePath);
            outStream = System.IO.File.Create(savePath);
            inStream = response.GetResponseStream();
            int l;
            do
            {
                l = inStream.Read(buffer, 0, buffer.Length);
                if (l > 0) outStream.Write(buffer, 0, l);
            } while (l > 0);
            value = true;
        }
        finally
        {
            if (outStream != null) outStream.Close();
            if (inStream != null) inStream.Close();
        }
        return value;
    }
}



