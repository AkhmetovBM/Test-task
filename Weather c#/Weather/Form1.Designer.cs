namespace Weather
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WeatherDisplay = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ShowWeatherButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WeatherDisplay
            // 
            this.WeatherDisplay.Location = new System.Drawing.Point(25, 73);
            this.WeatherDisplay.Name = "WeatherDisplay";
            this.WeatherDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WeatherDisplay.Size = new System.Drawing.Size(288, 128);
            this.WeatherDisplay.TabIndex = 0;
            this.WeatherDisplay.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Pennsylvania";
            // 
            // ShowWeatherButton
            // 
            this.ShowWeatherButton.Location = new System.Drawing.Point(147, 15);
            this.ShowWeatherButton.Name = "ShowWeatherButton";
            this.ShowWeatherButton.Size = new System.Drawing.Size(114, 38);
            this.ShowWeatherButton.TabIndex = 3;
            this.ShowWeatherButton.Text = "Показать погоду";
            this.ShowWeatherButton.UseVisualStyleBackColor = true;
            this.ShowWeatherButton.Click += new System.EventHandler(this.ShowWeatherButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 293);
            this.Controls.Add(this.ShowWeatherButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.WeatherDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WeatherDisplay;
        private TextBox textBox1;
        private Button ShowWeatherButton;
    }
}