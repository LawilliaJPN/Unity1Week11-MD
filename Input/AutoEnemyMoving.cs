using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class AutoEnemyMoving : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private EnemyManager scriptEnemyManager;

    private void Awake() {
        this.scriptEnemyManager = this.GetComponent<EnemyManager>();
    }

    private void Update() {
        if (GameDirector.IsGameRunning) {
            this.SetEnemySpeed();
        }
    }

    private void SetEnemySpeed() {
        Vector3 newSpeed = new Vector3(0, 0, 0);

        if (this.scriptEnemyManager.IsMovingUp) {
            newSpeed.y += this.scriptEnemyManager.SpeedY;

        } else {
            newSpeed.y -= this.scriptEnemyManager.SpeedY;
        }

        this.scriptEnemyManager.Speed = newSpeed;
    }
}
