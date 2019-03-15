using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ConstantManager : MonoBehaviour {
    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const bool IsDebugMode = true;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersion = 0;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersionMajor = 9;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersionMinor = 0;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const string GameVersionText = "0.9.0";

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float GameTime = 70.0f;


    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float BulletSpeed = -0.2f;

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float EnemyHorizontalSpeed = 0.2f;  // 左右

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float EnemyVerticalSpeed = 0.15f;  // 前後

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float PlayerHorizontalSpeed = 0.2f;  // 左右

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float PlayerVerticalSpeed = 0.15f;  // 前後

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float TargetSpeed = 0.06f;


    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeXMaxWave1 = 15.0f;  // 仮

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeXMinWave1 = -15.0f;  // 仮

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeYMaxWave1 = 3.5f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeYMinWave1 = -3.5f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeXMax = 8.0f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeXMin = -7.5f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeYMax = 3.5f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeYMin = -3.5f;


    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int ExplosionStandardNumOfChildren = 5;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int FallStandardNumOfChildren = 4;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int StopStandardNumOfChildren = 3;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int SlowdownStandardNumOfChildren = 2;


    [BoxGroup("Generater"), ShowInInspector, ReadOnly]
    public const float TargetGeneratorCoolTime = 3.0f;


    [BoxGroup("Auto"), ShowInInspector, ReadOnly]
    public const int EnemyMoveFrequencyOfSwitchDirection = 1000;


    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMaxL = 0.8f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMax = 0.6f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMin = 0.2f;


    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int NumOfTipsInGame = 10;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int OrderOfTipsMoveWASD = 0;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int OrderOfTipsShootClick = 1;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const float TipsSpan = 7.0f;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const float HideTipsSpan = 6.5f;
}
