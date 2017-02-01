using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Forms;

using Base.Factories;


namespace Functions
{
    public class Templatealllist
    {
        public void ARM(string loc_Template, string reslink)
        {
            XmlDocument xmldocument = new XmlDocument();
            //Carregar xml templatealllist
            xmldocument.Load(loc_Template);
            //Salvar o link da resource
            string[] pasta = new string[5] {
                "/00.png", //0
                "/1/icon.png", //1
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
                    baixar = new string[5] {
                    "image/arm/" + selectNode.Attributes["Pic"].Value + "/00.png", //0
                    "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/icon.png", //1
                    "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0/game.png", //2
                    "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0/show.png", //3
                    "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/1/game.png", //4
				    };
                    diretorio = new string[4] {
                        "image/arm/" + selectNode.Attributes["Pic"].Value, //0
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1", //1
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/0", //2
                        "image/arm/" + selectNode.Attributes["Pic"].Value + "/1/1", //3
				    };

                    string uri = reslink + "image/arm/" + selectNode.Attributes["Pic"].Value;

                    for (int i = 0; i <= 4; i++)
                    {
                        //Uni o link com onde irar ser salvo
                        data[i] = uri + pasta[i];
                        try
                        {
                            //A array diretório só tem 4 elementos.
                            if (i != 4)
                            {
                                //Criar a pasta.
                                if (!Directory.Exists(diretorio[i]))
                                    Directory.CreateDirectory(diretorio[i]);
                            }

                            WebClient client = new WebClient();

                            LoggerFactory.GetLogger().LogSuccess(data[i]); //Arquivos Download
                            client.DownloadFile(data[i], baixar[i]);

                           
                        }
                        catch (Exception ex)
                        {
                            LoggerFactory.GetLogger().LogError("Erro: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
