namespace ListDirectory
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.selectDirectory = new System.Windows.Forms.Button();
            this.names = new System.Windows.Forms.ListBox();
            this.toTxt = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.GroupBox();
            this.exclusions = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.exclusionsEnable = new System.Windows.Forms.CheckBox();
            this.extensions = new System.Windows.Forms.CheckBox();
            this.options.SuspendLayout();
            this.exclusions.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectDirectory
            // 
            this.selectDirectory.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectDirectory.Location = new System.Drawing.Point(11, 12);
            this.selectDirectory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.selectDirectory.Name = "selectDirectory";
            this.selectDirectory.Size = new System.Drawing.Size(86, 40);
            this.selectDirectory.TabIndex = 1;
            this.selectDirectory.Text = "Select Directory";
            this.selectDirectory.UseVisualStyleBackColor = true;
            this.selectDirectory.Click += new System.EventHandler(this.selectDirectory_Click);
            // 
            // names
            // 
            this.names.FormattingEnabled = true;
            this.names.HorizontalScrollbar = true;
            this.names.ItemHeight = 16;
            this.names.Location = new System.Drawing.Point(101, 12);
            this.names.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.names.Name = "names";
            this.names.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.names.Size = new System.Drawing.Size(290, 340);
            this.names.TabIndex = 2;
            // 
            // toTxt
            // 
            this.toTxt.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toTxt.Location = new System.Drawing.Point(395, 12);
            this.toTxt.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.toTxt.Name = "toTxt";
            this.toTxt.Size = new System.Drawing.Size(121, 25);
            this.toTxt.TabIndex = 3;
            this.toTxt.Text = "Save";
            this.toTxt.UseVisualStyleBackColor = true;
            // 
            // remove
            // 
            this.remove.ForeColor = System.Drawing.Color.Red;
            this.remove.Location = new System.Drawing.Point(101, 358);
            this.remove.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(290, 33);
            this.remove.TabIndex = 6;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // options
            // 
            this.options.Controls.Add(this.exclusions);
            this.options.Controls.Add(this.extensions);
            this.options.Location = new System.Drawing.Point(396, 43);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(158, 348);
            this.options.TabIndex = 7;
            this.options.TabStop = false;
            this.options.Text = "Options";
            // 
            // exclusions
            // 
            this.exclusions.Controls.Add(this.textBox1);
            this.exclusions.Controls.Add(this.exclusionsEnable);
            this.exclusions.Location = new System.Drawing.Point(6, 43);
            this.exclusions.Name = "exclusions";
            this.exclusions.Size = new System.Drawing.Size(146, 70);
            this.exclusions.TabIndex = 7;
            this.exclusions.TabStop = false;
            this.exclusions.Text = "Exclusions";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 22);
            this.textBox1.TabIndex = 1;
            // 
            // exclusionsEnable
            // 
            this.exclusionsEnable.AutoSize = true;
            this.exclusionsEnable.Location = new System.Drawing.Point(6, 19);
            this.exclusionsEnable.Name = "exclusionsEnable";
            this.exclusionsEnable.Size = new System.Drawing.Size(78, 20);
            this.exclusionsEnable.TabIndex = 0;
            this.exclusionsEnable.Text = "Enable";
            this.exclusionsEnable.UseVisualStyleBackColor = true;
            // 
            // extensions
            // 
            this.extensions.AutoSize = true;
            this.extensions.Checked = true;
            this.extensions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.extensions.Location = new System.Drawing.Point(6, 19);
            this.extensions.Name = "extensions";
            this.extensions.Size = new System.Drawing.Size(143, 20);
            this.extensions.TabIndex = 0;
            this.extensions.Text = "With Extensions";
            this.extensions.UseVisualStyleBackColor = true;
            this.extensions.CheckedChanged += new System.EventHandler(this.extensions_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 403);
            this.Controls.Add(this.options);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.toTxt);
            this.Controls.Add(this.names);
            this.Controls.Add(this.selectDirectory);
            this.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "List Directory";
            this.options.ResumeLayout(false);
            this.options.PerformLayout();
            this.exclusions.ResumeLayout(false);
            this.exclusions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectDirectory;
        private System.Windows.Forms.ListBox names;
        private System.Windows.Forms.Button toTxt;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.GroupBox options;
        private System.Windows.Forms.GroupBox exclusions;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox exclusionsEnable;
        private System.Windows.Forms.CheckBox extensions;
    }
}

