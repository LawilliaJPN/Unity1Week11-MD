using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(PulseObject))]

public class ChildManager : GroupManager {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected GameObject objectMyParent;

    public GameObject ObjectMyParent {
        get {
            return objectMyParent;
        }
        set {
            objectMyParent = value;
        }
    }

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected PulseObject scriptPulseObject;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private float maxOfOuterRadiusRatio;

    public float MaxOfOuterRadiusRatio {
        get {
            return maxOfOuterRadiusRatio;
        }
        set {
            maxOfOuterRadiusRatio = value;

            if (maxOfOuterRadiusRatio < this.MinOfOuterRadiusRatio) {
                maxOfOuterRadiusRatio = this.MinOfOuterRadiusRatio;
            }
        }
    }

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private float minOfOuterRadiusRatio;

    public float MinOfOuterRadiusRatio {
        get {
            return minOfOuterRadiusRatio;
        }
        set {
            minOfOuterRadiusRatio = value;

            if (minOfOuterRadiusRatio > this.MaxOfOuterRadiusRatio) {
                minOfOuterRadiusRatio = this.MaxOfOuterRadiusRatio;
            }
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private bool isChild;

    public bool IsChild {
        get {
            return isChild;
        }
        set {
            isChild = value;

            this.scriptRotateObject.IsRotation = !isChild;
        }
    }

    protected void AwakeChild() {
        this.objectMyParent = this.gameObject;

        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();
        this.scriptRotateObject = this.GetComponent<RotateObject>();
    }

    protected void StartChild() {
        this.scriptMoveObject.Speed = new Vector3(this.SpeedX, this.scriptMoveObject.Speed.y, this.scriptMoveObject.Speed.z);

        this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;

        this.scriptRotateObject.IsClockwise = IsClockwise;
    }

    public void BecomeChild(GameObject parent) {
        this.ObjectMyParent = parent;
        this.IsChild = true;
        this.SpeedX = 0;
        this.transform.SetParent(parent.transform);
    }
}
