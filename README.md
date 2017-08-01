# KelpNet
KelpNetはChainerを参考に全てC#で実装された深層学習の初学者向けライブラリです


## 特徴
- 行列を使わず配列ループで実装しているので Deep Learning の学習コストを抑えることが出来ます
- 依存する外部ライブラリが無いため、どこで何をしているかを全て観測できます
- 関数を積み重ねるように記述する直感的なコーディングスタイルを採用しています
- C#特有の記述を極力避けているため、C#以外のプログラマーでも、読み切れるようになっていると思います
- 並列計算にOpenCLを採用しているためNvidia以外の演算装置でも処理を高速化することが可能です

### C#で作られているメリット
- 開発環境の構築が容易で、これからプログラミングを学ぶ人にとっても敷居を低くすることが出来ます
- CPU実行時において純粋なPythonで作られているライブラリに対し比較的高パフォーマンスを発揮します
- WindowsFormやUnity等、ビジュアライズを行うための選択肢が豊富です
- 様々な環境に向けたアセンブリを作成できるため、アプリケーションパッケージでの配布が容易です

## このライブラリについて
このライブラリは、他に先行するライブラリと比較すると、まだまだ機能が少ない状態です。
また私自身が深層学習を勉強中であり、間違っている点もあるかと思います。
細やかなことでも構いませんので、何かお気づきの点が御座いましたら、お気軽にご連絡ください。

また、Gitを目下勉強中で、なんらかのマナー違反などが目につきましたら、ご指摘いただけると助かります。


## 連絡方法
ご質問、ご要望はTwitterから適当なつぶやきにご返信ください

Twitter: https://twitter.com/harujoh


最後に、このライブラリが誰かの学習の助けになれば幸いです


## License
Apache License 2.0


## 実装済み関数
- Activations:
　・ELU
　・LeakyReLU
　・ReLU
　・Sigmoid
　・Tanh
　・Softmax
　・Softplus
- Connections:
　・Convolution2D
　・Deconvolution2D
　・EmbedID
　・Linear
　・LSTM
- Poolings:
　・AveragePooling
　・MaxPooling
- LossFunctions:
　・MeanSquaredError
　・SoftmaxCrossEntropy
- Optimizers:
　・AdaDelta
　・AdaGrad
　・Adam
　・MomentumSGD
　・RMSprop
　・SGD
- Others:
　・DropOut
　・BatchNormalization
