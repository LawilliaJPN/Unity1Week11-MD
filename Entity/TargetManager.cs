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

        switch (GameDirector.CurrentWave) {
            case 1:
                this.SpeedX = ConstantManager.TargetSpeedWave1;
                break;

            case 2:
                this.SpeedX = ConstantManager.TargetSpeedWave2;
                break;

            case 3:
                this.SpeedX = ConstantManager.TargetSpeedWave3;
                break;
        }
    }
}
