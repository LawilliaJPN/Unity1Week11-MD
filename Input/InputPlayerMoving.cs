using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InputPlayerMoving :MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PlayerManager scriptPlayerManager;

    private void Awake() {
        this.scriptPlayerManager = this.GetComponent<PlayerManager>();
    }

    private void Update() {
        this.SetPlayerSpeed();
    }

    private void SetPlayerSpeed() {
        Vector3 newSpeed = new Vector3(0, 0, 0);

        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.H))) {
            newSpeed.x -= this.scriptPlayerManager.SpeedX;
        }

        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.L))) {
            newSpeed.x += this.scriptPlayerManager.SpeedX;
        }

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.K))) {
            newSpeed.y += this.scriptPlayerManager.SpeedY;
        }

        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.J))) {
            newSpeed.y -= this.scriptPlayerManager.SpeedY;
        }

        this.scriptPlayerManager.Speed = newSpeed;
    }
}
