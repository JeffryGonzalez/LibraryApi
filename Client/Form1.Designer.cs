namespace Client
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
			this.button1 = new System.Windows.Forms.Button();
			this.btnGetOne = new System.Windows.Forms.Button();
			this.txtId = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(50, 46);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(219, 77);
			this.button1.TabIndex = 0;
			this.button1.Text = "Get All";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnGetOne
			// 
			this.btnGetOne.Location = new System.Drawing.Point(335, 46);
			this.btnGetOne.Name = "btnGetOne";
			this.btnGetOne.Size = new System.Drawing.Size(178, 77);
			this.btnGetOne.TabIndex = 1;
			this.btnGetOne.Text = "Get =>";
			this.btnGetOne.UseVisualStyleBackColor = true;
			this.btnGetOne.Click += new System.EventHandler(this.btnGetOne_Click);
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(539, 66);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(100, 38);
			this.txtId.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1332, 700);
			this.Controls.Add(this.txtId);
			this.Controls.Add(this.btnGetOne);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnGetOne;
		private System.Windows.Forms.TextBox txtId;
	}
}

