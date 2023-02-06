using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Crwal.Core.Log;
using Newtonsoft.Json;
using VCCorp_Crawler_si_demand_source_INS.Config;

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
            Logging.Init();
            try
            {
                Program.Init();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
            }
            catch (Exception)
            {

                throw;
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
                IgRunTime.Config = new IgConfig();
                IgRunTime.Config.Kafka = new Kafka()
                {
                    SERVER_LINK = config.Kafka.SERVER_LINK,
                    _commentTableName = config.Kafka._commentTableName,
                    _topicTableName = config.Kafka._topicTableName
                };

                IgRunTime.Config.DbConnection = new DbConnection()
                {
                    NewsDbLocal = config.DbConnection.NewsDbLocal,
                    FBExce = config.DbConnection.FBExce,
                };
                Console.WriteLine(IgRunTime.Config);
                Logging.Infomation("Khởi tạo cấu hình thành công");
            }
            catch (Exception ex)
            {

                Logging.Error(ex);
            }
        }

    }
}
