using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TargetManager : ChildManager {
    private void Awake() {
        this.AwakeChild();
    }

    private void Start() {
        this.IsClockwise = true;

        this.MinOfOuterRadiusRatio = 0.1f;
        this.MaxOfOuterRadiusRatio = 0.6f;

        this.SpeedX = 0.02f;

        this.IsChild = false;

        this.StartChild();
    }
}
