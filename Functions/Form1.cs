using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Functions
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private bool _stoploop;
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
            
            if((textBox_MapServerList.Text == String.Empty && textBox_LinkResource.Text == String.Empty) || (textBox_BallList.Text == String.Empty && textBox_MapServerList.Text == String.Empty))
            {
                MessageBox.Show("String Inválida",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

            #region Desativa botoes

            btn_iniciar.Enabled = false;
            btn_Template.Enabled = false;
            button_BallList.Enabled = false;
            button_MapServerList.Enabled = false;

            #endregion
            _stoploop = false;

            Templatealllist templatealllist = new Templatealllist();

            string loc_Template = textBox_template.Text;
            //Salvar o link da resource
            string reslink = textBox_LinkResource.Text;

            templatealllist.ARM(loc_Template,reslink);

        }
        public void textBox_Load_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_LinkResource_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            _stoploop = true;
        }

        private void button_BaixarXmls_Click(object sender, EventArgs e)
        {
            if(textBox_LinkReq.Text == String.Empty || textBox_LinkReq.Text == @"Exemplo : http://ddtank.com/request/")
            {
                MessageBox.Show("String Inválida",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }

        RequestDownloader.run(textBox_LinkReq.Text);
        }

        private void button_MapServerList_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_Templatealllist = new OpenFileDialog();
            Open_Templatealllist.Filter = "MapServerList (*.xml)|*.xml";
            Open_Templatealllist.ShowDialog();
            textBox_MapServerList.Text = (Open_Templatealllist.FileName).Replace(@"\", @"\\");
        }

        private void button_BallList_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open_Templatealllist = new OpenFileDialog();
            Open_Templatealllist.Filter = "BallList (*.xml)|*.xml";
            Open_Templatealllist.ShowDialog();
            textBox_BallList.Text = (Open_Templatealllist.FileName).Replace(@"\", @"\\");
        }
    }
}
