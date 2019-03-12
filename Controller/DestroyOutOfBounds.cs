using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyOutOfBounds : MonoBehaviour {
    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float rangeX = 15.0f;

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
    private float rangeY = 10.0f;

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

    private void Update() {
        if (this.transform.position.x < -this.RangeX) {
            this.Destroy();

        } else if (this.transform.position.x > this.RangeX) {
            this.Destroy();

        } else if (this.transform.position.y < -this.RangeY) {
            this.Destroy();

        } else if (this.transform.position.y > this.RangeY) {
            this.Destroy();

        }
    }

    private void Destroy() {
        Destroy(this.gameObject);
    }
}
