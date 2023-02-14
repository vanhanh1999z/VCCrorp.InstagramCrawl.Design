﻿using Crwal.Core.Base;
using Crwal.Core.Log;
using Crwal.Core.Sql;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using VCCorp.CrawlerCore.Base;

namespace VCCorp_Crawler_si_demand_source_INS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string projectName = Assembly.GetExecutingAssembly().GetName().Name;
            Logging.Init(projectName);
            try
            {
                Program.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch
            {
            }
        }
        public static async void Init()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "system.hcf");
                if (File.Exists(filePath))
                {
                    using (StreamReader r = new StreamReader(filePath))
                    {
                        var jsonString = r.ReadToEnd();
                        var config = JsonConvert.DeserializeObject<IgConfig>(jsonString);
                        Program.LoadConfig(config);
                    }
                }
                else
                {
                    await Logging.ErrorAsync("Không tìm thấy file cấu hình");
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

                IgRunTime.Config = new IgConfig()
                {
                    Platform = config.Platform,
                    UserCrawler = config.UserCrawler,
                    InstagramDomainUrlOnePose = config.InstagramDomainUrlOnePose,
                    DeafultLoadUrl = config.DeafultLoadUrl,
                    Kafka = new Kafka()
                    {
                        SERVER_LINK = config.Kafka.SERVER_LINK,
                        _commentTableName = config.Kafka._commentTableName,
                        _topicTableName = config.Kafka._topicTableName
                    },
                    DbConnection = new DbConnection()
                    {
                    },
                    CloudDbConnection = new DbConnection()
                    {
                    },
                    Proxy = config.Proxy,
                    InsQuery = new Query(config.InsQuery.TopSearchUrl, config.InsQuery.ProfileContentUrl)
                };
                var localConnection = new ConnectionString(config.DbConnection.ServerName, config.DbConnection.User, config.DbConnection.Password);
                var cloudConnection = new ConnectionString(config.CloudDbConnection.ServerName, config.CloudDbConnection.User, config.CloudDbConnection.Password);
                IgRunTime.Config.DbConnection.FBExce = localConnection.BuildConnectionString();
                IgRunTime.Config.CloudDbConnection.FBExce = cloudConnection.BuildConnectionString();
                Logging.Infomation("Khởi tạo cấu hình thành công");
            }
            catch (Exception ex)
            {
                Logging.Error(ex);
            }
        }

    }
}
