using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace JsonToCSV
{
    public partial class JsonToCSV : Form
    {
        public JsonToCSV()
        {
            InitializeComponent();
        }

        private void button_JSON_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.DefaultExt = ".json";
                    ofd.Filter = "JSON (.json)|*.json";

                    ofd.InitialDirectory = (string.IsNullOrEmpty(textBox_Json.Text) == false) ? textBox_Json.Text : "";

                    if (ofd.ShowDialog(this) == DialogResult.OK)
                    {
                        textBox_Json.Text = ofd.FileName;
                        textBox_CSV.Text = Path.GetDirectoryName(ofd.FileName);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_CSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog fd = new FolderBrowserDialog())
                {
                    fd.SelectedPath = (string.IsNullOrEmpty(textBox_CSV.Text) == false) ? textBox_CSV.Text : "";

                    if (fd.ShowDialog(this) == DialogResult.OK)
                    {
                        textBox_CSV.Text = fd.SelectedPath;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            try
            {
                string sCSV = string.Empty;
                string sJSon = File.ReadAllText(textBox_Json.Text);

                sCSV = ReadJson(sJSon);

                if (string.IsNullOrEmpty(sCSV) == false)
                {
                    string sCSV_Path = Path.Combine(textBox_CSV.Text, Path.GetFileNameWithoutExtension(textBox_Json.Text));
                    sCSV_Path += ".csv";

                    File.WriteAllText(sCSV_Path, sCSV, Encoding.ASCII);

                    if (File.Exists(sCSV_Path) == true)
                    {
                        System.Diagnostics.Process.Start(Path.GetDirectoryName(sCSV_Path));
                    }
                }
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ReadJson(string jsonString)
        {
            JArray obj = JsonConvert.DeserializeObject<JArray>(jsonString);

            if (obj == null)
            {
                throw new Exception("Faild to deserialize JSON file.");
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine(ReadHeadersFromJson(obj));
            result.AppendLine(ReadDataFromJson(obj));

            return result.ToString();
        }

        private string ReadDataFromJson(JArray obj, string sLine = "")
        {
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();
            List<JArray> innerList = new List<JArray>();


            string sMainLine = string.Empty;
            string sTemp = string.Empty;
            string sVaue = string.Empty;

            if (obj == null)
            {
                throw new Exception("Faild to read JSON values");
            }

            foreach (JObject content in obj.Children<JObject>())
            {
                if (string.IsNullOrWhiteSpace(sLine) == false)
                {
                    line.Append(sLine);
                }

                foreach (JProperty prop in content.Properties())
                {
                    if (prop.Value is JArray)
                    {
                        innerList.Add((JArray)prop.Value);
                    }
                    else
                    {
                        sVaue = prop.Value.ToString();
                        sVaue = sVaue.Replace(',', ' ');
                        line.AppendFormat("{0}, ", sVaue);
                    }
                }

                if (innerList.Count > 0)
                {
                    sMainLine = line.ToString();

                    line.Clear();

                    foreach (JArray val in innerList)
                    {
                        sTemp = ReadDataFromJson(val, sMainLine);
                        line.Append(sTemp);
                    }
                }

                innerList.Clear();

                sTemp = line.ToString();
                sTemp = sTemp.TrimEnd('\r', '\n', ' ');

                result.AppendLine(sTemp);

                line.Clear();
            }

            return result.ToString();
        }

        private string ReadHeadersFromJson(JArray obj)
        {
            StringBuilder result = new StringBuilder();

            if (obj == null)
            {
                throw new Exception("Faild to read JSON headers");
            }

            if (obj != null && obj.First != null)
            {
                JObject content = (JObject)obj.First;

                foreach (JProperty prop in content.Properties())
                {
                    if (prop.Value is JArray)
                    {
                        result.Append(ReadHeadersFromJson((JArray)prop.Value));
                    }
                    else
                    {
                        result.Append(string.Format("{0}, ", prop.Name));
                    }
                }

            }

            string sCSV = result.ToString();

            return sCSV.TrimEnd(' ', ',');
        }
    }
}
