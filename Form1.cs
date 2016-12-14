using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.IO;

namespace ResourceDownloader
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_Templatealllist = new OpenFileDialog();
            Open_Templatealllist.Filter = "Templatealllist (*.xml)|*.xml";
            Open_Templatealllist.ShowDialog();
            textBox_template.Text = (Open_Templatealllist.FileName).Replace(@"\",@"\\");
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XmlDocument xmldocument = new XmlDocument();
            xmldocument.Load(textBox_template.Text);
            string reslink = textBox_LinkResource.Text;
            string[] pasta = new string[5]
            {
                "/00.png",       //0
                "/1/icon.png",   //1
                "/1/0/game.png", //2
                "/1/0/show.png", //3
                "/1/1/game.png", //4
            };

            string[] data = new string[5];
            string[] baixar;
            string[] diretorio;

            foreach (XmlNode selectNode in xmldocument.SelectNodes("/Result/ItemTemplate/*"))
            {
                if (selectNode.Attributes["CategoryID"].Value == "7" || selectNode.Attributes["CategoryID"].Value == "27")
                {
                    baixar = new string[5]
                    {
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/00.png",      //0
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/icon.png",  //1
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0/game.png",//2
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0/show.png",//3
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/1/game.png",//4
                    };

                    diretorio = new string[4]
                    {
                        "image/arm/" + selectNode.Attributes["Pic"].Value,          //0
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1",   //1
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0", //2
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/1", //3
                    };

                    string uri = reslink + "image/arm/" + selectNode.Attributes["Pic"].Value;

                    for (int i = 0; i <= 4; i++)
                    {
                        data[i] = uri + pasta[i];
                        try
                        {
                            if (i != 4)
                            {
                                if (!Directory.Exists(diretorio[i]))
                                    Directory.CreateDirectory(diretorio[i]);
                            }
                            WebClient client = new WebClient();
                            textBox_Load.Text += Environment.NewLine + data[i];
                            textBox_Load.SelectionStart = textBox_Load.Text.Length;
                            textBox_Load.ScrollToCaret();
                            client.DownloadFile(data[i], baixar[i]);
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

        }

        private void textBox_Load_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_LinkResource_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
