using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BulletManager : ChildManager {
    private void Awake() {
        this.AwakeChild();
    }

    private void Start() {
        this.IsClockwise = false;

        this.MinOfOuterRadiusRatio = 0.1f;
        this.MaxOfOuterRadiusRatio = 0.8f;

        this.SpeedX = -0.2f;

        this.IsChild = false;

        this.StartChild();
    }
}
