namespace WeatherApp
{
    partial class ExportForm
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
            textInputFolderPath = new TextBox();
            label1 = new Label();
            buttonChangeLocation = new Button();
            buttonExport = new Button();
            SuspendLayout();
            // 
            // textInputFolderPath
            // 
            textInputFolderPath.Location = new Point(31, 114);
            textInputFolderPath.Name = "textInputFolderPath";
            textInputFolderPath.Size = new Size(519, 31);
            textInputFolderPath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 74);
            label1.Name = "label1";
            label1.Size = new Size(321, 25);
            label1.TabIndex = 1;
            label1.Text = "Select folder to export weather data to:";
            // 
            // buttonChangeLocation
            // 
            buttonChangeLocation.Location = new Point(566, 114);
            buttonChangeLocation.Name = "buttonChangeLocation";
            buttonChangeLocation.Size = new Size(165, 34);
            buttonChangeLocation.TabIndex = 2;
            buttonChangeLocation.Text = "Change Location";
            buttonChangeLocation.UseVisualStyleBackColor = true;
            buttonChangeLocation.Click += buttonChangeLocation_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(566, 232);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(112, 34);
            buttonExport.TabIndex = 3;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // ExportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 281);
            Controls.Add(buttonExport);
            Controls.Add(buttonChangeLocation);
            Controls.Add(label1);
            Controls.Add(textInputFolderPath);
            Name = "ExportForm";
            Text = "ExportForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textInputFolderPath;
        private Label label1;
        private Button buttonChangeLocation;
        private Button buttonExport;
    }
}