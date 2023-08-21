namespace WeatherApp
{
    partial class ExportSuccessForm
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
            label1 = new Label();
            fileLocationButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 40);
            label1.Name = "label1";
            label1.Size = new Size(294, 25);
            label1.TabIndex = 0;
            label1.Text = "Weather Data Exported Successfully";
            // 
            // fileLocationButton
            // 
            fileLocationButton.Location = new Point(122, 95);
            fileLocationButton.Name = "fileLocationButton";
            fileLocationButton.Size = new Size(189, 34);
            fileLocationButton.TabIndex = 1;
            fileLocationButton.Text = "View File Location";
            fileLocationButton.UseVisualStyleBackColor = true;
            fileLocationButton.Click += fileLocationButton_Click;
            // 
            // ExportSuccessForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 152);
            Controls.Add(fileLocationButton);
            Controls.Add(label1);
            Name = "ExportSuccessForm";
            Text = "ExportSuccessForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button fileLocationButton;
    }
}