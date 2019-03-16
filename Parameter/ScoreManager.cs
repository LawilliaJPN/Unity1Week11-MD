using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ScoreManager : MonoBehaviour {
    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    private static int totalScore;

    public static int TotalScore {
        get {
            return totalScore;
        }
    }

    [BoxGroup("Score"), ShowInInspector, ReadOnly]
    private static int[] waveScores = new int[ConstantManager.NumberOfWaves];

    public static int[] WaveScores {
        get {
            return waveScores;
        }
    }

    [BoxGroup("Counter"), ShowInInspector, ReadOnly]
    private static int counterBulletHit;


    public static void ResetScores() {
        ResetWaveScores();
        counterBulletHit = 0;
    }

    private static void ResetWaveScores() {
        for (int i = 0; i < waveScores.Length; i++) {
            waveScores[i] = 0;
        }
        SetTotalScore();
    }

    private static void AddWaveScore(int wave, int value) {
        waveScores[wave - 1] += value;
        SetTotalScore();
    }

    private static void SetTotalScore() {
        int newTotalScore = 0;

        foreach (int waveScore in waveScores) {
            newTotalScore += waveScore;
        }

        totalScore = newTotalScore;
    }

    public static void AddScoreWhenBulletCollideWithTarget() {
        AddWaveScore(GameDirector.CurrentWave, ConstantManager.PointWhenBulletCollideWithTarget);
        counterBulletHit++;
    }

    public static void AddScoreWhenGroupBulletCollideWithTarget() {
        AddWaveScore(GameDirector.CurrentWave, ConstantManager.PointWhenGroupBulletCollideWithTarget);
        counterBulletHit++;
    }

    public static void AddScoreToDestroyGroup(int numOfTargetChildren, ConstantManager.PointRatioType pointRatioType) {
        int addend = 0;

        if (numOfTargetChildren >= 4) {
            addend = (int)ConstantManager.PointNumOfTarget.FourOrMore;

        } else if (numOfTargetChildren == 3) {
            addend = (int)ConstantManager.PointNumOfTarget.Three;

        } else if (numOfTargetChildren == 2) {
            addend = (int)ConstantManager.PointNumOfTarget.Two;

        } else if (numOfTargetChildren == 1) {
            addend = (int)ConstantManager.PointNumOfTarget.One;

        }

        addend *= (int)pointRatioType;
        AddWaveScore(GameDirector.CurrentWave, addend);

        if (ConstantManager.IsDebugMode) {
            Debug.Log("AddScoreToDestroyGroup addend:" + addend);
            Debug.Log("(TargetNum: " + numOfTargetChildren + " PointRatio:" + (int)pointRatioType + ")");
        }
    }
}
