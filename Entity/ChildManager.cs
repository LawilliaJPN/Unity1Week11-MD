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

            this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
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

            this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;
        }
    }

    private void Awake() {
        this.objectMyParent = this.gameObject;

        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();
        this.scriptRotateObject = this.GetComponent<RotateObject>();
    }

    public void BecomeChild(GameObject parent) {
        ParentManager scriptParentManager = parent.GetComponent<ParentManager>();
        scriptParentManager.AddListObjectChildren(this.gameObject);

        this.ObjectMyParent = parent;

        this.IsRotation = false;
        this.SpeedX = 0;

        this.transform.SetParent(parent.transform);
    }
}
