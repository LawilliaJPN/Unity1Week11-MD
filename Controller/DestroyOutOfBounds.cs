using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyOutOfBounds : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private ParentManager scriptParentManager;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float rangeX = ConstantManager.OutOfBoundsRangeX;

    public float RangeX {
        get {
            return rangeX;
        }
        set {
            rangeX = value;

            if (rangeX < 0) {
                rangeX = 0;
            }
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float rangeY = ConstantManager.OutOfBoundsRangeY;

    public float RangeY {
        get {
            return rangeY;
        }
        set {
            rangeY = value;

            if (rangeY < 0) {
                rangeY = 0;
            }
        }
    }

    private void Awake() {
        if (this.gameObject.tag == "GroupParent") {
            this.scriptParentManager = this.GetComponent<ParentManager>();
        }
    }

    private void Update() {
        if (this.gameObject.transform.parent.gameObject.tag == "GroupParent") {
            return;
        }

        if (this.transform.position.x < -this.RangeX) {
            this.DestroyOutOfBoundsObject();

        } else if (this.transform.position.x > this.RangeX) {
            this.DestroyOutOfBoundsObject();

        } else if (this.transform.position.y < -this.RangeY) {
            this.DestroyOutOfBoundsObject();

        } else if (this.transform.position.y > this.RangeY) {
            this.DestroyOutOfBoundsObject();

        }
    }

    private void DestroyOutOfBoundsObject() {
        if (this.gameObject.tag == "GroupParent") {
            this.scriptParentManager.Explosion(ConstantManager.PointRatioType.OutOfBounds);

        } else {
            Destroy(this.gameObject);
        }
    }
}
