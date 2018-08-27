using System;
using System.Linq;
using System.Windows.Forms;
using VulnXML2Nessus.Controllers;

namespace VulnXML2Nessus
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }

        private string vulnXMLFile = "";
        private string outputXMLDir = "";

        private void browseXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "VulnXML File|*.xml";
            openFileDialog1.Title = "Select VulnXML File";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textXML.Text = openFileDialog1.FileName;
                vulnXMLFile = openFileDialog1.FileName;
            }
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textOut.Text = folderBrowserDialog1.SelectedPath;
                outputXMLDir = folderBrowserDialog1.SelectedPath;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!vulnXMLFile.Equals("") & !outputXMLDir.Equals(""))
            {
                var parser = new VulnXMLParser((string)vulnXMLFile);
                var report = parser.Run();

                var output = new NessusXMLOutput();
                var result = output.GenerateNessusXML(report, outputXMLDir);

                var filepath = outputXMLDir + @"\Nessus-XML-output.xml";

                if (!System.IO.File.Exists(filepath))
                {
                    result.Save(filepath);
                    MessageBox.Show("File saved: " + filepath);
                }
                else
                {
                    MessageBox.Show("File already exists - not saved");
                }
            }
            else
            {
                MessageBox.Show("Empty Input / Output File");
            }
        }
    }
}
