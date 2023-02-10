using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCCorp_Crawler_si_demand_source_INS.Config
{
    public static class IgRunTime
    {
        public static IgConfig Config { get; set; }
        public static string AppId { get; set; }
        public static string CachePath { get; set; }
        public static async Task<string> GetGlobalCookie()
        {
            var cookieManager = Cef.GetGlobalCookieManager();
            var visitor = new CookieCollector();
            cookieManager.VisitUrlCookies("https://www.instagram.com", true, (ICookieVisitor)visitor);
            var cookies = await visitor.Task;
            var cookieHeader = CookieCollector.GetCookieHeader(cookies);
            return cookieHeader;
        }

    }
    public class Query
    {
        public Query(string topSearchUrl, string profileContentUrl)
        {
            TopSearchUrl = topSearchUrl;
            ProfileContentUrl = profileContentUrl;
        }

        public string TopSearchUrl { get; set; }
        public string ProfileContentUrl { get; set; }
    }
    public class DbConnection
    {
        public string FBExce { get; set; }
        public string NewsDbLocal { get; set; }
    }
    public class Kafka
    {
        public string _topicTableName { get; set; }
        public string _commentTableName { get; set; }
        public string SERVER_LINK { get; set; }
    }
    public class IgConfig
    {
        public DbConnection DbConnection { get; set; }
        public Kafka Kafka { get; set; }
        public Query InsQuery { get; set; }
        public string Platform { get; set; }
        public string UserCrawler { get; set; }
        public string InstagramDomainUrlOnePose { get; set; }
        public string DeafultLoadUrl { get; set; }
    }
}
