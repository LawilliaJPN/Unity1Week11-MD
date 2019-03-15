using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TipsTextManager : MonoBehaviour {
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


    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionBulletAndBullet = "弾同士で衝突すると、つながっていない弾は消滅する。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionBulletAndBulletRapidFire = "連射が速すぎると、弾同士が衝突してしまう。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndBullet = "弾と的が衝突すると、「つながる」。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndPlayer = "的と接触すると、すべての弾や的が消えてしまう。";

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public const string TipsCollisionTargetAndTarget = "的同士で衝突すると、消滅してスコアが加算される。";


    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenSlowdown = "弾がくっつくと、的の移動速度が遅くなる。";

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenStop = "弾と的が3つ以上つながると、的は移動しなくなる。";

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const string TipsChildrenExplosion = "弾と的が5つ以上つながると、消滅してスコアが加算される。";


    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceConnect = "的を多くつなげられると、高スコアを狙える。";

    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceRight = "画面右よりで的を停止させると、狙いやすい。";

    [BoxGroup("Advice"), ShowInInspector, ReadOnly]
    public const string TipsAdviceNotRapidFire = "連射するよりも、タイミングを考えて撃つことが大事だ。";

}
