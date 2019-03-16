using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerManager : SpawnerManager {
    private void Start() {
        this.MaxOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMax;
        this.MinOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMin;

        this.CanMoveX = true;
        this.MaxOfMovingRangeX = ConstantManager.PlayerRangeXMax;
        this.MinOfMovingRangeX = ConstantManager.PlayerRangeXMin;
        this.SpeedX = ConstantManager.PlayerVerticalSpeed;

        this.CanMoveY = true;
        this.MaxOfMovingRangeY = ConstantManager.PlayerRangeYMax;
        this.MinOfMovingRangeY = ConstantManager.PlayerRangeYMin;
        this.SpeedY = ConstantManager.PlayerHorizontalSpeed;
    }
}