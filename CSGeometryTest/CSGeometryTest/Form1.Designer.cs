namespace CSGeometryTest
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.tab = new System.Windows.Forms.TabControl();
			this.GetLength = new System.Windows.Forms.TabPage();
			this.pnlGetLength = new System.Windows.Forms.Panel();
			this.GetPointLR = new System.Windows.Forms.TabPage();
			this.pnlGetPointLR = new System.Windows.Forms.Panel();
			this.GetCrossPoint = new System.Windows.Forms.TabPage();
			this.pnlGetCrossPoint = new System.Windows.Forms.Panel();
			this.GetAngle = new System.Windows.Forms.TabPage();
			this.pnlGetAngle = new System.Windows.Forms.Panel();
			this.tab.SuspendLayout();
			this.GetLength.SuspendLayout();
			this.GetPointLR.SuspendLayout();
			this.GetCrossPoint.SuspendLayout();
			this.GetAngle.SuspendLayout();
			this.SuspendLayout();
			// 
			// tab
			// 
			this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tab.Controls.Add(this.GetLength);
			this.tab.Controls.Add(this.GetPointLR);
			this.tab.Controls.Add(this.GetCrossPoint);
			this.tab.Controls.Add(this.GetAngle);
			this.tab.Location = new System.Drawing.Point(12, 12);
			this.tab.Name = "tab";
			this.tab.SelectedIndex = 0;
			this.tab.Size = new System.Drawing.Size(721, 648);
			this.tab.TabIndex = 0;
			// 
			// GetLength
			// 
			this.GetLength.Controls.Add(this.pnlGetLength);
			this.GetLength.Location = new System.Drawing.Point(4, 22);
			this.GetLength.Name = "GetLength";
			this.GetLength.Size = new System.Drawing.Size(713, 622);
			this.GetLength.TabIndex = 3;
			this.GetLength.Text = "GetLength";
			this.GetLength.UseVisualStyleBackColor = true;
			// 
			// pnlGetLength
			// 
			this.pnlGetLength.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGetLength.Location = new System.Drawing.Point(0, 0);
			this.pnlGetLength.Name = "pnlGetLength";
			this.pnlGetLength.Size = new System.Drawing.Size(713, 622);
			this.pnlGetLength.TabIndex = 0;
			this.pnlGetLength.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGetLength_Paint);
			this.pnlGetLength.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGetLength_MouseDown);
			// 
			// GetPointLR
			// 
			this.GetPointLR.Controls.Add(this.pnlGetPointLR);
			this.GetPointLR.Location = new System.Drawing.Point(4, 22);
			this.GetPointLR.Name = "GetPointLR";
			this.GetPointLR.Padding = new System.Windows.Forms.Padding(3);
			this.GetPointLR.Size = new System.Drawing.Size(713, 622);
			this.GetPointLR.TabIndex = 1;
			this.GetPointLR.Text = "GetPointLR";
			this.GetPointLR.UseVisualStyleBackColor = true;
			// 
			// pnlGetPointLR
			// 
			this.pnlGetPointLR.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGetPointLR.Location = new System.Drawing.Point(3, 3);
			this.pnlGetPointLR.Name = "pnlGetPointLR";
			this.pnlGetPointLR.Size = new System.Drawing.Size(707, 616);
			this.pnlGetPointLR.TabIndex = 0;
			this.pnlGetPointLR.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGetPointLR_Paint);
			this.pnlGetPointLR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGetPointLR_MouseDown);
			// 
			// GetCrossPoint
			// 
			this.GetCrossPoint.Controls.Add(this.pnlGetCrossPoint);
			this.GetCrossPoint.Location = new System.Drawing.Point(4, 22);
			this.GetCrossPoint.Name = "GetCrossPoint";
			this.GetCrossPoint.Size = new System.Drawing.Size(713, 622);
			this.GetCrossPoint.TabIndex = 2;
			this.GetCrossPoint.Text = "GetCrossPoint";
			this.GetCrossPoint.UseVisualStyleBackColor = true;
			// 
			// pnlGetCrossPoint
			// 
			this.pnlGetCrossPoint.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGetCrossPoint.Location = new System.Drawing.Point(0, 0);
			this.pnlGetCrossPoint.Name = "pnlGetCrossPoint";
			this.pnlGetCrossPoint.Size = new System.Drawing.Size(713, 622);
			this.pnlGetCrossPoint.TabIndex = 0;
			this.pnlGetCrossPoint.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGetCrossPoint_Paint);
			this.pnlGetCrossPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGetCrossPoint_MouseDown);
			// 
			// GetAngle
			// 
			this.GetAngle.Controls.Add(this.pnlGetAngle);
			this.GetAngle.Location = new System.Drawing.Point(4, 22);
			this.GetAngle.Name = "GetAngle";
			this.GetAngle.Size = new System.Drawing.Size(713, 622);
			this.GetAngle.TabIndex = 5;
			this.GetAngle.Text = "GetAngle";
			this.GetAngle.UseVisualStyleBackColor = true;
			// 
			// pnlGetAngle
			// 
			this.pnlGetAngle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGetAngle.Location = new System.Drawing.Point(0, 0);
			this.pnlGetAngle.Name = "pnlGetAngle";
			this.pnlGetAngle.Size = new System.Drawing.Size(713, 622);
			this.pnlGetAngle.TabIndex = 0;
			this.pnlGetAngle.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGetAngle_Paint);
			this.pnlGetAngle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlGetAngle_MouseDown);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 672);
			this.Controls.Add(this.tab);
			this.Name = "Form1";
			this.Text = "Form1";
			this.tab.ResumeLayout(false);
			this.GetLength.ResumeLayout(false);
			this.GetPointLR.ResumeLayout(false);
			this.GetCrossPoint.ResumeLayout(false);
			this.GetAngle.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tab;
		private System.Windows.Forms.TabPage GetPointLR;
		private System.Windows.Forms.Panel pnlGetPointLR;
		private System.Windows.Forms.TabPage GetCrossPoint;
		private System.Windows.Forms.Panel pnlGetCrossPoint;
		private System.Windows.Forms.TabPage GetLength;
		private System.Windows.Forms.Panel pnlGetLength;
		private System.Windows.Forms.TabPage GetAngle;
		private System.Windows.Forms.Panel pnlGetAngle;
	}
}

