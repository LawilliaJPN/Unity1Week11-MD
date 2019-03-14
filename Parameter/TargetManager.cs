using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TargetManager : ChildManager {
    private void Start() {
        this.IsRotation = true;
        this.IsClockwise = true;

        this.MaxOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMax;
        this.MinOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMin;

        this.SpeedX = ConstantManager.TargetSpeed;
    }
}
