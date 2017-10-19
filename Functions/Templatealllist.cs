using System;
using System.Xml;
using System.Net;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace Functions
{
    public class Templatealllist
    {
        public static void image(string loc_Template, string reslink)
        {
            //inicializar a função para fazer leitura do site
            WebClient client = new WebClient();
            //inicializar o leitor de xml
            XmlDocument xmldocument = new XmlDocument();
            //Carregar xml templatealllist
            xmldocument.Load(loc_Template);
            //Salvar o link da resource
            string[] pasta_arm = new string[5] {
                "/00.png", //0
                "/1/icon.png", //1
                "/1/0/game.png", //2
                "/1/0/show.png", //3
                "/1/1/game.png", //4
		    };
            string[] data;
            string[] baixar;
            string[] diretorio;
            foreach (XmlNode selectNode in xmldocument.SelectNodes("/Result/ItemTemplate/*"))
            {
                //if (param1 == 7 || param1 == 27 || param1 == 64)
                if (selectNode.Attributes["CategoryID"].Value == "7" || selectNode.Attributes["CategoryID"].Value == "27" || selectNode.Attributes["CategoryID"].Value == "64")
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
                        data = new string[5];
                        //Uni o link com onde irar ser salvo
                        data[i] = uri + pasta_arm[i];
                        try
                        {
                            //A array diretório só tem 4 elementos.
                            if (i != 4)
                            {
                                //Criar a pasta.
                                if (!Directory.Exists(diretorio[i]))
                                {
                                    Principal.textBox_Load.SelectionStart = Principal.textBox_Load.Text.Length;
                                    Principal.textBox_Load.ScrollToCaret();
                                    //Principal.textBox_Load.ForeColor = Color.Red;
                                    //Principal.textBox_Load.ReadOnly = false;
                                    Principal.textBox_Load.Text += Environment.NewLine + "Pasta Criada: " + diretorio[i];
                                    Directory.CreateDirectory(diretorio[i]);
                                }

                            }
                            //Principal.textBox_Load.ForeColor = Color.Green;
                            //Principal.textBox_Load.ReadOnly = false;
                            Principal.textBox_Load.Text += Environment.NewLine + data[i];
                            Principal.textBox_Load.SelectionStart = Principal.textBox_Load.Text.Length;
                            Principal.textBox_Load.ScrollToCaret();

                            client.DownloadFile(data[i], baixar[i]);

                        }
                        catch (Exception ex)
                        {
                            Principal.textBox_Load.Text += Environment.NewLine + "Erro: " + ex.Message;
                        }
                    }
                }
                //if(param1 == 24 || param1 == 11 || param1 == 65 || param1 == 68 || param1 == 69 || param1 == 72)
                else if (selectNode.Attributes["CategoryID"].Value == "24" || selectNode.Attributes["CategoryID"].Value == "11" || selectNode.Attributes["CategoryID"].Value == "65" || selectNode.Attributes["CategoryID"].Value == "68" || selectNode.Attributes["CategoryID"].Value == "69" || selectNode.Attributes["CategoryID"].Value == "72")
                {

                    string baixar2;
                    string diretorio2;
                    baixar2 = "image/unfrightprop/" + selectNode.Attributes["Pic"].Value + "/icon.png";
                    diretorio2 = "image/unfrightprop/" + selectNode.Attributes["Pic"].Value;

                    string uri = reslink + diretorio2;

                    string data2;

                    data2 = uri + "/icon.png";

                    try{
                        if (!Directory.Exists(diretorio2))
                        {
                            Principal.textBox_Load.SelectionStart = Principal.textBox_Load.Text.Length;
                            Principal.textBox_Load.ScrollToCaret();
                            //Principal.textBox_Load.ForeColor = Color.Red;
                            //Principal.textBox_Load.ReadOnly = false;
                            Principal.textBox_Load.Text += Environment.NewLine + "Pasta Criada: " + diretorio2;
                            Directory.CreateDirectory(diretorio2);
                        }

                        Principal.textBox_Load.Text += Environment.NewLine + data2;
                        Principal.textBox_Load.SelectionStart = Principal.textBox_Load.Text.Length;
                        Principal.textBox_Load.ScrollToCaret();
                        client.DownloadFile(data2, baixar2);
                    } catch(Exception ex) {
                        Principal.textBox_Load.Text += Environment.NewLine + "Erro: " + ex.Message;
                    }
                }
            }
        }
    }
}
