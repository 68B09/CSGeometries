# CSGeometries
C#用幾何計算クラス
======================
線分の長さや線交差座標等を求めるための幾何計算クラスや、RGB-HSV相互変換などのカラーモデル変換クラスを実装しています。

言語・開発環境
------
C#/.NET Framework 4.0/VisualStudio2015

使い方
------
１、プロジェクトへの登録  
CSGeometries.csproj を自身の .sln に登録するなどしてビルドしてください。  

２、コードの利用  
CSGeometryTest が簡易テスト用のドライバになっていますので、これを参考にしてください。  

関連情報
------
１、座標は直交座標系です  
２、座標は、Double型を使用する System.Windows.Point構造体(WindowsBase.dll内) を使用しています  
　　2D用の Point構造体 と名前が重複していることにご注意ください。  
３、条件を満たさないパラメータを与えると不正な結果を返すメソッドもあることに注意してください  
４、ColorDやHSV構造体の多くのメンバ変数が取る値が0.0～1.0であることに注意が必要です。

ライセンス
------
ライセンスを適用するファイルにはライセンスについての記述があります。  
The MIT License (MIT)  
Copyright (c) 2016 ZZO  
see also 'LICENSE' file

履歴
-----
2016/6/4 ZZO(68B09)   
線分クラス(Line)追加。  
線分クリップ(Clip)追加。  
  
2016/5/22 ZZO(68B09)  
ColorModels追加。  
  
2016/5/15 ZZO(68B09)  
First release.
