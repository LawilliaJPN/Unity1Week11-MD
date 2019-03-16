using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BulletManager))]

public class BulletCollider :MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputTips scriptOutputTips;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectParentOfGroups;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BulletManager scriptBulletManager;

    [SerializeField, BoxGroup("Prefab")]
    private GameObject prefabGroupParent;

    private void Awake() {
        this.objectGameDirector = GameObject.FindWithTag("Director");
        this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

        this.objectSEManager = GameObject.FindWithTag("SEManager");
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

        this.objectParentOfGroups = GameObject.FindWithTag("ParentOfGroups");

        this.scriptBulletManager = this.GetComponent<BulletManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Target") {
            this.CollisionWithTarget(collision);

        } else if (collision.gameObject.tag == "Bullet") {
            this.CollisionWithBullet(collision);
        }
    }

    private void CollisionWithTarget(Collision2D collision) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("BulletCollider CollisionWithTarget");
        }

        TargetManager scriptTargetManager = collision.gameObject.GetComponent<TargetManager>();
        ParentManager scriptParentManager = null;

        GameObject objectGroupParent = null;
        GameObject objectBulletParent = this.scriptBulletManager.ObjectMyParent;
        GameObject objectTargetParent = scriptTargetManager.ObjectMyParent;

        bool bulletIsIsolated = objectBulletParent.tag != "GroupParent";
        bool targetIsIsolated = objectTargetParent.tag != "GroupParent";

        if (objectBulletParent == objectTargetParent) {
            return;
        }

        this.scriptSEManager.PlaySEBulletHit();

        if (bulletIsIsolated) {
            ScoreManager.AddScoreWhenBulletCollideWithTarget();

        } else {
            ScoreManager.AddScoreWhenGroupBulletCollideWithTarget();
        }

        if (bulletIsIsolated && targetIsIsolated) {
            objectGroupParent = Instantiate(this.prefabGroupParent) as GameObject;

            if (!TipsBoolManager.isAlreadyTipsCollisionTargetAndBullet) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionTargetAndBullet);
                TipsBoolManager.isAlreadyTipsCollisionTargetAndBullet = true;
            }

        } else if (bulletIsIsolated) {
            objectGroupParent = objectTargetParent;

        } else {
            objectGroupParent = objectBulletParent;
        }

        scriptParentManager = objectGroupParent.GetComponent<ParentManager>();

        if (bulletIsIsolated && targetIsIsolated) {
            scriptParentManager.SyncChild(scriptTargetManager);

            objectGroupParent.transform.SetParent(this.objectParentOfGroups.transform);
        }

        if (bulletIsIsolated) {
            this.scriptBulletManager.BecomeChild(objectGroupParent);
            scriptParentManager.NumOfBulletChildren++;
        }

        if (targetIsIsolated) {
            scriptTargetManager.BecomeChild(objectGroupParent);
            scriptParentManager.NumOfTargetChildren++;
        }

        if (!bulletIsIsolated && !targetIsIsolated) {
            // Debug.Log("parent  " + objectTargetParent.name);

            ParentManager scriptTargetParentManager = objectTargetParent.GetComponent<ParentManager>();

            foreach (GameObject child in scriptTargetParentManager.ListObjectChildren) {
                Debug.Log("child " + child.gameObject.name);

                if (child.tag == "Bullet") {
                    child.GetComponent<BulletManager>().BecomeChild(objectGroupParent);
                    Debug.Log("child Bullet " + child.name);

                } else if (child.tag == "Target") {
                    child.GetComponent<TargetManager>().BecomeChild(objectGroupParent);
                    Debug.Log("child Target " + child.name);

                }
            }

            /* 親要素のforeachで、時々、子要素を取得漏れする不具合あり

            foreach (Transform child in objectTargetParent.transform) {
                // Debug.Log("child " + child.gameObject.name);

                if (child.gameObject.tag == "Bullet") {
                    child.gameObject.GetComponent<BulletManager>().BecomeChild(objectGroupParent);
                    // Debug.Log("child Bullet " + child.gameObject.name);

                } else if (child.gameObject.tag == "Target") {
                    child.gameObject.GetComponent<TargetManager>().BecomeChild(objectGroupParent);
                    // Debug.Log("child Target " + child.gameObject.name);

                }
            }
            */

            scriptParentManager.NumOfBulletChildren += scriptTargetParentManager.NumOfBulletChildren;
            scriptParentManager.NumOfTargetChildren += scriptTargetParentManager.NumOfTargetChildren;
            
            Destroy(objectTargetParent);
        }

        scriptParentManager.UpdateParametersWhenChildrenIsIncreasing();

        /*
        Debug.Log("----------");
        Debug.Log("Bullet " + scriptParentManager.NumOfBulletChildren);
        Debug.Log("Target " + scriptParentManager.NumOfTargetChildren);
        Debug.Log("----------");
        */
    }

    private void CollisionWithBullet(Collision2D collision) {
        if (ConstantManager.IsDebugMode) {
            Debug.Log("BulletCollider CollisionWithBullet");
        }

        if (this.transform.position.x < collision.transform.position.x) {
            return;
        }

        BulletManager scriptCollisionBulletManager = collision.gameObject.GetComponent<BulletManager>();

        GameObject objectThisParent = this.scriptBulletManager.ObjectMyParent;
        GameObject objectCollisionBulletParent = scriptCollisionBulletManager.ObjectMyParent;

        bool thisIsIsolated = objectThisParent.tag != "GroupParent";
        bool collisionBulletIsIsolated = objectCollisionBulletParent.tag != "GroupParent";

        if (thisIsIsolated || collisionBulletIsIsolated) {
            this.scriptSEManager.PlaySEBulletVanish();
        }

        if (thisIsIsolated && collisionBulletIsIsolated) {
            if (!TipsBoolManager.isAlreadyTipsCollisionBulletAndBulletRapidFire) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionBulletAndBulletRapidFire);
                TipsBoolManager.isAlreadyTipsCollisionBulletAndBulletRapidFire = true;
            }

        } else if (thisIsIsolated || collisionBulletIsIsolated) {
            if (!TipsBoolManager.isAlreadyTipsCollisionBulletAndBullet) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsCollisionBulletAndBullet);
                TipsBoolManager.isAlreadyTipsCollisionBulletAndBullet = true;
            }
        }

        if (collisionBulletIsIsolated) {
            Destroy(collision.gameObject);
        }

        if (thisIsIsolated) {
            Destroy(this.gameObject);
        }
    }
}
