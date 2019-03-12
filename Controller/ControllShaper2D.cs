using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ControllShaper2D : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    protected GameObject objectBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected BGMManager scriptBGMManager;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected Shaper2D shaper2D;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private float maxOfOuterRadiusRatio, minOfOuterRadiusRatio, difOfOuterRadiusRatio;

    public float MaxOfOuterRadiusRatio {
        get {
            return maxOfOuterRadiusRatio;
        }
        set {
            this.maxOfOuterRadiusRatio = value;

            if (this.maxOfOuterRadiusRatio > 1.0f) {
                this.maxOfOuterRadiusRatio = 1.0f;
            } else if (this.maxOfOuterRadiusRatio < this.MinOfOuterRadiusRatio) {
                this.maxOfOuterRadiusRatio = this.MinOfOuterRadiusRatio;
            }

            this.difOfOuterRadiusRatio = this.maxOfOuterRadiusRatio - this.MinOfOuterRadiusRatio;
        }
    }

    public float MinOfOuterRadiusRatio {
        get {
            return minOfOuterRadiusRatio;
        }
        set {
            this.minOfOuterRadiusRatio = value;

            if (this.minOfOuterRadiusRatio > 1.0f) {
                this.minOfOuterRadiusRatio = 1.0f;
            } else if (this.minOfOuterRadiusRatio > this.MaxOfOuterRadiusRatio) {
                this.minOfOuterRadiusRatio = this.MaxOfOuterRadiusRatio;
            }

            this.difOfOuterRadiusRatio = this.maxOfOuterRadiusRatio - this.MinOfOuterRadiusRatio;
        }
    }

    public float DifOfOuterRadiusRatio {
        get {
            return difOfOuterRadiusRatio;
        }
    }

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();

        this.shaper2D = this.GetComponent<Shaper2D>();
    }
}
