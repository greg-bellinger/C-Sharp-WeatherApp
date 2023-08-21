namespace WeatherApp
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
            inputText = new TextBox();
            submitButton = new Button();
            temperatureLabel = new Label();
            humidityLabel = new Label();
            descriptionLabel = new Label();
            celciusRadioButton = new RadioButton();
            fRadioButton = new RadioButton();
            locationLabel = new Label();
            jsonExport = new Button();
            label1 = new Label();
            tempLowLabel = new Label();
            tempHighLabel = new Label();
            feelsLikeLabel = new Label();
            label2 = new Label();
            sunriseLabel = new Label();
            sunsetLabel = new Label();
            windSpeedLabel = new Label();
            SuspendLayout();
            // 
            // inputText
            // 
            inputText.Location = new Point(208, 102);
            inputText.Name = "inputText";
            inputText.Size = new Size(184, 31);
            inputText.TabIndex = 0;
            inputText.Enter += inputText_Enter;
            // 
            // submitButton
            // 
            submitButton.Location = new Point(18, 102);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(184, 34);
            submitButton.TabIndex = 1;
            submitButton.Text = "Check Weather";
            submitButton.UseVisualStyleBackColor = true;
            submitButton.Click += submitButton_Click;
            // 
            // temperatureLabel
            // 
            temperatureLabel.AutoSize = true;
            temperatureLabel.Location = new Point(43, 185);
            temperatureLabel.Name = "temperatureLabel";
            temperatureLabel.Size = new Size(135, 25);
            temperatureLabel.TabIndex = 2;
            temperatureLabel.Text = "Current: ________";
            // 
            // humidityLabel
            // 
            humidityLabel.AutoSize = true;
            humidityLabel.Location = new Point(43, 285);
            humidityLabel.Name = "humidityLabel";
            humidityLabel.Size = new Size(150, 25);
            humidityLabel.TabIndex = 3;
            humidityLabel.Text = "Humidity: ________";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(320, 185);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(142, 25);
            descriptionLabel.TabIndex = 4;
            descriptionLabel.Text = "Outlook: ________";
            // 
            // celciusRadioButton
            // 
            celciusRadioButton.AutoSize = true;
            celciusRadioButton.Location = new Point(451, 102);
            celciusRadioButton.Name = "celciusRadioButton";
            celciusRadioButton.Size = new Size(48, 29);
            celciusRadioButton.TabIndex = 5;
            celciusRadioButton.TabStop = true;
            celciusRadioButton.Text = "C";
            celciusRadioButton.UseVisualStyleBackColor = true;
            celciusRadioButton.CheckedChanged += celciusRadioButton_CheckedChanged;
            // 
            // fRadioButton
            // 
            fRadioButton.AutoSize = true;
            fRadioButton.Location = new Point(505, 102);
            fRadioButton.Name = "fRadioButton";
            fRadioButton.Size = new Size(46, 29);
            fRadioButton.TabIndex = 6;
            fRadioButton.TabStop = true;
            fRadioButton.Text = "F";
            fRadioButton.UseVisualStyleBackColor = true;
            fRadioButton.CheckedChanged += fRadioButton_CheckedChanged;
            // 
            // locationLabel
            // 
            locationLabel.AutoSize = true;
            locationLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            locationLabel.Location = new Point(28, 26);
            locationLabel.Name = "locationLabel";
            locationLabel.Size = new Size(0, 45);
            locationLabel.TabIndex = 7;
            // 
            // jsonExport
            // 
            jsonExport.Location = new Point(162, 393);
            jsonExport.Name = "jsonExport";
            jsonExport.Size = new Size(230, 34);
            jsonExport.TabIndex = 8;
            jsonExport.Text = "Export All Weather Data";
            jsonExport.UseVisualStyleBackColor = true;
            jsonExport.Click += jsonExport_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(29, 153);
            label1.Name = "label1";
            label1.Size = new Size(149, 32);
            label1.TabIndex = 9;
            label1.Text = "Temperature";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // tempLowLabel
            // 
            tempLowLabel.AutoSize = true;
            tempLowLabel.Location = new Point(44, 235);
            tempLowLabel.Name = "tempLowLabel";
            tempLowLabel.Size = new Size(109, 25);
            tempLowLabel.TabIndex = 10;
            tempLowLabel.Text = "Low: ________";
            // 
            // tempHighLabel
            // 
            tempHighLabel.AutoSize = true;
            tempHighLabel.Location = new Point(44, 260);
            tempHighLabel.Name = "tempHighLabel";
            tempHighLabel.Size = new Size(115, 25);
            tempHighLabel.TabIndex = 11;
            tempHighLabel.Text = "High: ________";
            // 
            // feelsLikeLabel
            // 
            feelsLikeLabel.AutoSize = true;
            feelsLikeLabel.Location = new Point(44, 210);
            feelsLikeLabel.Name = "feelsLikeLabel";
            feelsLikeLabel.Size = new Size(151, 25);
            feelsLikeLabel.TabIndex = 12;
            feelsLikeLabel.Text = "Feels Like: ________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(300, 153);
            label2.Name = "label2";
            label2.Size = new Size(102, 32);
            label2.TabIndex = 13;
            label2.Text = "Forecast";
            // 
            // sunriseLabel
            // 
            sunriseLabel.AutoSize = true;
            sunriseLabel.Location = new Point(320, 210);
            sunriseLabel.Name = "sunriseLabel";
            sunriseLabel.Size = new Size(134, 25);
            sunriseLabel.TabIndex = 14;
            sunriseLabel.Text = "Sunrise: ________";
            // 
            // sunsetLabel
            // 
            sunsetLabel.AutoSize = true;
            sunsetLabel.Location = new Point(320, 235);
            sunsetLabel.Name = "sunsetLabel";
            sunsetLabel.Size = new Size(130, 25);
            sunsetLabel.TabIndex = 15;
            sunsetLabel.Text = "Sunset: ________";
            // 
            // windSpeedLabel
            // 
            windSpeedLabel.AutoSize = true;
            windSpeedLabel.Location = new Point(43, 310);
            windSpeedLabel.Name = "windSpeedLabel";
            windSpeedLabel.Size = new Size(174, 25);
            windSpeedLabel.TabIndex = 16;
            windSpeedLabel.Text = "Wind Speed: ________";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 450);
            Controls.Add(windSpeedLabel);
            Controls.Add(sunsetLabel);
            Controls.Add(sunriseLabel);
            Controls.Add(label2);
            Controls.Add(feelsLikeLabel);
            Controls.Add(tempHighLabel);
            Controls.Add(tempLowLabel);
            Controls.Add(label1);
            Controls.Add(jsonExport);
            Controls.Add(locationLabel);
            Controls.Add(fRadioButton);
            Controls.Add(celciusRadioButton);
            Controls.Add(descriptionLabel);
            Controls.Add(humidityLabel);
            Controls.Add(temperatureLabel);
            Controls.Add(submitButton);
            Controls.Add(inputText);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputText;
        private Button submitButton;
        private Label temperatureLabel;
        private Label humidityLabel;
        private Label descriptionLabel;
        private RadioButton celciusRadioButton;
        private RadioButton fRadioButton;
        private Label locationLabel;
        private Button jsonExport;
        private Label label1;
        private Label tempLowLabel;
        private Label tempHighLabel;
        private Label feelsLikeLabel;
        private Label label2;
        private Label sunriseLabel;
        private Label sunsetLabel;
        private Label windSpeedLabel;
    }
}