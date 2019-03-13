using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BulletManager))]

public class BulletCollider : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectParentOfGroups;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BulletManager scriptBulletManager;

    [SerializeField, BoxGroup("Prefab")]
    private GameObject prefabGroupParent;

    private void Awake() {
        this.objectParentOfGroups = GameObject.FindWithTag("ParentOfGroups");

        this.scriptBulletManager = this.GetComponent<BulletManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Target") {
            TargetManager scriptTargetManager = collision.gameObject.GetComponent<TargetManager>();

            GameObject objectGroupParent = null;
            GameObject objectBulletParent = this.scriptBulletManager.ObjectMyParent;
            GameObject objectTargetParent = scriptTargetManager.ObjectMyParent;

            bool bulletIsIsolated = objectBulletParent.tag != "GroupParent";
            bool targetIsIsolated = objectTargetParent.tag != "GroupParent";

            if (bulletIsIsolated && targetIsIsolated) {
                objectGroupParent = Instantiate(this.prefabGroupParent) as GameObject;
                objectGroupParent.transform.position = collision.transform.position;
                objectGroupParent.transform.Rotate(collision.transform.localEulerAngles);
                objectGroupParent.transform.SetParent(this.objectParentOfGroups.transform);

            } else if (bulletIsIsolated) {
                objectGroupParent = objectTargetParent;

            } else {
                objectGroupParent = objectBulletParent;
            }

            if (bulletIsIsolated) {
                this.scriptBulletManager.BecomeChild(objectGroupParent);
            }

            if (targetIsIsolated) {
                scriptTargetManager.BecomeChild(objectGroupParent);
            }

            if (!bulletIsIsolated && !targetIsIsolated && (objectBulletParent != objectTargetParent)) {
                // Debug.Log("parent  " + objectTargetParent.name);

                foreach (Transform child in objectTargetParent.transform) {
                    // Debug.Log("child " + child.gameObject.name);

                    if (child.gameObject.tag == "Bullet") {
                        child.gameObject.GetComponent<BulletManager>().BecomeChild(objectGroupParent);
                        // Debug.Log("child Bullet" + child.gameObject.tag);

                    } else if (child.gameObject.tag == "Target") {
                        child.gameObject.GetComponent<TargetManager>().BecomeChild(objectGroupParent);
                        // Debug.Log("child Target" + child.gameObject.tag);

                    }
                }

                scriptTargetManager.BecomeChild(objectGroupParent);
                Destroy(objectTargetParent);
            }
        }
    }
}
