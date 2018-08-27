namespace VulnXML2Nessus
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.outputDir = new System.Windows.Forms.Label();
            this.vulnXMLInput = new System.Windows.Forms.Label();
            this.buttonOut = new System.Windows.Forms.Button();
            this.browseXML = new System.Windows.Forms.Button();
            this.textOut = new System.Windows.Forms.TextBox();
            this.textXML = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.outputDir);
            this.splitContainer1.Panel1.Controls.Add(this.vulnXMLInput);
            this.splitContainer1.Panel1.Controls.Add(this.buttonOut);
            this.splitContainer1.Panel1.Controls.Add(this.browseXML);
            this.splitContainer1.Panel1.Controls.Add(this.textOut);
            this.splitContainer1.Panel1.Controls.Add(this.textXML);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.buttonCreate);
            this.splitContainer1.Size = new System.Drawing.Size(649, 116);
            this.splitContainer1.SplitterDistance = 71;
            this.splitContainer1.TabIndex = 0;
            // 
            // outputDir
            // 
            this.outputDir.AutoSize = true;
            this.outputDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputDir.Location = new System.Drawing.Point(39, 42);
            this.outputDir.Name = "outputDir";
            this.outputDir.Size = new System.Drawing.Size(75, 18);
            this.outputDir.TabIndex = 5;
            this.outputDir.Text = "Output Dir";
            // 
            // vulnXMLInput
            // 
            this.vulnXMLInput.AutoSize = true;
            this.vulnXMLInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vulnXMLInput.Location = new System.Drawing.Point(12, 11);
            this.vulnXMLInput.Name = "vulnXMLInput";
            this.vulnXMLInput.Size = new System.Drawing.Size(102, 18);
            this.vulnXMLInput.TabIndex = 4;
            this.vulnXMLInput.Text = "VulnXML Input";
            // 
            // buttonOut
            // 
            this.buttonOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOut.Location = new System.Drawing.Point(551, 43);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(84, 23);
            this.buttonOut.TabIndex = 3;
            this.buttonOut.Text = "browse...";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // browseXML
            // 
            this.browseXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseXML.Location = new System.Drawing.Point(551, 11);
            this.browseXML.Name = "browseXML";
            this.browseXML.Size = new System.Drawing.Size(84, 24);
            this.browseXML.TabIndex = 2;
            this.browseXML.Text = "browse...";
            this.browseXML.UseVisualStyleBackColor = true;
            this.browseXML.Click += new System.EventHandler(this.browseXML_Click);
            // 
            // textOut
            // 
            this.textOut.BackColor = System.Drawing.SystemColors.Window;
            this.textOut.Location = new System.Drawing.Point(120, 43);
            this.textOut.Multiline = true;
            this.textOut.Name = "textOut";
            this.textOut.ReadOnly = true;
            this.textOut.Size = new System.Drawing.Size(425, 22);
            this.textOut.TabIndex = 1;
            // 
            // textXML
            // 
            this.textXML.BackColor = System.Drawing.SystemColors.Window;
            this.textXML.Location = new System.Drawing.Point(120, 12);
            this.textXML.Multiline = true;
            this.textXML.Name = "textXML";
            this.textXML.ReadOnly = true;
            this.textXML.Size = new System.Drawing.Size(425, 23);
            this.textXML.TabIndex = 0;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreate.Location = new System.Drawing.Point(0, 0);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(649, 41);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Generate this bad boy";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 116);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VulnXML 2 Nessus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label vulnXMLInput;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Button browseXML;
        private System.Windows.Forms.TextBox textOut;
        private System.Windows.Forms.TextBox textXML;
        private System.Windows.Forms.Label outputDir;
        private System.Windows.Forms.Button buttonCreate;
    }
}

