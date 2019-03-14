using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class MoveObject : MonoBehaviour {
    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private Vector3 speed;

    public Vector3 Speed {
        get {
            return speed;
        }
        set {
            speed = value;

            if (speed.x > 1.0f) { // 仮
                speed.x = 1.0f;
            } else if (speed.x < -1.0) { // 仮
                speed.x = -1.0f;
            }

            if (speed.y > 1.0f) { // 仮
                speed.y = 1.0f;
            } else if (speed.y < -1.0) { // 仮
                speed.y = -1.0f;
            }

            if ((speed.x != 0) && (speed.y != 0)) {
                float correction = (float)(Math.Sqrt(Math.Pow(speed.x, 2) + Math.Pow(speed.y, 2)));

                speed.x *= Math.Abs(speed.x) / correction;
                speed.y *= Math.Abs(speed.y) / correction;
            }

            speed.z = 0;
        }
    }

    private void Update() {
        this.Move();
    }

    private void Move() {
        this.transform.position += this.Speed;
    }
}
