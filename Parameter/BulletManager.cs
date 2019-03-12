using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(RotateObject))]
[RequireComponent(typeof(PulseObject))]

public class BulletManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private MoveObject scriptMoveObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PulseObject scriptPulseObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private RotateObject scriptRotateObject;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MaxOfOuterRadiusRatio = 0.8f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MinOfOuterRadiusRatio = 0.1f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const bool IsClockwise = false;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float speedX = -0.2f;

    public float SpeedX {
        get {
            return speedX;
        }
        set {
            speedX = value;
            this.scriptMoveObject.Speed = new Vector3(speedX, this.scriptMoveObject.Speed.y, this.scriptMoveObject.Speed.z);
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isChild = false;

    public bool IsChild {
        get {
            return isChild;
        }
        set {
            isChild = value;

            this.scriptRotateObject.IsRotation = !isChild;
        }
    }

    private void Awake() {
        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();
        this.scriptRotateObject = this.GetComponent<RotateObject>();

        this.scriptMoveObject.Speed = new Vector3(this.SpeedX, this.scriptMoveObject.Speed.y, this.scriptMoveObject.Speed.z);

        this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;

        this.scriptRotateObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptRotateObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;
        this.scriptRotateObject.IsClockwise = IsClockwise;
    }
}
