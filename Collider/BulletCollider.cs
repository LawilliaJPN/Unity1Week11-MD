using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(BulletManager))]

public class BulletCollider : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private BulletManager scriptBulletManager;

    private void Awake() {
        this.scriptBulletManager = this.GetComponent<BulletManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Target") {

            if (!this.scriptBulletManager.IsChild) {
                // Debug.Log("OnCollisionEnter2D BulletCollider Target Not IsChild");

                this.scriptBulletManager.IsChild = true;
                this.scriptBulletManager.SpeedX = 0;

                this.transform.SetParent(collision.transform);

            } else {
                // Debug.Log("OnCollisionEnter2D BulletCollider Target IsChild");

                TargetManager scriptTargetManager = collision.gameObject.GetComponent<TargetManager>();

                scriptTargetManager.IsChild = true;
                scriptTargetManager.SpeedX = 0;

                collision.transform.SetParent(this.transform);
            }
        }

    }
}
