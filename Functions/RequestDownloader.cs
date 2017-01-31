using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Functions
{
    public class RequestDownloader
    {
        public static void run(string url)
        {
            if (!Directory.Exists("xml"))
            {
                Directory.CreateDirectory("xml");

            }
            using (var webClient = new WebClient())
            {
                webClient.DownloadFile(url + "TemplateAllList.xml", "Xml/TemplateAllList.xml");
                Thread.Sleep(1000);
                webClient.DownloadFile(url + "BallList.xml", "Xml/BallList.xml");
                Thread.Sleep(1000);
                webClient.DownloadFile(url + "bombconfig.xml", "Xml/bombconfig.xml");
                Thread.Sleep(1000);

                MessageBox.Show("Download das xml's Concluído!",
               "XML",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
            }


        }
    }
}
