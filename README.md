# CSGeometries
C#用幾何計算クラス
======================
線分の長さや線交差座標等を求めるための幾何計算クラスです。

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
４、CSGeometries.Geometry のメソッドを使用した処理は、後に CSGeometries.Algorithm名前空間 に実装するかもしれません。  

ライセンス
------
ライセンスを適用するファイルは CSGeometries.cs のみです。  
The MIT License (MIT)  
Copyright (c) 2016 ZZO  
see also 'LICENSE' file
