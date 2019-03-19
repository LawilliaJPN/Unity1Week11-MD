using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TipsTextManager : MonoBehaviour {
    [BoxGroup("Game"), ShowInInspector, ReadOnly]
    public const string Tips3Wave = "3ウェーブの合計スコアを競うゲームだ。";


    [BoxGroup("Controll"), ShowInInspector, ReadOnly]
    public const string TipsControllMoveWASD  = "WASDキーで、移動することができる。";

    [BoxGroup("Controll"), ShowInInspector, ReadOnly]
    public const string TipsControllMoveArrow = "方向キーでも、移動することができる。";

    [BoxGroup("Controll"), ShowInInspector, ReadOnly]
    public const string TipsControllMoveHJKL = "HJKLキーでも、移動することができる。";

    [BoxGroup("Controll"), ShowInInspector, ReadOnly]
    public const string TipsControllShootClick = "左クリックで、弾を撃つことができる。";

    [BoxGroup("Controll"), ShowInInspector, ReadOnly]
    public const string TipsControllShootSpace = "スペースキーでも、弾を撃つことができる。";


    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreWhenBulletCollideWithTarget = "撃った弾が的に当たると、1ポイント加算される。";

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreWhenGroupBulletCollideWithTarget = "的と的をつなげると、5ポイント加算される。";

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreWhenTargetCollideWithTarget = "的同士が衝突した時のスコア加算は、本来の4割だ。";

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreWhenPlayerCollideWithTarget = "ミスになって的が消えた時のスコア加算は、本来の2割だ。";

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreWhenWaveFinish = "ウェーブ終了時に消えた的からのスコア加算は、本来の8割だ。";

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const string TipsScoreExplosion = "弾と的を5つ以上繋げて消せば、一番多くスコアが加算される。";


    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionBulletAndBullet = "弾同士で衝突すると、つながっていない弾は消滅する。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionBulletAndBulletRapidFire = "連射が速すぎると、弾同士が衝突してしまう。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndBullet = "弾と的が衝突すると、「つながる」。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndPlayer = "的と接触してしまうと、すべての弾や的が消える。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndTarget = "的同士で衝突すると、消滅してスコアが少し加算される。";


    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenSlowdown = "弾がくっつくと、的の移動速度が遅くなる。";

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenStop = "弾と的が3つ以上つながると、的は移動しなくなる。";

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenExplosion = "弾と的が5つ以上つながると、消滅してスコアが加算される。";


    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceNotConnect = "弾をつけすぎると、的を3つ以上つなげられなくなる。";

    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceConnect = "的を3つ以上つなげられると、高スコアを狙える。";

    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceRight = "画面右よりで的を停止させると、狙いやすい。";

    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceNotRapidFire = "連射するよりも、タイミングを考えて撃つことが大事だ。";
}
