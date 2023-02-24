using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Crwal.Core.Log;
using Crwal.Core.Sql;
using Newtonsoft.Json;
using VCCorp.CrawlerCore.Base;

namespace VCCorp.Instagram.CrawlerJob
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var projectName = Assembly.GetExecutingAssembly().GetName().Name;
            Logging.Init(projectName);
            Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }

        public static async void Init()
        {
            try
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "system.hcf");
                if (File.Exists(filePath))
                {
                    using (var r = new StreamReader(filePath))
                    {
                        var jsonString = r.ReadToEnd();
                        var config = JsonConvert.DeserializeObject<IgConfig>(jsonString);
                        LoadConfig(config);
                    }
                }
                else
                {
                    await "Không tìm thấy file cấu hình".ErrorAsync();
                    await filePath.ErrorAsync();
                }
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

        public static void LoadConfig(IgConfig config)
        {
            try
            {
                IgRunTime.Config = new IgConfig
                {
                    Platform = config.Platform,
                    UserCrawler = config.UserCrawler,
                    InstagramDomainUrlOnePose = config.InstagramDomainUrlOnePose,
                    DeafultLoadUrl = config.DeafultLoadUrl,
                    Kafka = new Kafka
                    {
                        SERVER_LINK = config.Kafka.SERVER_LINK,
                        _commentTableName = config.Kafka._commentTableName,
                        _topicTableName = config.Kafka._topicTableName
                    },
                    DbConnection = new DbConnection(),
                    CloudDbConnection = new DbConnection(),
                    Proxy = config.Proxy,
                    InsQuery = new Query(config.InsQuery.TopSearchUrl, config.InsQuery.ProfileContentUrl)
                };
                var localConnection = new ConnectionString(config.DbConnection.ServerName, config.DbConnection.User,
                    config.DbConnection.Password);
                var cloudConnection = new ConnectionString(config.CloudDbConnection.ServerName,
                    config.CloudDbConnection.User, config.CloudDbConnection.Password);
                IgRunTime.Config.DbConnection.FBExce = localConnection.BuildConnectionString();
                IgRunTime.Config.CloudDbConnection.FBExce = cloudConnection.BuildConnectionString();
                "Khởi tạo cấu hình thành công".Infomation();
            }
            catch (Exception ex)
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "system.hcf");
                Logging.Error(ex);
            }
        }
    }
}