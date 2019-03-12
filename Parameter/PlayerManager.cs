using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(PulseObject))]

public class PlayerManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PulseObject scriptPulseObject;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MaxOfOuterRadiusRatio = 0.6f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    private const float MinOfOuterRadiusRatio = 0.1f;
    
    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    public const float Speed = 0.2f;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    public const float MaxOfMovingRangeY = 3.0f;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    public const float MinOfMovingRangeY = -3.0f;

    private void Awake() {
        this.scriptPulseObject = this.GetComponent<PulseObject>();

        this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;
    }
}
