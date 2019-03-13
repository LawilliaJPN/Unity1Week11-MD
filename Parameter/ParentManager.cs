using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ParentManager : GroupManager {
    private void Awake() {
        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptRotateObject = this.GetComponent<RotateObject>();
    }

    private void Start() {
        this.SpeedX = 0.02f;
        this.scriptMoveObject.Speed = new Vector3(this.SpeedX, this.scriptMoveObject.Speed.y, this.scriptMoveObject.Speed.z);

        this.IsClockwise = true;
        this.scriptRotateObject.IsClockwise = IsClockwise;
    }
}
