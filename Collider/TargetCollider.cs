using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(TargetManager))]

public class TargetCollider :MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private DestroyAll scriptDestroyAll;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputTips scriptOutputTips;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private TargetManager scriptTargetManager;

    private void Awake() {
        this.objectGameDirector = GameObject.FindWithTag("Director");
        this.scriptDestroyAll = this.objectGameDirector.GetComponent<DestroyAll>();
        this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

        this.scriptTargetManager = this.GetComponent<TargetManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Target") {
            this.CollisionWithTarget(collision);

        } else if (collision.gameObject.tag == "Player") {
            this.CollisionWithPlayer(collision);
        }
    }

    private void CollisionWithTarget(Collision2D collision) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("TargetCollider CollisionWithTarget");
        }

        TargetManager scriptCollisionTargetManager = collision.gameObject.GetComponent<TargetManager>();

        GameObject objectThisParent = this.scriptTargetManager.ObjectMyParent;
        GameObject objectCollisionTargetParent = scriptCollisionTargetManager.ObjectMyParent;

        bool thisIsIsolated = objectThisParent.tag != "GroupParent";
        bool collisionBulletIsIsolated = objectCollisionTargetParent.tag != "GroupParent";

        if (thisIsIsolated) {
            Destroy(this.gameObject);

        } else {
            objectThisParent.GetComponent<ParentManager>().Explosion();

        }

        if (collisionBulletIsIsolated) {
            Destroy(this.gameObject);

        } else {
            objectCollisionTargetParent.GetComponent<ParentManager>().Explosion();
        }

        if (!TipsBoolManager.isAlreadyTipsCollisionTargetAndTarget) {
            this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionTargetAndTarget);
            TipsBoolManager.isAlreadyTipsCollisionTargetAndTarget = true;
        }
    }

    private void CollisionWithPlayer(Collision2D collision) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("TargetCollider CollisionWithPlayer");
        }

        this.scriptDestroyAll.DestroyAllGroup();

        if (!TipsBoolManager.isAlreadyTipsCollisionTargetAndPlayer) {
            this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionTargetAndPlayer);
            TipsBoolManager.isAlreadyTipsCollisionTargetAndPlayer = true;
        }
    }
}