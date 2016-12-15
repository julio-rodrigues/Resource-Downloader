namespace ResourceDownloader
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.textBox_template = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Template = new System.Windows.Forms.Button();
            this.Open_Templatealllist = new System.Windows.Forms.OpenFileDialog();
            this.btn_iniciar = new System.Windows.Forms.Button();
            this.progressBar_load = new System.Windows.Forms.ProgressBar();
            this.textBox_Load = new System.Windows.Forms.TextBox();
            this.BallList = new System.Windows.Forms.Label();
            this.textBox_BallList = new System.Windows.Forms.TextBox();
            this.button_BallList = new System.Windows.Forms.Button();
            this.MapServerList = new System.Windows.Forms.Label();
            this.textBox_MapServerList = new System.Windows.Forms.TextBox();
            this.button_MapServerList = new System.Windows.Forms.Button();
            this.textBox_LinkResource = new System.Windows.Forms.TextBox();
            this.LinkResource = new System.Windows.Forms.Label();
            this.button_stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_template
            // 
            this.textBox_template.BackColor = System.Drawing.Color.White;
            this.textBox_template.Location = new System.Drawing.Point(12, 34);
            this.textBox_template.Name = "textBox_template";
            this.textBox_template.Size = new System.Drawing.Size(286, 20);
            this.textBox_template.TabIndex = 0;
            this.textBox_template.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImageKey = "(none)";
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Templatealllist";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_Template
            // 
            this.btn_Template.BackColor = System.Drawing.Color.Transparent;
            this.btn_Template.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Template.Location = new System.Drawing.Point(304, 34);
            this.btn_Template.Name = "btn_Template";
            this.btn_Template.Size = new System.Drawing.Size(67, 20);
            this.btn_Template.TabIndex = 6;
            this.btn_Template.Text = "Carregar";
            this.btn_Template.UseVisualStyleBackColor = false;
            this.btn_Template.Click += new System.EventHandler(this.button1_Click);
            // 
            // Open_Templatealllist
            // 
            this.Open_Templatealllist.FileName = "Open_Templatealllist";
            this.Open_Templatealllist.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btn_iniciar
            // 
            this.btn_iniciar.Location = new System.Drawing.Point(497, 380);
            this.btn_iniciar.Name = "btn_iniciar";
            this.btn_iniciar.Size = new System.Drawing.Size(75, 23);
            this.btn_iniciar.TabIndex = 7;
            this.btn_iniciar.Text = "Baixar";
            this.btn_iniciar.UseVisualStyleBackColor = true;
            this.btn_iniciar.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // progressBar_load
            // 
            this.progressBar_load.Location = new System.Drawing.Point(12, 380);
            this.progressBar_load.Name = "progressBar_load";
            this.progressBar_load.Size = new System.Drawing.Size(479, 23);
            this.progressBar_load.TabIndex = 9;
            // 
            // textBox_Load
            // 
            this.textBox_Load.Location = new System.Drawing.Point(12, 213);
            this.textBox_Load.MaxLength = 9999999;
            this.textBox_Load.Multiline = true;
            this.textBox_Load.Name = "textBox_Load";
            this.textBox_Load.ReadOnly = true;
            this.textBox_Load.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Load.Size = new System.Drawing.Size(479, 161);
            this.textBox_Load.TabIndex = 10;
            this.textBox_Load.TextChanged += new System.EventHandler(this.textBox_Load_TextChanged);
            // 
            // BallList
            // 
            this.BallList.AutoSize = true;
            this.BallList.BackColor = System.Drawing.Color.Transparent;
            this.BallList.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BallList.ForeColor = System.Drawing.Color.Black;
            this.BallList.ImageKey = "(none)";
            this.BallList.Location = new System.Drawing.Point(8, 57);
            this.BallList.Name = "BallList";
            this.BallList.Size = new System.Drawing.Size(66, 23);
            this.BallList.TabIndex = 11;
            this.BallList.Text = "BallList";
            // 
            // textBox_BallList
            // 
            this.textBox_BallList.BackColor = System.Drawing.Color.White;
            this.textBox_BallList.Location = new System.Drawing.Point(12, 83);
            this.textBox_BallList.Name = "textBox_BallList";
            this.textBox_BallList.Size = new System.Drawing.Size(286, 20);
            this.textBox_BallList.TabIndex = 12;
            // 
            // button_BallList
            // 
            this.button_BallList.Location = new System.Drawing.Point(304, 83);
            this.button_BallList.Name = "button_BallList";
            this.button_BallList.Size = new System.Drawing.Size(67, 20);
            this.button_BallList.TabIndex = 13;
            this.button_BallList.Text = "Carregar";
            this.button_BallList.UseVisualStyleBackColor = true;
            // 
            // MapServerList
            // 
            this.MapServerList.AutoSize = true;
            this.MapServerList.BackColor = System.Drawing.Color.Transparent;
            this.MapServerList.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapServerList.ForeColor = System.Drawing.Color.Black;
            this.MapServerList.ImageKey = "(none)";
            this.MapServerList.Location = new System.Drawing.Point(12, 106);
            this.MapServerList.Name = "MapServerList";
            this.MapServerList.Size = new System.Drawing.Size(124, 23);
            this.MapServerList.TabIndex = 14;
            this.MapServerList.Text = "MapServerList";
            // 
            // textBox_MapServerList
            // 
            this.textBox_MapServerList.BackColor = System.Drawing.Color.White;
            this.textBox_MapServerList.Location = new System.Drawing.Point(12, 132);
            this.textBox_MapServerList.Name = "textBox_MapServerList";
            this.textBox_MapServerList.Size = new System.Drawing.Size(286, 20);
            this.textBox_MapServerList.TabIndex = 15;
            // 
            // button_MapServerList
            // 
            this.button_MapServerList.Location = new System.Drawing.Point(304, 132);
            this.button_MapServerList.Name = "button_MapServerList";
            this.button_MapServerList.Size = new System.Drawing.Size(67, 20);
            this.button_MapServerList.TabIndex = 16;
            this.button_MapServerList.Text = "Carregar";
            this.button_MapServerList.UseVisualStyleBackColor = true;
            // 
            // textBox_LinkResource
            // 
            this.textBox_LinkResource.BackColor = System.Drawing.Color.White;
            this.textBox_LinkResource.Location = new System.Drawing.Point(12, 181);
            this.textBox_LinkResource.Name = "textBox_LinkResource";
            this.textBox_LinkResource.Size = new System.Drawing.Size(286, 20);
            this.textBox_LinkResource.TabIndex = 17;
            this.textBox_LinkResource.TextChanged += new System.EventHandler(this.textBox_LinkResource_TextChanged);
            // 
            // LinkResource
            // 
            this.LinkResource.AutoSize = true;
            this.LinkResource.BackColor = System.Drawing.Color.Transparent;
            this.LinkResource.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkResource.ForeColor = System.Drawing.Color.Black;
            this.LinkResource.ImageKey = "(none)";
            this.LinkResource.Location = new System.Drawing.Point(12, 155);
            this.LinkResource.Name = "LinkResource";
            this.LinkResource.Size = new System.Drawing.Size(115, 23);
            this.LinkResource.TabIndex = 18;
            this.LinkResource.Text = "Link Resource";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(497, 351);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 19;
            this.button_stop.Text = "Parar";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(584, 415);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.LinkResource);
            this.Controls.Add(this.textBox_LinkResource);
            this.Controls.Add(this.button_MapServerList);
            this.Controls.Add(this.textBox_MapServerList);
            this.Controls.Add(this.MapServerList);
            this.Controls.Add(this.button_BallList);
            this.Controls.Add(this.textBox_BallList);
            this.Controls.Add(this.BallList);
            this.Controls.Add(this.textBox_Load);
            this.Controls.Add(this.progressBar_load);
            this.Controls.Add(this.btn_iniciar);
            this.Controls.Add(this.btn_Template);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_template);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Resource Downloader";
            this.TransparencyKey = System.Drawing.Color.Crimson;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_template;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Template;
        private System.Windows.Forms.OpenFileDialog Open_Templatealllist;
        private System.Windows.Forms.Button btn_iniciar;
        private System.Windows.Forms.ProgressBar progressBar_load;
        private System.Windows.Forms.TextBox textBox_Load;
        private System.Windows.Forms.Label BallList;
        private System.Windows.Forms.TextBox textBox_BallList;
        private System.Windows.Forms.Button button_BallList;
        private System.Windows.Forms.Label MapServerList;
        private System.Windows.Forms.TextBox textBox_MapServerList;
        private System.Windows.Forms.Button button_MapServerList;
        private System.Windows.Forms.TextBox textBox_LinkResource;
        private System.Windows.Forms.Label LinkResource;
        private System.Windows.Forms.Button button_stop;
    }
}

