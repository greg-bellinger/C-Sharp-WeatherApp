using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherApp
{
    public partial class ExportSuccessForm : Form
    {
        private string folderPath;
        public ExportSuccessForm(string folderPath)
        {
            InitializeComponent();
            this.folderPath = folderPath;
        }

        private void fileLocationButton_Click(object sender, EventArgs e)
        {
            // Open the file explorer where the weather data was written to
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
        }
    }
}
