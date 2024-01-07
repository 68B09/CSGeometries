/*
The MIT License (MIT)

Copyright (c) 2016-2018 ZZO.

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
	public partial class Geometry
	{
		/// <summary>
		/// 線分長取得
		/// </summary>
		/// <param name="p1">座標点1</param>
		/// <param name="p2">座標点2</param>
		/// <returns>長さ</returns>
		public static double GetLength(System.Windows.Point p1, System.Windows.Point p2)
		{
			return GetLength(p1.X, p1.Y, p2.X, p2.Y);
		}

		/// <summary>
		/// 線分長取得
		/// </summary>
		/// <param name="pX1">座標点1X</param>
		/// <param name="pY1">座標点1Y</param>
		/// <param name="pX2">座標点2X</param>
		/// <param name="pY2">座標点2Y</param>
		/// <returns>長さ</returns>
		public static double GetLength(double pX1, double pY1, double pX2, double pY2)
		{
			double dx = pX1 - pX2;
			double dy = pY1 - pY2;
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
		/// <param name="p1">矩形対角座標点1</param>
		/// <param name="p2">矩形対角座標点2</param>
		/// <param name="pPoint">判定座標点</param>
		/// <returns>true=矩形内、false=外</returns>
		/// <remarks>
		/// 対角線 p1-p2 で示される矩形内に点pPointが入っているか否かを判定する。
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
		/// 矩形内判定
		/// </summary>
		/// <param name="p1">矩形対角座標点1</param>
		/// <param name="p2">矩形対角座標点2</param>
		/// <param name="pPoints">判定座標群</param>
		/// <returns>true=すべて矩形内、false=外</returns>
		/// <remarks>
		/// 対角線 p1-p2 で示される矩形内に点群pPointsが入っているか否かを判定する。
		/// </remarks>
		public static bool InRect(System.Windows.Point p1, System.Windows.Point p2, params System.Windows.Point[] pPoints)
		{
			double xmin = Math.Min(p1.X, p2.X);
			double xmax = Math.Max(p1.X, p2.X);
			double ymin = Math.Min(p1.Y, p2.Y);
			double ymax = Math.Max(p1.Y, p2.Y);

			for (int i = 0; i < pPoints.Length; i++) {
				if ((pPoints[i].X < xmin) || (pPoints[i].X > xmax) ||
					(pPoints[i].Y < ymin) || (pPoints[i].Y > ymax)) {
					return false;
				}
			}

			return true;
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
		/// 垂線長取得(線分上判定)
		/// </summary>
		/// <param name="p1">線分座標点1</param>
		/// <param name="p2">線分座標点2</param>
		/// <param name="pPoint">判定座標点</param>
		/// <returns>長さ。交点が線分上に無い場合はnull</returns>
		/// <remarks>
		/// 点 pPoint から線分 p1-p2 への垂線長を返す。
		/// </remarks>
		public static double? GetPerpendicularlineLengthOnLine(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point pPoint)
		{
			Point? crossPoint = GetPerpendicularlinePointOnLine(p1, p2, pPoint);
			if (crossPoint == null) {
				return null;
			}
			return GetLength(pPoint, crossPoint.Value);
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
		/// 垂直交点取得(線分上判定)
		/// </summary>
		/// <param name="p1">直線座標点1</param>
		/// <param name="p2">直線座標点2</param>
		/// <param name="pPoint">垂線基準座標点</param>
		/// <returns>交点座標。交点が線分上に無い場合はnull</returns>
		/// <remarks>
		/// GetPerpendicularlinePointで求めた交点が線分上であれば交点座標を、線分上に無ければnullを返す。
		/// </remarks>
		public static System.Windows.Point? GetPerpendicularlinePointOnLine(System.Windows.Point p1, System.Windows.Point p2, System.Windows.Point pPoint)
		{
			System.Windows.Point ans = GetPerpendicularlinePoint(p1, p2, pPoint);
			MarshalMaxmin(ref p1, ref p2);
			if ((ans.X < p1.X) || (ans.X > p2.X) || (ans.Y < p1.Y) || (ans.Y > p2.Y)) {
				return null;
			}
			return ans;
		}

		/// <summary>
		/// 範囲内丸め
		/// </summary>
		/// <param name="pValue">値</param>
		/// <param name="pMin">許容最小値</param>
		/// <param name="pMax">許容最大値</param>
		/// <returns></returns>
		public static double GetInRange(double pValue, double pMin, double pMax)
		{
			if (pValue < pMin) {
				return pMin;
			} else if (pValue > pMax) {
				return pMax;
			} else {
				return pValue;
			}
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
		/// 最小最大座標点取得
		/// </summary>
		/// <param name="pPoints">座標群</param>
		/// <param name="pMin">最小座標</param>
		/// <param name="pMax">最大座標</param>
		/// <remarks>
		/// 座標群 sPoints 中から最小・最大座標を取得する。
		/// </remarks>
		public static void GetMaxmin(System.Windows.Point[] pPoints, out System.Windows.Point pMin, out System.Windows.Point pMax)
		{
			pMin = pMax = new Point(0, 0);

			for (int i = 0; i < pPoints.Length; i++) {
				if (i == 0) {
					pMin = pMax = pPoints[i];
				} else {
					if (pMin.X > pPoints[i].X) {
						pMin.X = pPoints[i].X;
					}
					if (pMin.Y > pPoints[i].Y) {
						pMin.Y = pPoints[i].Y;
					}

					if (pMax.X < pPoints[i].X) {
						pMax.X = pPoints[i].X;
					}
					if (pMax.Y < pPoints[i].Y) {
						pMax.Y = pPoints[i].Y;
					}
				}
			}
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

		/// <summary>
		/// 飽和丸め
		/// </summary>
		/// <param name="pValue">値</param>
		/// <param name="pMin">下限値</param>
		/// <param name="pMax">上限値</param>
		/// <returns>飽和処理後の値</returns>
		/// <remarks>
		/// pValueが上下限値内に収まるように調整する。
		/// </remarks>
		public static double Saturation(double pValue, double pMin = 0.0, double pMax = 1.0)
		{
			if (pValue < pMin) {
				return pMin;
			} else if (pValue > pMax) {
				return pMax;
			}
			return pValue;
		}

		/// <summary>
		/// 最大公約数取得
		/// </summary>
		/// <param name="p1">値1</param>
		/// <param name="p2">値2</param>
		/// <returns>最大公約数</returns>
		/// <remarks>
		/// p1及びp2の最大公約数を返す。
		/// p1＜0 OR p2＜0 の場合は例外を起こす。
		/// p1==0 OR p2==0 の場合は0を返す。
		/// </remarks>
		public static long GCD(long p1, long p2)
		{
			if ((p1 < 0) || (p2 < 0)) {
				throw new ArgumentOutOfRangeException("負数が指定された");
			}

			if ((p1 == 0) || (p2 == 0)) {
				return 0;
			}

			if (p1 < p2) {
				return GCD(p2, p1);
			}

			while (p2 != 0) {
				long remain = p1 % p2;
				p1 = p2;
				p2 = remain;
			}

			return p1;
		}

		/// <summary>
		/// 最小公倍数取得
		/// </summary>
		/// <param name="p1">値1</param>
		/// <param name="p2">値2</param>
		/// <returns>最小公倍数</returns>
		/// <remarks>
		/// p1及びp2の最小公倍数を返す。
		/// p1＜0 OR p2＜0 の場合は例外を起こす。
		/// p1==0 OR p2==0 の場合は0を返す。
		/// </remarks>
		public static long LCM(long p1, long p2)
		{
			if ((p1 < 0) || (p2 < 0)) {
				throw new ArgumentOutOfRangeException("負数が指定された");
			}

			if ((p1 == 0) || (p2 == 0)) {
				return 0;
			}

			return (p1 * p2) / GCD(p1, p2);
		}

		/// <summary>
		/// 素因数分解
		/// </summary>
		/// <param name="pValue">値</param>
		/// <returns>素数リスト</returns>
		/// <remarks>
		/// pValueを素因数分解した結果を返す。
		/// pValueが1未満の場合は例外を起こす。
		/// 素数リストには1以上の素数が格納される。
		/// 素数リストには同一値の素数が複数格納される場合がある。
		/// </remarks>
		public static System.Collections.Generic.List<long> PrimeFactorization(long pValue)
		{
			if (pValue < 1) {
				throw new ArgumentOutOfRangeException("1未満の値が指定された");
			}

			System.Collections.Generic.List<long> list = new System.Collections.Generic.List<long>();

			if (pValue == 1) {
				list.Add(1);
			} else {
				long n = 2;
				while ((pValue % n) == 0) {
					list.Add(n);
					pValue /= n;
				}

				n = 3;
				while (n < pValue) {
					while ((pValue % n) == 0) {
						list.Add(n);
						pValue /= n;
					}
					n += 2;
				}
				if (pValue != 1) {
					list.Add(pValue);
				}
			}

			return list;
		}

		/// <summary>
		/// 対角座標から4点を作成
		/// </summary>
		/// <param name="p1">対角座標1</param>
		/// <param name="p2">対角座標2</param>
		/// <param name="pTable">矩形座標</param>
		/// <remarks>
		/// 対角座標から矩形を構成する4点を作成する。
		/// </remarks>
		public static void Rect2PointTo4Point(Point p1, Point p2, Point[] pTable)
		{
			pTable[0] = p1;
			pTable[1] = new Point(p2.X, p1.Y);
			pTable[2] = p2;
			pTable[3] = new Point(p1.X, p2.Y);
		}
	}
}
