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

namespace CSGeometries
{
	/// <summary>
	/// 幾何計算クラス
	/// </summary>
	public partial class Geometry
	{
		/// <summary>
		/// クリップ判定フラグ
		/// </summary>
		[Flags]
		public enum ClipFlags : int
		{
			EMPTY = 0,
			UNDERX = 1,
			OVERX = 2,
			UNDERY = 4,
			OVERY = 8,
		}

		/// <summary>
		/// クリップ判定フラグ作成
		/// </summary>
		/// <param name="pAreaDiagonalLine">矩形領域の対角線</param>
		/// <param name="pPoint">判定対象座票</param>
		/// <returns>クリップ判定フラグ</returns>
		/// <remarks>
		/// 判定対象座標が矩形領域内・外のどこにあるかを判定する。
		/// </remarks>
		public static ClipFlags CreateClipFlag(Line pAreaDiagonalLine, System.Drawing.Point pPoint)
		{
			ClipFlags flag = ClipFlags.EMPTY;

			if (pPoint.X < pAreaDiagonalLine.X1) {
				flag |= ClipFlags.UNDERX;
			} else if (pPoint.X > pAreaDiagonalLine.X2) {
				flag |= ClipFlags.OVERX;
			}

			if (pPoint.Y < pAreaDiagonalLine.Y1) {
				flag |= ClipFlags.UNDERY;
			} else if (pPoint.Y > pAreaDiagonalLine.Y2) {
				flag |= ClipFlags.OVERY;
			}

			return flag;
		}

		/// <summary>
		/// 線分矩形領域クリップ
		/// </summary>
		/// <param name="pAreaDiagonalLine">矩形領域の対角線</param>
		/// <param name="pPoint">線分</param>
		/// <returns>true=線分が矩形領域内にある、false=線分は矩形領域外</returns>
		/// <remarks>
		/// pAreaDiagonalLineはあらかじめ最適化(MarshalMaxmin)を実行しておくこと。
		/// </remarks>
		public static bool Clip(Line pAreaDiagonalLine, Line pLine)
		{
			int x = 0;
			int y = 0;

			while (true) {
				ClipFlags f1 = CreateClipFlag(pAreaDiagonalLine, pLine.P1);
				ClipFlags f2 = CreateClipFlag(pAreaDiagonalLine, pLine.P2);

				if ((f1 == ClipFlags.EMPTY) && (f2 == ClipFlags.EMPTY)) {
					return true;
				}

				if ((f1 & f2) != ClipFlags.EMPTY) {
					return false;
				}

				ClipFlags flag = (f1 != ClipFlags.EMPTY) ? (f1) : (f2);

				do {
					if (pLine.X1 == pLine.X2) {
						if (pLine.Y2 < pAreaDiagonalLine.Y1) {
							y = pAreaDiagonalLine.Y1;
						} else if (pLine.Y2 > pAreaDiagonalLine.Y2) {
							y = pAreaDiagonalLine.Y2;
						}
						if (pLine.Y1 < pAreaDiagonalLine.Y1) {
							y = pAreaDiagonalLine.Y1;
						} else if (pLine.Y1 > pAreaDiagonalLine.Y2) {
							y = pAreaDiagonalLine.Y2;
						}
						x = pLine.X1;
						break;
					}

					if ((flag & ClipFlags.UNDERX) != ClipFlags.EMPTY) {
						y = pLine.Y1 + (int)(((pLine.Y2 - pLine.Y1) * (pAreaDiagonalLine.X1 - pLine.X1)) / (double)(pLine.X2 - pLine.X1));
						x = pAreaDiagonalLine.X1;
						break;
					}
					if ((flag & ClipFlags.OVERX) != ClipFlags.EMPTY) {
						y = pLine.Y1 + (int)(((pLine.Y2 - pLine.Y1) * (pAreaDiagonalLine.X2 - pLine.X1)) / (double)(pLine.X2 - pLine.X1));
						x = pAreaDiagonalLine.X2;
						break;
					}
					if (pLine.Y1 == pLine.Y2) {
						if (pLine.X2 < pAreaDiagonalLine.X1) {
							x = pAreaDiagonalLine.X1;
						} else if (pLine.X2 > pAreaDiagonalLine.X2) {
							x = pAreaDiagonalLine.X2;
						}
						if (pLine.X1 < pAreaDiagonalLine.X1) {
							x = pAreaDiagonalLine.X1;
						} else if (pLine.X1 > pAreaDiagonalLine.X2) {
							x = pAreaDiagonalLine.X2;
						}
						y = pLine.Y1;
						break;
					}

					if ((flag & ClipFlags.UNDERY) != ClipFlags.EMPTY) {
						x = pLine.X1 + (int)(((pLine.X2 - pLine.X1) * (pAreaDiagonalLine.Y1 - pLine.Y1)) / (double)(pLine.Y2 - pLine.Y1));
						y = pAreaDiagonalLine.Y1;
						break;
					}

					if ((flag & ClipFlags.OVERY) != ClipFlags.EMPTY) {
						x = pLine.X1 + (int)(((pLine.X2 - pLine.X1) * (pAreaDiagonalLine.Y2 - pLine.Y1)) / (double)(pLine.Y2 - pLine.Y1));
						y = pAreaDiagonalLine.Y2;
					}
				} while (false);

				if (flag == f1) {
					pLine.X1 = x;
					pLine.Y1 = y;
				} else {
					pLine.X2 = x;
					pLine.Y2 = y;
				}
			}
		}
	}
}
