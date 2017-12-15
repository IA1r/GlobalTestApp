namespace GlobalTestAppWF
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
			this.ofd = new System.Windows.Forms.OpenFileDialog();
			this.serialize_btn = new System.Windows.Forms.Button();
			this.deserializel_btn = new System.Windows.Forms.Button();
			this.fbd = new System.Windows.Forms.FolderBrowserDialog();
			this.sfd = new System.Windows.Forms.SaveFileDialog();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// ofd
			// 
			this.ofd.FileName = "openFileDialog1";
			// 
			// serialize_btn
			// 
			this.serialize_btn.Location = new System.Drawing.Point(96, 21);
			this.serialize_btn.Name = "serialize_btn";
			this.serialize_btn.Size = new System.Drawing.Size(152, 39);
			this.serialize_btn.TabIndex = 0;
			this.serialize_btn.Text = "Serialize";
			this.serialize_btn.UseVisualStyleBackColor = true;
			this.serialize_btn.Click += new System.EventHandler(this.serialize_Click);
			// 
			// deserializel_btn
			// 
			this.deserializel_btn.Location = new System.Drawing.Point(96, 88);
			this.deserializel_btn.Name = "deserializel_btn";
			this.deserializel_btn.Size = new System.Drawing.Size(152, 37);
			this.deserializel_btn.TabIndex = 1;
			this.deserializel_btn.Text = "Deserialize";
			this.deserializel_btn.UseVisualStyleBackColor = true;
			this.deserializel_btn.Click += new System.EventHandler(this.deserialize_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 148);
			this.Controls.Add(this.deserializel_btn);
			this.Controls.Add(this.serialize_btn);
			this.Name = "Form1";
			this.Text = "File Serialization";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog ofd;
		private System.Windows.Forms.Button serialize_btn;
		private System.Windows.Forms.Button deserializel_btn;
		private System.Windows.Forms.FolderBrowserDialog fbd;
		private System.Windows.Forms.SaveFileDialog sfd;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

