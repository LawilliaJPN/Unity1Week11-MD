using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using DG.Tweening;

[RequireComponent(typeof(TargetManager))]

public class TargetCollider :MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private DestroyAll scriptDestroyAll;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputTips scriptOutputTips;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectMainCamera;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private TargetManager scriptTargetManager;

    private void Awake() {
        this.objectGameDirector = GameObject.FindWithTag("Director");
        this.scriptDestroyAll = this.objectGameDirector.GetComponent<DestroyAll>();
        this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

        this.objectMainCamera = GameObject.FindWithTag("MainCamera");

        this.objectSEManager = GameObject.FindWithTag("SEManager");
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

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

        if (this.transform.position.x < collision.transform.position.x) {
            return;
        }

        this.scriptSEManager.PlaySETargetVanish();

        TargetManager scriptCollisionTargetManager = collision.gameObject.GetComponent<TargetManager>();

        GameObject objectThisParent = this.scriptTargetManager.ObjectMyParent;
        GameObject objectCollisionTargetParent = scriptCollisionTargetManager.ObjectMyParent;

        bool thisIsIsolated = objectThisParent.tag != "GroupParent";
        bool collisionBulletIsIsolated = objectCollisionTargetParent.tag != "GroupParent";

        if (!TipsBoolManager.isAlreadyTipsCollisionTargetAndTarget) {
            this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionTargetAndTarget);
            TipsBoolManager.isAlreadyTipsCollisionTargetAndTarget = true;
        }

        if (collisionBulletIsIsolated) {
            Destroy(collision.gameObject);

        } else {
            objectCollisionTargetParent.GetComponent<ParentManager>().Explosion(ConstantManager.PointRatioType.TargetCollideWithTarget);
        }

        if (thisIsIsolated) {
            Destroy(this.gameObject);

        } else {
            objectThisParent.GetComponent<ParentManager>().Explosion(ConstantManager.PointRatioType.TargetCollideWithTarget);

        }
    }

    private void CollisionWithPlayer(Collision2D collision) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("TargetCollider CollisionWithPlayer");
        }

        this.scriptSEManager.PlaySEDamage();
        this.objectMainCamera.transform.DOShakePosition(duration: 1.0f, strength: 0.5f, vibrato: 10, randomness: 90, snapping:false, fadeOut:true);

        this.scriptDestroyAll.DestroyAllGroup(ConstantManager.PointRatioType.PlayerCollideWithTarget);

        if (!TipsBoolManager.isAlreadyTipsCollisionTargetAndPlayer) {
            this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionTargetAndPlayer);
            TipsBoolManager.isAlreadyTipsCollisionTargetAndPlayer = true;
        }
    }
}