using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSGeometryTest
{
	public partial class Form1 : Form
	{
		private enum PointID : int
		{
			Minimum = 0,

			GetPointLR_S,
			GetPointLR_E,
			GetPointLR_P,

			GetCrossPoint_11,
			GetCrossPoint_12,
			GetCrossPoint_21,
			GetCrossPoint_22,

			GetLength_S,
			GetLength_E,

			GetAngle_1,
			GetAngle_2,
			GetAngle_3,

			Maximum
		}

		private Dictionary<PointID, System.Windows.Point> mPointDic = new Dictionary<PointID, System.Windows.Point>();

		private Pen mPenBlack = new Pen(Color.Black);
		private Pen mPenRed = new Pen(Color.Red);
		private Pen mPenGray = new Pen(Color.Gray);

		private SolidBrush mBrushBlack = new SolidBrush(Color.Black);

		public Form1()
		{
			InitializeComponent();
			if (this.DesignMode) {
				return;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (this.DesignMode) {
				return;
			}

			this.mPointDic[PointID.GetPointLR_S] = new System.Windows.Point(100, 100);
			this.mPointDic[PointID.GetPointLR_E] = new System.Windows.Point(600, 600);
			this.mPointDic[PointID.GetPointLR_P] = new System.Windows.Point(350, 100);

			this.mPointDic[PointID.GetCrossPoint_11] = new System.Windows.Point(100, 100);
			this.mPointDic[PointID.GetCrossPoint_12] = new System.Windows.Point(500, 500);
			this.mPointDic[PointID.GetCrossPoint_21] = new System.Windows.Point(400, 100);
			this.mPointDic[PointID.GetCrossPoint_22] = new System.Windows.Point(100, 400);

			this.mPointDic[PointID.GetLength_S] = new System.Windows.Point(100, 300);
			this.mPointDic[PointID.GetLength_E] = new System.Windows.Point(500, 300);

			this.mPointDic[PointID.GetAngle_1] = new System.Windows.Point(500, 100);
			this.mPointDic[PointID.GetAngle_2] = new System.Windows.Point(200, 200);
			this.mPointDic[PointID.GetAngle_3] = new System.Windows.Point(300, 500);

			this.trkHSVR.Value = 100;
			this.trkHSVG.Value = 100;
			this.trkHSVB.Value = 100;
		}

		private string GetPointString(PointID pID)
		{
			return GetPointString(this.mPointDic[pID]);
		}

		private string GetPointString(System.Windows.Point pPoint)
		{
			return string.Format("{0} , {1}", pPoint.X, pPoint.Y);
		}

		private string GetPointString(PointID pIDS, PointID pIDE)
		{
			return GetPointString(this.mPointDic[pIDS], this.mPointDic[pIDE]);
		}

		private string GetPointString(System.Windows.Point pS, System.Windows.Point pE)
		{
			return GetPointString(pS) + " - " + GetPointString(pE);
		}

		private void DrawPoint(Graphics pGraphics, PointID pID, Pen pPen)
		{
			this.DrawPoint(pGraphics, this.mPointDic[pID].ToFloat(), pPen);
		}

		private void DrawPoint(Graphics pGraphics, System.Windows.Point pPoint, Pen pPen)
		{
			this.DrawPoint(pGraphics, pPoint.ToFloat(), pPen);
		}

		private void DrawPoint(Graphics pGraphics, PointF pPoint, Pen pPen)
		{
			const float offset = 2;
			pGraphics.DrawLine(pPen, pPoint.X - offset, pPoint.Y - offset, pPoint.X + offset, pPoint.Y - offset);
			pGraphics.DrawLine(pPen, pPoint.X + offset, pPoint.Y - offset, pPoint.X + offset, pPoint.Y + offset);
			pGraphics.DrawLine(pPen, pPoint.X + offset, pPoint.Y + offset, pPoint.X - offset, pPoint.Y + offset);
			pGraphics.DrawLine(pPen, pPoint.X - offset, pPoint.Y + offset, pPoint.X - offset, pPoint.Y - offset);
		}

		private void DrawLine(Graphics pGraphics, PointID pID1, PointID pID2)
		{
			DrawLine(pGraphics, pID1, pID2, this.mPenBlack);
		}

		private void DrawLine(Graphics pGraphics, PointID pID1, PointID pID2, Pen pPen)
		{
			pGraphics.DrawLine(pPen, this.mPointDic[pID1].ToFloat(), this.mPointDic[pID2].ToFloat());
		}

		private void DrawLine(Graphics pGraphics, System.Windows.Point p1, System.Windows.Point p2, Pen pPen)
		{
			pGraphics.DrawLine(pPen, p1.ToFloat(), p2.ToFloat());
		}

		private void DrawRect(Graphics pGraphics, CSGeometries.Line pArea, Pen pPen)
		{
			pGraphics.DrawLine(pPen, pArea.X1, pArea.Y1, pArea.X2, pArea.Y1);
			pGraphics.DrawLine(pPen, pArea.X2, pArea.Y1, pArea.X2, pArea.Y2);
			pGraphics.DrawLine(pPen, pArea.X2, pArea.Y2, pArea.X1, pArea.Y2);
			pGraphics.DrawLine(pPen, pArea.X1, pArea.Y2, pArea.X1, pArea.Y1);
		}

		private void MouseDownSub(MouseEventArgs e, Control pControl, PointID pID)
		{
			double x = e.Location.X;
			double y = pControl.ClientSize.Height - 1 - e.Location.Y;

			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
				x = Math.Round(x / 10, MidpointRounding.AwayFromZero) * 10;
				y = Math.Round(y / 10, MidpointRounding.AwayFromZero) * 10;
			}

			this.mPointDic[pID] = new System.Windows.Point(x, y);
			pControl.Invalidate();
		}

		#region GetPointLR
		private void pnlGetPointLR_Paint(object sender, PaintEventArgs e)
		{
			double length = CSGeometries.Geometry.GetPerpendicularlineLength(
													this.mPointDic[PointID.GetPointLR_S],
													this.mPointDic[PointID.GetPointLR_E],
													this.mPointDic[PointID.GetPointLR_P]);

			System.Windows.Point crossPoint = CSGeometries.Geometry.GetPerpendicularlinePoint(
													this.mPointDic[PointID.GetPointLR_S],
													this.mPointDic[PointID.GetPointLR_E],
													this.mPointDic[PointID.GetPointLR_P]);

			GraphicsState state = e.Graphics.Save();
			try {
				e.Graphics.TranslateTransform(0, this.pnlGetPointLR.Height - 1);
				e.Graphics.ScaleTransform(1, -1);

				this.DrawLine(e.Graphics, PointID.GetPointLR_S, PointID.GetPointLR_E);
				this.DrawPoint(e.Graphics, PointID.GetPointLR_P, this.mPenBlack);

				this.DrawLine(e.Graphics, this.mPointDic[PointID.GetPointLR_P], crossPoint, this.mPenRed);
				this.DrawPoint(e.Graphics, crossPoint, this.mPenRed);
			}
			finally {
				e.Graphics.Restore(state);
			}

			double ans = CSGeometries.Geometry.GetPointLR(this.mPointDic[PointID.GetPointLR_S],
														  this.mPointDic[PointID.GetPointLR_E],
														  this.mPointDic[PointID.GetPointLR_P]);

			string strwk;
			if (ans == 0.0) {
				strwk = "ONLINE";
			} else if (ans > 0.0) {
				strwk = "RIGHT";
			} else {
				strwk = "LEFT";
			}

			strwk = string.Format("S:{0}\nE:{1}\nP:{2}\nPos:{3}\nGetPerpendicularlineLength:{4}\nCrossPoint:{5}",
				GetPointString(this.mPointDic[PointID.GetPointLR_S]),
				GetPointString(this.mPointDic[PointID.GetPointLR_E]),
				GetPointString(this.mPointDic[PointID.GetPointLR_P]),
				strwk,
				length,
				GetPointString(crossPoint));

			e.Graphics.DrawString(strwk, this.Font, mBrushBlack, 0, 0);
		}

		private void pnlGetPointLR_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDownSub(e, this.pnlGetPointLR, PointID.GetPointLR_P);
		}
		#endregion

		#region
		private void pnlGetCrossPoint_Paint(object sender, PaintEventArgs e)
		{
			bool isCross;
			System.Windows.Point crossPoint = CSGeometries.Geometry.GetCrossPoint(
												this.mPointDic[PointID.GetCrossPoint_11],
												this.mPointDic[PointID.GetCrossPoint_12],
												this.mPointDic[PointID.GetCrossPoint_21],
												this.mPointDic[PointID.GetCrossPoint_22],
												out isCross);

			GraphicsState state = e.Graphics.Save();
			try {
				e.Graphics.TranslateTransform(0, this.pnlGetCrossPoint.Height - 1);
				e.Graphics.ScaleTransform(1, -1);

				this.DrawLine(e.Graphics, PointID.GetCrossPoint_11, PointID.GetCrossPoint_12);
				this.DrawLine(e.Graphics, PointID.GetCrossPoint_21, PointID.GetCrossPoint_22);
				this.DrawPoint(e.Graphics, PointID.GetCrossPoint_22, this.mPenBlack);
				if (isCross) {
					this.DrawPoint(e.Graphics, crossPoint, this.mPenRed);
				}
			}
			finally {
				e.Graphics.Restore(state);
			}

			StringBuilder sb = new StringBuilder(1024);
			string strwk;

			strwk = string.Format("L1:{0}\nL2:{1}\n",
				GetPointString(PointID.GetCrossPoint_11, PointID.GetCrossPoint_12),
				GetPointString(PointID.GetCrossPoint_21, PointID.GetCrossPoint_22));
			sb.Append(strwk);

			if (isCross) {
				strwk = string.Format("CrossPoint:{0}", this.GetPointString(crossPoint));
			} else {
				strwk = "NOT CROSS";
			}
			sb.Append(strwk);

			if (isCross) {
				if (CSGeometries.Geometry.InRect(this.mPointDic[PointID.GetCrossPoint_11],
						this.mPointDic[PointID.GetCrossPoint_12],
						crossPoint)) {
					sb.Append("\nRECT IN");
				} else {
					sb.Append("\nRECT OUT");
				}
			}

			e.Graphics.DrawString(sb.ToString(), this.Font, mBrushBlack, 0, 0);
		}

		private void pnlGetCrossPoint_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDownSub(e, this.pnlGetCrossPoint, PointID.GetCrossPoint_22);
		}
		#endregion

		#region GetLength
		private void pnlGetLength_Paint(object sender, PaintEventArgs e)
		{
			double length = CSGeometries.Geometry.GetLength(
												this.mPointDic[PointID.GetLength_S],
												this.mPointDic[PointID.GetLength_E]);

			GraphicsState state = e.Graphics.Save();
			try {
				e.Graphics.TranslateTransform(0, this.pnlGetCrossPoint.Height - 1);
				e.Graphics.ScaleTransform(1, -1);

				this.DrawLine(e.Graphics, PointID.GetLength_S, PointID.GetLength_E);
				this.DrawPoint(e.Graphics, PointID.GetLength_E, this.mPenRed);
			}
			finally {
				e.Graphics.Restore(state);
			}

			string strwk;
			strwk = string.Format("Length:{0}", length);

			strwk = string.Format("{0}\n{1}",
				GetPointString(PointID.GetLength_S, PointID.GetLength_E),
				strwk);

			e.Graphics.DrawString(strwk, this.Font, mBrushBlack, 0, 0);
		}

		private void pnlGetLength_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDownSub(e, this.pnlGetLength, PointID.GetLength_E);
		}
		#endregion

		#region GetAngle
		private void pnlGetAngle_Paint(object sender, PaintEventArgs e)
		{
			double angle;
			bool valid = CSGeometries.Geometry.GetAngle(
												this.mPointDic[PointID.GetAngle_1],
												this.mPointDic[PointID.GetAngle_2],
												this.mPointDic[PointID.GetAngle_3],
												out angle
												);

			GraphicsState state = e.Graphics.Save();
			try {
				e.Graphics.TranslateTransform(0, this.pnlGetCrossPoint.Height - 1);
				e.Graphics.ScaleTransform(1, -1);

				this.DrawLine(e.Graphics, PointID.GetAngle_1, PointID.GetAngle_2);
				this.DrawLine(e.Graphics, PointID.GetAngle_2, PointID.GetAngle_3);
				this.DrawPoint(e.Graphics, PointID.GetAngle_3, this.mPenRed);
			}
			finally {
				e.Graphics.Restore(state);
			}

			StringBuilder sb = new StringBuilder(1024);
			sb.Append("P1:");
			sb.Append(GetPointString(PointID.GetAngle_1));
			sb.Append("\nP2:");
			sb.Append(GetPointString(PointID.GetAngle_2));
			sb.Append("\nP3:");
			sb.Append(GetPointString(PointID.GetAngle_3));
			sb.Append("\nAngle");
			if (valid) {
				sb.Append("(RAD):");
				sb.Append(angle);
				sb.Append("\nAngle(DEG):");
				sb.Append(CSGeometries.Geometry.RadianToDegree(angle));
			} else {
				sb.Append(":ERROR");
			}

			e.Graphics.DrawString(sb.ToString(), this.Font, mBrushBlack, 0, 0);
		}

		private void pnlGetAngle_MouseDown(object sender, MouseEventArgs e)
		{
			this.MouseDownSub(e, this.pnlGetAngle, PointID.GetAngle_3);
		}
		#endregion

		#region HSV
		private void pnlHSV_Paint(object sender, PaintEventArgs e)
		{
			int centerX = this.pnlHSV.ClientSize.Width / 2;
			int centerY = this.pnlHSV.ClientSize.Height / 2;

			double w = this.pnlHSV.ClientSize.Width / 360;
		}

		bool blHSVEventSkip = false;

		private void trkHSVRGB_ValueChanged(object sender, EventArgs e)
		{
			this.txtHSVR.Text = (this.trkHSVR.Value / 100.0).ToString();
			this.txtHSVG.Text = (this.trkHSVG.Value / 100.0).ToString();
			this.txtHSVB.Text = (this.trkHSVB.Value / 100.0).ToString();

			if (blHSVEventSkip) {
				return;
			}

			blHSVEventSkip = true;

			CSGeometries.ColorModels.ColorD rgb = new CSGeometries.ColorModels.ColorD(
															this.trkHSVR.Value / 100.0,
															this.trkHSVG.Value / 100.0,
															this.trkHSVB.Value / 100.0);

			CSGeometries.ColorModels.HSV hsv = CSGeometries.ColorModels.HSV.FromColorD(rgb);

			this.trkHSVH.Value = (int)hsv.H;
			this.trkHSVS.Value = (int)(hsv.S * 100);
			this.trkHSVV.Value = (int)(hsv.V * 100);

			this.lblHSVBox.BackColor = Color.FromArgb(this.trkHSVR.Value * 255 / 100,
													  this.trkHSVG.Value * 255 / 100,
													  this.trkHSVB.Value * 255 / 100);
			blHSVEventSkip = false;
		}

		private void trkHSVHSV_ValueChanged(object sender, EventArgs e)
		{
			this.txtHSVH.Text = (this.trkHSVH.Value).ToString();
			this.txtHSVS.Text = (this.trkHSVS.Value / 100.0).ToString();
			this.txtHSVV.Text = (this.trkHSVV.Value / 100.0).ToString();

			if (blHSVEventSkip) {
				return;
			}

			blHSVEventSkip = true;

			CSGeometries.ColorModels.HSV hsv = new CSGeometries.ColorModels.HSV(
															this.trkHSVH.Value,
															this.trkHSVS.Value / 100.0,
															this.trkHSVV.Value / 100.0);

			CSGeometries.ColorModels.ColorD rgb = CSGeometries.ColorModels.ColorD.FromHSV(hsv);

			this.trkHSVR.Value = (int)(rgb.R * 100);
			this.trkHSVG.Value = (int)(rgb.G * 100);
			this.trkHSVB.Value = (int)(rgb.B * 100);

			this.lblHSVBox.BackColor = Color.FromArgb(this.trkHSVR.Value * 255 / 100,
													  this.trkHSVG.Value * 255 / 100,
													  this.trkHSVB.Value * 255 / 100);
			blHSVEventSkip = false;
		}
		#endregion

		#region Clip
		private void button1_Click(object sender, EventArgs e)
		{
			this.pnlClip.Invalidate();
		}
		private void pnlClip_Paint(object sender, PaintEventArgs e)
		{
			CSGeometries.Line areaDiagonalLine = new CSGeometries.Line(64, 64, this.pnlClip.ClientSize.Width - 64, pnlClip.ClientSize.Height - 64).MarshalMaxmin();

			DrawRect(e.Graphics, areaDiagonalLine, this.mPenGray);

			Random rnd = new Random();
			for (int i = 0; i < 10; i++) {
				CSGeometries.Line line = new CSGeometries.Line(rnd.Next(this.pnlClip.ClientSize.Width),
																rnd.Next(this.pnlClip.ClientSize.Height),
																rnd.Next(this.pnlClip.ClientSize.Width),
																rnd.Next(this.pnlClip.ClientSize.Height));
				e.Graphics.DrawLine(this.mPenGray, (int)line.X1, (int)line.Y1, (int)line.X2, (int)line.Y2);
				if (CSGeometries.Geometry.Clip(areaDiagonalLine, line)) {
					e.Graphics.DrawLine(this.mPenRed, (int)line.X1, (int)line.Y1, (int)line.X2, (int)line.Y2);
				}
			}
		}
		#endregion
	}

	static class Extensions
	{
		public static PointF ToFloat(this System.Windows.Point pPointD)
		{
			return new PointF((float)pPointD.X, (float)pPointD.Y);
		}
	}
}
