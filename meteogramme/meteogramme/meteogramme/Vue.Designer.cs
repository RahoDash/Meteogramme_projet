namespace meteogramme
{
    partial class Vue
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtpWeather = new System.Windows.Forms.DateTimePicker();
            this.cc1 = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(12, 12);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(100, 20);
            this.txtLat.TabIndex = 0;
            this.txtLat.Text = "46.2043907";
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(118, 12);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(100, 20);
            this.txtLon.TabIndex = 1;
            this.txtLon.Text = "6.1431577";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(224, 12);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 20);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Load";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 16;
            // 
            // dtpWeather
            // 
            this.dtpWeather.Location = new System.Drawing.Point(247, 71);
            this.dtpWeather.MinDate = new System.DateTime(2017, 10, 9, 0, 0, 0, 0);
            this.dtpWeather.Name = "dtpWeather";
            this.dtpWeather.ShowUpDown = true;
            this.dtpWeather.Size = new System.Drawing.Size(165, 20);
            this.dtpWeather.TabIndex = 6;
            this.dtpWeather.ValueChanged += new System.EventHandler(this.dtpWeather_ValueChanged);
            // 
            // cc1
            // 
            this.cc1.Location = new System.Drawing.Point(34, 112);
            this.cc1.Name = "cc1";
            this.cc1.Size = new System.Drawing.Size(574, 211);
            this.cc1.TabIndex = 7;
            this.cc1.Text = "cartesianChart1";
            // 
            // Vue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 459);
            this.Controls.Add(this.cc1);
            this.Controls.Add(this.dtpWeather);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtLon);
            this.Controls.Add(this.txtLat);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Vue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Météogramme";
            this.Load += new System.EventHandler(this.Vue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtpWeather;
        private LiveCharts.WinForms.CartesianChart cc1;
    }
}

