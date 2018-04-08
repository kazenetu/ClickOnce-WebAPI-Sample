using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinClient.connectLib;

namespace ClickOnceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // WebAPIのルートURLを取得
            var rootURL = getWebApiRootAddress();

            // Getメソッド発行
            var results = HttpConnectLib.Get<List<string>>(string.Format("{0}/test", rootURL));

            // 結果を表示
            var sb = new StringBuilder();
            foreach (var item in results)
            {
                sb.AppendLine(item.ToString());
            }
            MessageBox.Show(sb.ToString());
        }

        /// <summary>
        /// WebAPIのルートURLを取得
        /// </summary>
        /// <returns>APIのルートURL</returns>
        private string getWebApiRootAddress()
        {
            var url = string.Empty;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                // ClickOnce実行時のURL
                var updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation;
                url = string.Format("{0}://{1}:{2}/api/", updateLocation.Scheme, updateLocation.Host, updateLocation.Port);
            }
            else
            {
                // デバッグ実行時のURL
                var args = Environment.GetCommandLineArgs();
                if (args.Length >= 2)
                {
                    url = args[1] + "api/";
                }
            }

            return url;
        }

    }
}
