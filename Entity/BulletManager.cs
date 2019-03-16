using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BulletManager : ChildManager {
    private void Start() {
        this.IsRotation = true;
        this.IsClockwise = false;

        this.MaxOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMaxL;
        this.MinOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMin;

        this.SpeedX = ConstantManager.BulletSpeed;
    }
}
