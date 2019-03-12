using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TargetManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private RotateObject scriptRotateObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PulseObject scriptPulseObject;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MaxOfOuterRadiusRatio = 0.8f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MinOfOuterRadiusRatio = 0.2f;

    private void Awake() {
        this.scriptRotateObject = this.GetComponent<RotateObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();

        this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;

        this.scriptRotateObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptRotateObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;
    }
}
