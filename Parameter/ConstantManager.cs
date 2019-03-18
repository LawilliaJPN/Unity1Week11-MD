using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ConstantManager : MonoBehaviour {
    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const bool IsDebugMode = false;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const string GameIdAtUnityroom = "meteor_decagon";

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const string GameNameJaJP = "メテオデカゴン";

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersion = 1;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersionMajor = 0;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const int GameVersionMinor = 0;

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const string GameVersionText = "1.0.0";

    [BoxGroup("Information"), ShowInInspector, ReadOnly]
    public const string TweetHashtag = "unity1week";


    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const int NumberOfWaves = 3;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float GameTimeWave1 = 35.0f;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float GameTimeWave2 = 35.0f;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float GameTimeWave3 = 35.0f;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float TimeDisplayTextWave = 3.0f;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float StandardOfTimerEmphasis = 5.0f;

    [BoxGroup("Timer"), ShowInInspector, ReadOnly]
    public const float TimeBeforeRetry = 3.0f;


    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointWhenBulletCollideWithTarget = 1;

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointWhenGroupBulletCollideWithTarget = 5;

    public enum PointNumOfTarget { // 配列を constには できないっぽいから 代用
        One = 5,
        Two = 25,
        Three = 100,
        FourOrMore = 200
    }

    public enum PointRatioType {
        Debug = 0,
        PlayerCollideWithTarget = 1,
        TargetCollideWithTarget = 2,
        OutOfBounds = 3,
        WaveFinish = 4,
        BulletCollideWithTarget = 5
    }
    /*
    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointRatioToDestroyWhenPlayerCollideWithTarget = 1;

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointRatioToDestroyWhenTargetCollideWithTarget = 2;

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointRatioToDestroyWhenWaveFinish = 4;

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    public const int PointRatioToDestroyWhenBulletCollideWithTarget = 5;
    */


    [BoxGroup("Audio"), ShowInInspector, ReadOnly]
    public const float InitialVolumeBGM = 0.6f;

    [BoxGroup("Audio"), ShowInInspector, ReadOnly]
    public const float InitialVolumeSE = 0.9f;

    [BoxGroup("Audio"), ShowInInspector, ReadOnly]
    public const float StandardOfBGMWave3 = 1000;


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
    public const float TargetSpeedWave1 = 0.04f;

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float TargetSpeedWave2 = 0.08f;

    [BoxGroup("Speed"), ShowInInspector, ReadOnly]
    public const float TargetSpeedWave3 = 0.12f;


    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeXMaxWave1 = 15.0f;  // 仮

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeXMinWave1 = -15.0f;  // 仮

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeYMaxWave1 = 3.0f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float EnemyRangeYMinWave1 = -3.0f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeXMax = 8.35f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeXMin = -7.85f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeYMax = 4.1f;

    [BoxGroup("MovingRange"), ShowInInspector, ReadOnly]
    public const float PlayerRangeYMin = -4.1f;


    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float OutOfBoundsRangeX = 15.0f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float OutOfBoundsRangeY = 10.0f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float BulletColliderRangeXMin = -9.5f;


    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int ExplosionStandardNumOfChildren = 5;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int FallStandardNumOfChildren = 4;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int StopStandardNumOfChildren = 3;

    [BoxGroup("Children"), ShowInInspector, ReadOnly]
    public const int SlowdownStandardNumOfChildren = 2;


    [BoxGroup("Generater"), ShowInInspector, ReadOnly]
    public const float TargetGeneratorCoolTimeWave1 = 3.2f;

    [BoxGroup("Generater"), ShowInInspector, ReadOnly]
    public const float TargetGeneratorCoolTimeWave2 = 2.4f;

    [BoxGroup("Generater"), ShowInInspector, ReadOnly]
    public const float TargetGeneratorCoolTimeWave3 = 1.2f;

    [BoxGroup("Generater"), ShowInInspector, ReadOnly]
    public const float BulletGeneratorPositionCorrection = -0.95f;
    

    [BoxGroup("Auto"), ShowInInspector, ReadOnly]
    public const int EnemyMoveFrequencyOfSwitchDirection = 1000;


    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMaxL = 0.8f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMax = 0.6f;

    [BoxGroup("Shaper2D"), ShowInInspector, ReadOnly]
    public const float OuterRadiusRatioMin = 0.2f;


    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int NumOfTipsInGame = 15;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int OrderOfTipsMoveWASD = 0;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const int OrderOfTipsShootClick = 1;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const float TipsSpan = 7.0f;

    [BoxGroup("Tips"), ShowInInspector, ReadOnly]
    public const float HideTipsSpan = 6.5f;
}
