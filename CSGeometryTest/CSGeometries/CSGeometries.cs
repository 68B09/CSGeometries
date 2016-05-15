/*
The MIT License (MIT)

Copyright (c) 2016 ZZO.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/

using System;
using System.Windows;

namespace CSGeometries
{
	/// <summary>
	/// 幾何計算クラス
	/// </summary>
	public class Geometry
	{
		/// <summary>
		/// 線分長取得
		/// </summary>
		/// <param name="p1">座標点1</param>
		/// <param name="p2">座標点2</param>
		/// <returns>長さ</returns>
		public static double GetLength(System.Windows.Point p1, System.Windows.Point p2)
		{
			double dx = p1.X - p2.X;
			double dy = p1.Y - p2.Y;
			double ans = Math.Sqrt((dx * dx) + (dy * dy));
			return ans;
		}

		/// <summary>
		/// 内積取得
		/// </summary>
		/// <param name="p1">座標点1</param>
		/// <param name="p2">座標点2</param>
		/// <returns>内積</returns>
		public static double GetDot(System.Windows.Point p1, System.Windows.Point p2)
		{
			double dot = (p1.X * p2.X) + (p1.Y * p2.Y);
			return dot;
		}

		/// <summary>
		/// 線に対する点の位置を取得
		/// </summary>
		/// <param name="pStart">線の開始座標</param>
		/// <param name="pEnd">線の終了座標</param>
		/// <param name="pPoint">点の座標</param>
		/// <returns>負=点は線の方向に対して左に存在、0=線上、正=右</returns>
		/// <remarks>
		/// 点pStartからpEndに向かっている直線から見た点pPointの左右位置を返す。
		/// </remarks>
		public static double GetPointLR(System.Windows.Point pStart, System.Windows.Point pEnd, System.Windows.Point pPoint)
		{
			double pos = ((pEnd.Y - pStart.Y) * (pPoint.X - pStart.X)) - ((pPoint.Y - pStart.Y) * (pEnd.X - pStart.X));
			return pos;
		}

		/// <summary>
		/// 直線交差判定
		/// </summary>
		/// <param name="pL1_1">直線1の座標1</param>
		/// <param name="pL1_2">直線1の座標2</param>
		/// <param name="pL2_1">直線2の座標1</param>
		/// <param name="pL2_2">直線2の座標2</param>
		/// <returns>0=交差しない、0!=交差する</returns>
		public static double IsCross(System.Windows.Point pL1_1, System.Windows.Point pL1_2, System.Windows.Point pL2_1, System.Windows.Point pL2_2)
		{
			double wk = ((pL1_2.X - pL1_1.X) * (pL2_2.Y - pL2_1.Y)) - ((pL2_2.X - pL2_1.X) * (pL1_2.Y - pL1_1.Y));
			return wk;
		}

		/// <summary>
		/// 2直線の交点を取得
		/// </summary>
		/// <param name="pL1_1">直線1の座標1</param>
		/// <param name="pL1_2">直線1の座標2</param>
		/// <param name="pL2_1">直線2の座標1</param>
		/// <param name="pL2_2">直線2の座標2</param>
		/// <param name="pIsCross">true=交差する(戻り値有効)、false=しない</param>
		/// <returns>交点座標</returns>
		public static System.Windows.Point GetCrossPoint(System.Windows.Point pL1_1, System.Windows.Point pL1_2, System.Windows.Point pL2_1, System.Windows.Point pL2_2, out bool pIsCross)
		{
			double keisu = IsCross(pL1_1, pL1_2, pL2_1, pL2_2);
			pIsCross = keisu != 0.0;
			if (pIsCross == false) {
				return new System.Windows.Point(0, 0);
			}

			double x = (((pL1_2.Y - pL1_1.Y) * (pL2_2.X - pL2_1.X) * pL1_1.X)
					  - ((pL2_2.Y - pL2_1.Y) * (pL1_2.X - pL1_1.X) * pL2_1.X)
					  + ((pL2_1.Y - pL1_1.Y) * (pL1_2.X - pL1_1.X) * (pL2_2.X - pL2_1.X))) / (-keisu);

			double y = (((pL1_2.X - pL1_1.X) * (pL2_2.Y - pL2_1.Y) * pL1_1.Y)
					 - ((pL2_2.X - pL2_1.X) * (pL1_2.Y - pL1_1.Y) * pL2_1.Y)
					 + ((pL2_1.X - pL1_1.X) * (pL1_2.Y - pL1_1.Y) * (pL2_2.Y - pL2_1.Y))) / keisu;

			return new System.Windows.Point(x, y);
		}

		/// <summary>
		/// 矩形内判定
		/// </summary>
		/// <param name="p1">線分座標点1</param>
		/// <param name="p2">線分座標点2</param>
		/// <param name="pPoint">判定座標点</param>
		/// <returns>true=矩形内、false=外</returns>
		/// <remarks>
		/// 線分 p1-p2 で示される矩形内に点pPointが入っているか否かを判定する。
		/// </remarks>
		public static bool InRect(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point pPoint)
		{
			double xmin = Math.Min(p1.X, p2.X);
			double xmax = Math.Max(p1.X, p2.X);
			double ymin = Math.Min(p1.Y, p2.Y);
			double ymax = Math.Max(p1.Y, p2.Y);

			if ((pPoint.X >= xmin) && (pPoint.X <= xmax) &&
				(pPoint.Y >= ymin) && (pPoint.Y <= ymax)) {
				return true;
			}

			return false;
		}

		/// <summary>
		/// 垂線長取得
		/// </summary>
		/// <param name="p1">線分座標点1</param>
		/// <param name="p2">線分座標点2</param>
		/// <param name="pPoint">判定座標点</param>
		/// <returns>長さ</returns>
		/// <remarks>
		/// 点 pPoint から線分 p1-p2 への垂線長を返す。
		/// </remarks>
		public static double GetPerpendicularlineLength(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point pPoint)
		{
			double dx = p2.X - p1.X;
			double dy = p2.Y - p1.Y;

			double len = Math.Sqrt((dx * dx) + (dy * dy));

			if (len == 0.0) {
				return GetLength(p1, pPoint);
			}

			double length = ((dx * (pPoint.Y - p1.Y)) - (dy * (pPoint.X - p1.X))) / len;
			return length;
		}

		/// <summary>
		/// 垂線交点取得
		/// </summary>
		/// <param name="p1">直線座標点1</param>
		/// <param name="p2">直線座標点2</param>
		/// <param name="pPoint">垂線基準座標点</param>
		/// <returns>交点座標</returns>
		/// <remarks>
		/// 座標 pPoint から直線 p1-p2 に垂線を引いたときの直線上の交点を返す。
		/// </remarks>
		public static System.Windows.Point GetPerpendicularlinePoint(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point pPoint)
		{
			if (p1.X == p2.X) {
				return new System.Windows.Point(p1.X, pPoint.Y);
			}

			if (p1.Y == p2.Y) {
				return new System.Windows.Point(pPoint.X, p1.Y);
			}

			double m = (p2.Y - p1.Y) / (p2.X - p1.X);
			double m2 = (m * m) + 1.0;

			double x = ((m * ((m * p1.X) - p1.Y + pPoint.Y)) + pPoint.X) / m2;
			double y = ((m * ((m * pPoint.Y) - p1.X + pPoint.X)) + p1.Y) / m2;
			return new Point(x, y);
		}

		/// <summary>
		/// 最小・最大値整合
		/// </summary>
		/// <param name="pMin">最小値</param>
		/// <param name="pMax">最大値</param>
		/// <remarks>
		/// 座標 pMin,pMax のX,Y座標を入れ替え、pMin=最小値、pMax=最大値になるように調整する。
		/// </remarks>
		public static void MarshalMaxmin(ref System.Windows.Point pMin, ref System.Windows.Point pMax)
		{
			double xmin = Math.Min(pMin.X, pMax.X);
			double xmax = Math.Max(pMin.X, pMax.X);
			double ymin = Math.Min(pMin.Y, pMax.Y);
			double ymax = Math.Max(pMin.Y, pMax.Y);

			pMin = new System.Windows.Point(xmin, ymin);
			pMax = new System.Windows.Point(xmax, ymax);
		}

		/// <summary>
		/// 折れ線がなす角度を取得
		/// </summary>
		/// <param name="p1">折れ線座標点1</param>
		/// <param name="p2">折れ線座標点2</param>
		/// <param name="p3">折れ線座標点3</param>
		/// <param name="pAngle">角度(ラジアン)</param>
		/// <returns>true=成功、false=失敗(線分の長さがゼロ)</returns>
		/// <remarks>
		/// 折れ線 p1-p2-p3 のなす角度を返す。
		/// p1-p2 もしくは p2-p3 の線分長さがゼロの場合は失敗する。
		/// </remarks>
		public static bool GetAngle(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point p3, out double pAngle)
		{
			double l1 = GetLength(p1, p2);
			double l2 = GetLength(p2, p3);

			if ((l1 == 0.0) || (l2 == 0.0)) {
				pAngle = 0.0;
				return false;
			}

			double l3 = GetLength(p1, p3);

			pAngle = (l3 * l3) - (l2 * l2) - (l1 * l1);
			pAngle = pAngle / (-2.0 * l1 * l2);
			pAngle = Math.Acos(pAngle);

			return true;
		}

		/// <summary>
		/// RAD→DEG
		/// </summary>
		/// <param name="pAngle">RAD角度</param>
		/// <returns>DEG角度</returns>
		public static double RadianToDegree(double pAngle)
		{
			double deg = pAngle * (180.0 / Math.PI);
			return deg;
		}

		/// <summary>
		/// DEG→RAD
		/// </summary>
		/// <param name="pAngle">DEG角度</param>
		/// <returns>RAD角度</returns>
		public static double DegreeToRadian(double pAngle)
		{
			double rad = pAngle * (Math.PI / 180.0);
			return rad;
		}
	}
}
