namespace JsonToCSV
{
    partial class JsonToCSV
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
            this.button_JSON = new System.Windows.Forms.Button();
            this.button_CSV = new System.Windows.Forms.Button();
            this.button_Convert = new System.Windows.Forms.Button();
            this.textBox_Json = new System.Windows.Forms.TextBox();
            this.textBox_CSV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_JSON
            // 
            this.button_JSON.Location = new System.Drawing.Point(665, 12);
            this.button_JSON.Name = "button_JSON";
            this.button_JSON.Size = new System.Drawing.Size(75, 23);
            this.button_JSON.TabIndex = 0;
            this.button_JSON.Text = "...";
            this.button_JSON.UseVisualStyleBackColor = true;
            this.button_JSON.Click += new System.EventHandler(this.button_JSON_Click);
            // 
            // button_CSV
            // 
            this.button_CSV.Location = new System.Drawing.Point(665, 60);
            this.button_CSV.Name = "button_CSV";
            this.button_CSV.Size = new System.Drawing.Size(75, 23);
            this.button_CSV.TabIndex = 1;
            this.button_CSV.Text = "...";
            this.button_CSV.UseVisualStyleBackColor = true;
            this.button_CSV.Click += new System.EventHandler(this.button_CSV_Click);
            // 
            // button_Convert
            // 
            this.button_Convert.Location = new System.Drawing.Point(150, 101);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(509, 53);
            this.button_Convert.TabIndex = 2;
            this.button_Convert.Text = "Convert";
            this.button_Convert.UseVisualStyleBackColor = true;
            this.button_Convert.Click += new System.EventHandler(this.button_Convert_Click);
            // 
            // textBox_Json
            // 
            this.textBox_Json.Location = new System.Drawing.Point(150, 13);
            this.textBox_Json.Name = "textBox_Json";
            this.textBox_Json.Size = new System.Drawing.Size(509, 22);
            this.textBox_Json.TabIndex = 3;
            // 
            // textBox_CSV
            // 
            this.textBox_CSV.Location = new System.Drawing.Point(150, 60);
            this.textBox_CSV.Name = "textBox_CSV";
            this.textBox_CSV.Size = new System.Drawing.Size(509, 22);
            this.textBox_CSV.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select JSON file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select output folder";
            // 
            // JsonToCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 171);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_CSV);
            this.Controls.Add(this.textBox_Json);
            this.Controls.Add(this.button_Convert);
            this.Controls.Add(this.button_CSV);
            this.Controls.Add(this.button_JSON);
            this.Name = "JsonToCSV";
            this.Text = "JsonToCSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_JSON;
        private System.Windows.Forms.Button button_CSV;
        private System.Windows.Forms.Button button_Convert;
        private System.Windows.Forms.TextBox textBox_Json;
        private System.Windows.Forms.TextBox textBox_CSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

