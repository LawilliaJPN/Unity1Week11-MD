using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(RotateObject))]

public class GroupManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected MoveObject scriptMoveObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected RotateObject scriptRotateObject;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isRotation;

    public bool IsRotation {
        get {
            return isRotation;
        }
        set {
            isRotation = value;

            this.scriptRotateObject.IsRotation = isRotation;
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isClockwise;

    public bool IsClockwise {
        get {
            return isClockwise;
        }
        set {
            isClockwise = value;

            this.scriptRotateObject.IsClockwise = IsClockwise;
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float speedX;

    public float SpeedX {
        get {
            return speedX;
        }
        set {
            speedX = value;

            this.scriptMoveObject.Speed = new Vector3(speedX, this.scriptMoveObject.Speed.y, this.scriptMoveObject.Speed.z);
        }
    }
}
