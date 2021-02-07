# roll-a-ball

## サンプルビルド
https://yuki-tachi.github.io/roll-a-ball/webgl/

## プレイヤーを動かす際に使うmethod

### rigidbody.MovePosition
MovePositionを使う場合はRididbodyのis Kinematicにチェックを入れていない場合、transform.positionで動かしているのと同じで運動を伝播できない
is Kinematicにチェックが入っていると物理的な干渉を受けなくなる。
isKinematicがtrueの場合、Use Gravityにチェックが入っていても無視され、別のオブジェクトがぶつかっても動かない。ただ、周りのオブジェクトに対しては干渉するようになる。物理特性を無視しつつ影響を与えたい場合に使用する
すり抜ける場合はCollision Detectionを変更する

### rigidbody.AddForce
rigidbody.AddForce(Vector3.forward * 0.1f, ForceMode.Force);　と rigidbody.velocity += (Vector3.forward * 0.1f) * Time.fixedDeltaTime / rigidbody.mass;は等価

### deltaTimeとfixedDeltaTime
deltaTimeは直前のフレームと今のフレームで経過した時間を返すプロパティ。fixedDeltaTimeは固定フレーム秒を返すfixedUpdate内でdeltaTimeを呼ぶと、fixedDeltaTimeと同値になる。なのでどちらを使っても結果はおなじになる

### 参考
https://qiita.com/toRisouP/items/930100e25e666494fcd6
