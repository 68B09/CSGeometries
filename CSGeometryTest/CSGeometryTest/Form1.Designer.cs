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
			this.HSV = new System.Windows.Forms.TabPage();
			this.pnlHSV = new System.Windows.Forms.Panel();
			this.lblHSVBox = new System.Windows.Forms.Label();
			this.txtHSVV = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.trkHSVV = new System.Windows.Forms.TrackBar();
			this.txtHSVS = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.trkHSVS = new System.Windows.Forms.TrackBar();
			this.txtHSVH = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.trkHSVH = new System.Windows.Forms.TrackBar();
			this.txtHSVB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.trkHSVB = new System.Windows.Forms.TrackBar();
			this.txtHSVG = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.trkHSVG = new System.Windows.Forms.TrackBar();
			this.txtHSVR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.trkHSVR = new System.Windows.Forms.TrackBar();
			this.Clip = new System.Windows.Forms.TabPage();
			this.pnlClip = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.tab.SuspendLayout();
			this.GetLength.SuspendLayout();
			this.GetPointLR.SuspendLayout();
			this.GetCrossPoint.SuspendLayout();
			this.GetAngle.SuspendLayout();
			this.HSV.SuspendLayout();
			this.pnlHSV.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVV)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVG)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVR)).BeginInit();
			this.Clip.SuspendLayout();
			this.pnlClip.SuspendLayout();
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
			this.tab.Controls.Add(this.HSV);
			this.tab.Controls.Add(this.Clip);
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
			// HSV
			// 
			this.HSV.Controls.Add(this.pnlHSV);
			this.HSV.Location = new System.Drawing.Point(4, 22);
			this.HSV.Name = "HSV";
			this.HSV.Size = new System.Drawing.Size(713, 622);
			this.HSV.TabIndex = 6;
			this.HSV.Text = "HSV";
			this.HSV.UseVisualStyleBackColor = true;
			// 
			// pnlHSV
			// 
			this.pnlHSV.Controls.Add(this.lblHSVBox);
			this.pnlHSV.Controls.Add(this.txtHSVV);
			this.pnlHSV.Controls.Add(this.label6);
			this.pnlHSV.Controls.Add(this.trkHSVV);
			this.pnlHSV.Controls.Add(this.txtHSVS);
			this.pnlHSV.Controls.Add(this.label5);
			this.pnlHSV.Controls.Add(this.trkHSVS);
			this.pnlHSV.Controls.Add(this.txtHSVH);
			this.pnlHSV.Controls.Add(this.label4);
			this.pnlHSV.Controls.Add(this.trkHSVH);
			this.pnlHSV.Controls.Add(this.txtHSVB);
			this.pnlHSV.Controls.Add(this.label3);
			this.pnlHSV.Controls.Add(this.trkHSVB);
			this.pnlHSV.Controls.Add(this.txtHSVG);
			this.pnlHSV.Controls.Add(this.label2);
			this.pnlHSV.Controls.Add(this.trkHSVG);
			this.pnlHSV.Controls.Add(this.txtHSVR);
			this.pnlHSV.Controls.Add(this.label1);
			this.pnlHSV.Controls.Add(this.trkHSVR);
			this.pnlHSV.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlHSV.Location = new System.Drawing.Point(0, 0);
			this.pnlHSV.Name = "pnlHSV";
			this.pnlHSV.Size = new System.Drawing.Size(713, 622);
			this.pnlHSV.TabIndex = 0;
			this.pnlHSV.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHSV_Paint);
			// 
			// lblHSVBox
			// 
			this.lblHSVBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHSVBox.Location = new System.Drawing.Point(218, 390);
			this.lblHSVBox.Name = "lblHSVBox";
			this.lblHSVBox.Size = new System.Drawing.Size(200, 200);
			this.lblHSVBox.TabIndex = 18;
			// 
			// txtHSVV
			// 
			this.txtHSVV.Location = new System.Drawing.Point(660, 300);
			this.txtHSVV.MaxLength = 3;
			this.txtHSVV.Name = "txtHSVV";
			this.txtHSVV.Size = new System.Drawing.Size(50, 19);
			this.txtHSVV.TabIndex = 17;
			this.txtHSVV.WordWrap = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 300);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(13, 12);
			this.label6.TabIndex = 16;
			this.label6.Text = "V";
			// 
			// trkHSVV
			// 
			this.trkHSVV.Location = new System.Drawing.Point(22, 300);
			this.trkHSVV.Maximum = 100;
			this.trkHSVV.Name = "trkHSVV";
			this.trkHSVV.Size = new System.Drawing.Size(632, 45);
			this.trkHSVV.TabIndex = 15;
			this.trkHSVV.TickFrequency = 10;
			this.trkHSVV.ValueChanged += new System.EventHandler(this.trkHSVHSV_ValueChanged);
			// 
			// txtHSVS
			// 
			this.txtHSVS.Location = new System.Drawing.Point(660, 249);
			this.txtHSVS.MaxLength = 3;
			this.txtHSVS.Name = "txtHSVS";
			this.txtHSVS.Size = new System.Drawing.Size(50, 19);
			this.txtHSVS.TabIndex = 14;
			this.txtHSVS.WordWrap = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 249);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(12, 12);
			this.label5.TabIndex = 13;
			this.label5.Text = "S";
			// 
			// trkHSVS
			// 
			this.trkHSVS.Location = new System.Drawing.Point(22, 249);
			this.trkHSVS.Maximum = 100;
			this.trkHSVS.Name = "trkHSVS";
			this.trkHSVS.Size = new System.Drawing.Size(632, 45);
			this.trkHSVS.TabIndex = 12;
			this.trkHSVS.TickFrequency = 10;
			this.trkHSVS.ValueChanged += new System.EventHandler(this.trkHSVHSV_ValueChanged);
			// 
			// txtHSVH
			// 
			this.txtHSVH.Location = new System.Drawing.Point(660, 198);
			this.txtHSVH.MaxLength = 3;
			this.txtHSVH.Name = "txtHSVH";
			this.txtHSVH.Size = new System.Drawing.Size(50, 19);
			this.txtHSVH.TabIndex = 11;
			this.txtHSVH.WordWrap = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 198);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(13, 12);
			this.label4.TabIndex = 10;
			this.label4.Text = "H";
			// 
			// trkHSVH
			// 
			this.trkHSVH.Location = new System.Drawing.Point(22, 198);
			this.trkHSVH.Maximum = 359;
			this.trkHSVH.Name = "trkHSVH";
			this.trkHSVH.Size = new System.Drawing.Size(632, 45);
			this.trkHSVH.TabIndex = 9;
			this.trkHSVH.TickFrequency = 10;
			this.trkHSVH.ValueChanged += new System.EventHandler(this.trkHSVHSV_ValueChanged);
			// 
			// txtHSVB
			// 
			this.txtHSVB.Location = new System.Drawing.Point(660, 105);
			this.txtHSVB.MaxLength = 3;
			this.txtHSVB.Name = "txtHSVB";
			this.txtHSVB.Size = new System.Drawing.Size(50, 19);
			this.txtHSVB.TabIndex = 8;
			this.txtHSVB.WordWrap = false;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(13, 12);
			this.label3.TabIndex = 7;
			this.label3.Text = "B";
			// 
			// trkHSVB
			// 
			this.trkHSVB.Location = new System.Drawing.Point(22, 105);
			this.trkHSVB.Maximum = 100;
			this.trkHSVB.Name = "trkHSVB";
			this.trkHSVB.Size = new System.Drawing.Size(632, 45);
			this.trkHSVB.TabIndex = 6;
			this.trkHSVB.TickFrequency = 10;
			this.trkHSVB.ValueChanged += new System.EventHandler(this.trkHSVRGB_ValueChanged);
			// 
			// txtHSVG
			// 
			this.txtHSVG.Location = new System.Drawing.Point(660, 54);
			this.txtHSVG.MaxLength = 3;
			this.txtHSVG.Name = "txtHSVG";
			this.txtHSVG.Size = new System.Drawing.Size(50, 19);
			this.txtHSVG.TabIndex = 5;
			this.txtHSVG.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "G";
			// 
			// trkHSVG
			// 
			this.trkHSVG.Location = new System.Drawing.Point(22, 54);
			this.trkHSVG.Maximum = 100;
			this.trkHSVG.Name = "trkHSVG";
			this.trkHSVG.Size = new System.Drawing.Size(632, 45);
			this.trkHSVG.TabIndex = 3;
			this.trkHSVG.TickFrequency = 10;
			this.trkHSVG.ValueChanged += new System.EventHandler(this.trkHSVRGB_ValueChanged);
			// 
			// txtHSVR
			// 
			this.txtHSVR.Location = new System.Drawing.Point(660, 3);
			this.txtHSVR.MaxLength = 3;
			this.txtHSVR.Name = "txtHSVR";
			this.txtHSVR.Size = new System.Drawing.Size(50, 19);
			this.txtHSVR.TabIndex = 2;
			this.txtHSVR.WordWrap = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "R";
			// 
			// trkHSVR
			// 
			this.trkHSVR.Location = new System.Drawing.Point(22, 3);
			this.trkHSVR.Maximum = 100;
			this.trkHSVR.Name = "trkHSVR";
			this.trkHSVR.Size = new System.Drawing.Size(632, 45);
			this.trkHSVR.TabIndex = 0;
			this.trkHSVR.TickFrequency = 10;
			this.trkHSVR.ValueChanged += new System.EventHandler(this.trkHSVRGB_ValueChanged);
			// 
			// Clip
			// 
			this.Clip.Controls.Add(this.pnlClip);
			this.Clip.Location = new System.Drawing.Point(4, 22);
			this.Clip.Name = "Clip";
			this.Clip.Size = new System.Drawing.Size(713, 622);
			this.Clip.TabIndex = 7;
			this.Clip.Text = "Clip";
			this.Clip.UseVisualStyleBackColor = true;
			// 
			// pnlClip
			// 
			this.pnlClip.Controls.Add(this.button1);
			this.pnlClip.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlClip.Location = new System.Drawing.Point(0, 0);
			this.pnlClip.Name = "pnlClip";
			this.pnlClip.Size = new System.Drawing.Size(713, 622);
			this.pnlClip.TabIndex = 0;
			this.pnlClip.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlClip_Paint);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "DRAW";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.HSV.ResumeLayout(false);
			this.pnlHSV.ResumeLayout(false);
			this.pnlHSV.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVV)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVG)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkHSVR)).EndInit();
			this.Clip.ResumeLayout(false);
			this.pnlClip.ResumeLayout(false);
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
		private System.Windows.Forms.TabPage HSV;
		private System.Windows.Forms.Panel pnlHSV;
		private System.Windows.Forms.TextBox txtHSVV;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TrackBar trkHSVV;
		private System.Windows.Forms.TextBox txtHSVS;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar trkHSVS;
		private System.Windows.Forms.TextBox txtHSVH;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trkHSVH;
		private System.Windows.Forms.TextBox txtHSVB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trkHSVB;
		private System.Windows.Forms.TextBox txtHSVG;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar trkHSVG;
		private System.Windows.Forms.TextBox txtHSVR;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trkHSVR;
		private System.Windows.Forms.Label lblHSVBox;
		private System.Windows.Forms.TabPage Clip;
		private System.Windows.Forms.Panel pnlClip;
		private System.Windows.Forms.Button button1;
	}
}

