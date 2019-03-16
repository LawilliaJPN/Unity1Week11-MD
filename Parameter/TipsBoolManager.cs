using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TipsBoolManager : MonoBehaviour {
    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsCollisionBulletAndBullet;

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsCollisionBulletAndBulletRapidFire;

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsCollisionTargetAndBullet;

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsCollisionTargetAndPlayer;

    [BoxGroup("Collision"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsCollisionTargetAndTarget;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsChildrenStop;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public static bool isAlreadyTipsChildrenExplosion;

    public static void SetIsAlreadyTipsFalse() {
        isAlreadyTipsCollisionBulletAndBullet = false;
        isAlreadyTipsCollisionBulletAndBulletRapidFire = false;
        isAlreadyTipsCollisionTargetAndBullet = false;
        isAlreadyTipsCollisionTargetAndPlayer = false;
        isAlreadyTipsCollisionTargetAndTarget = false;

        isAlreadyTipsChildrenStop = false;
        isAlreadyTipsChildrenExplosion = false;
    }
}
/*

[BoxGroup("GameObject"), ShowInInspector, ReadOnly]
private GameObject objectGameDirector;
[BoxGroup("Component"), ShowInInspector, ReadOnly]
private OutputTips scriptOutputTips;

[SerializeField, BoxGroup("GameObject")]
private GameObject objectGameDirector;
[BoxGroup("Component"), ShowInInspector, ReadOnly]
private OutputTips scriptOutputTips;

this.objectGameDirector = GameObject.FindWithTag("Director");
this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

if (!TipsBoolManager.) {
    this.scriptOutputTips.SetNextTips(TipsTextManager.);
    TipsBoolManager. = true;
}
*/
