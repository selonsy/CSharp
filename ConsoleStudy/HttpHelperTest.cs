using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin;
namespace CommonTest
{
    public class HttpHelperTest
    {
        public void Excute(int page)
        {
            //豆瓣Top250
            //HttpItem request = new HttpItem();
            //request.URL = "https://api.douban.com/v2/movie/top250?count=10";
            //HttpResult result = new HttpHelper().GetHtml(request);
            //Console.WriteLine(result.Html);
            //new FileOperateHelper().Write_Txt("movie.txt", result.Html);

            HttpItem request = new HttpItem();
            request.URL = "http://zpm.hr.duoyi.com/login/user_login?t=1482907957038&acct=shenjinlong@henhaoji.com&password=60184CBFC4C3B14BA37C3A18589D8236&vercode=";
            request.Method = "POST";
            request.Cookie = "ASP.NET_SessionId=lxinwana55sb1rx4gqtfxbjf; __VERSION__=1482750930211; zpm_vercode=zpm_need=578F68AC76FD552A";
            request.Postdata = "t=1482907957038&acct=shenjinlong%40henhaoji.com&password=60184CBFC4C3B14BA37C3A18589D8236&vercode=";
            HttpResult result = new HttpHelper().GetHtml(request);

            HttpItem request1 = new HttpItem();
            request1.URL = string.Format("http://zpm.hr.duoyi.com/resume/resume_xz_list?page_index={0}&page_in_line=1000",page);
            request1.Method = "POST";
            request1.Cookie = "ASP.NET_SessionId=vqaf2ces4xdgqsfhpjf12woq; BB554C9A4669DDD0814768708F3C70E1FBAABC0DA15B785466AA0BE673811EA612ED66EC5AB7D741=526CA2D636B66911E2F7DC3F2A59A5F5A4577BFE340229C974777DE58D39EFC5; Dy_zhaopin_sys_ck=BB554C9A4669DDD0814768708F3C70E1FBAABC0DA15B785466AA0BE673811EA612ED66EC5AB7D741; __VERSION__=1484102849372; userInfo=%7B%22user_acct%22%3A%22shenjinlong%40henhaoji.com%22%2C%22user_name%22%3A%22%E6%B2%88%E9%87%91%E9%BE%99%22%7D; Hm_lvt_e05750f7254f66ecb2bd6a43ab5369ef=1484126259; Hm_lpvt_e05750f7254f66ecb2bd6a43ab5369ef=1484127112";
            request1.Postdata = "t=1482892805383&page_index=1&page_in_line=5000&where=%7B%22%E5%85%A8%E9%83%A8%E7%AE%80%E5%8E%86%22%3A1%7D&filter=_id%7Ccode%7Cdelive_time%7C%E4%B8%AA%E4%BA%BA%E4%BF%A1%E6%81%AF%7C%E6%B1%82%E8%81%8C%E6%84%8F%E5%90%91%7C%E6%93%8D%E4%BD%9C%E8%AF%A6%E6%83%85%7C%E6%93%8D%E4%BD%9C%E8%AE%B0%E5%BD%95%7C%E7%AE%80%E5%8E%86%E7%8A%B6%E6%80%81%7C%E8%80%83%E8%AF%95%E6%88%90%E7%BB%A9%7C%E9%9D%A2%E8%AF%95%E6%95%B0%E6%8D%AE%7Ctype%7C%E6%8F%8F%E8%BF%B0%E6%A0%87%E7%AD%BE%7CHR%E9%9D%A2%E8%AF%95%E8%AF%84%E4%BB%B7%7C%E4%B8%93%E4%B8%9A%E9%9D%A2%E8%AF%95%E8%AF%84%E4%BB%B7%7C%E9%87%8D%E5%A4%8D%E7%AE%80%E5%8E%86%7Cposition_id%7Ccampus_id%7Cis_submit%7Cdata_state%7Cuser_id%7C%E7%8A%B6%E6%80%81%E6%A0%87%E7%AD%BE%E6%9F%A5%E8%AF%A2%7C%E7%8A%B6%E6%80%81%E6%A0%87%E7%AD%BE%7C%E8%96%AA%E8%B5%84%E5%AE%A1%E6%A0%B8%7Cpaper_link";
            HttpResult result1 = new HttpHelper().GetHtml(request1);

            //Console.WriteLine(result1.Html);
            //new FileOperateHelper().Write_Txt("heheda7.txt", result1.Html);
            new HttpHelperTest1().handle_pic(result1.Html);
        }
    }
}
