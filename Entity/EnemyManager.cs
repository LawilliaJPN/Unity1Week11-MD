using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class EnemyManager : SpawnerManager {
    [BoxGroup("Move"), ShowInInspector, ReadOnly]
    private int frequencyOfSwitchDirection;

    public int FrequencyOfSwitchDirection {
        get {
            return frequencyOfSwitchDirection;
        }
        set {
            frequencyOfSwitchDirection = value;

            if (frequencyOfSwitchDirection < 0) {
                frequencyOfSwitchDirection = 0;
            }
        }
    }

    [BoxGroup("Move"), ShowInInspector, ReadOnly]
    private int correctionOfFrequencyOfSD;

    [BoxGroup("Move"), ShowInInspector, ReadOnly]
    private bool isMovingUp;

    public bool IsMovingUp {
        get {
            return isMovingUp;
        }
        set {
            isMovingUp = value;
        }
    }

    [BoxGroup("Generate"), ShowInInspector, ReadOnly]
    private float coolTime, coolTimeSpan;

    public float CoolTime {
        get {
            return coolTime;
        }
        set {
            coolTime = value;

            if (coolTime < 0) {
                coolTime = 0;
            }
        }
    }

    public float CoolTimeSpan {
        get {
            return coolTimeSpan;
        }
        set {
            coolTimeSpan = value;

            if (coolTimeSpan < 0) {
                coolTimeSpan = 0;
            }
        }
    }

    private void Start() {
        this.MaxOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMax;
        this.MinOfOuterRadiusRatio = ConstantManager.OuterRadiusRatioMin;

        this.CanMoveX = false;
        this.MaxOfMovingRangeX = ConstantManager.EnemyRangeYMaxWave1;
        this.MinOfMovingRangeX = ConstantManager.EnemyRangeYMinWave1;
        this.SpeedX = ConstantManager.EnemyVerticalSpeed;

        this.CanMoveY = true;
        this.MaxOfMovingRangeY = ConstantManager.EnemyRangeYMaxWave1;
        this.MinOfMovingRangeY = ConstantManager.EnemyRangeYMinWave1;
        this.SpeedY = ConstantManager.EnemyHorizontalSpeed;

        this.FrequencyOfSwitchDirection = ConstantManager.EnemyMoveFrequencyOfSwitchDirection;
        this.SwitchMovingDirectionRandomly();
    }

    private void Update() {
        UpdateMovingDirection();
    }

    private void UpdateMovingDirection() {
        SwitchMovingDirectionRandomly();

        if (this.transform.position.y > MaxOfMovingRangeY) {
            // Debug.Log("SwitchMovingDirection Max " + this.correctionOfFrequencyOfSD);
            this.SwitchMovingDirectionEdge();

        } else if (this.transform.position.y < MinOfMovingRangeY) {
            // Debug.Log("SwitchMovingDirection Min " + this.correctionOfFrequencyOfSD);
            this.SwitchMovingDirectionEdge();
        }
    }

    private void SwitchMovingDirection() {
        this.IsMovingUp = !this.IsMovingUp;
    }

    private void SwitchMovingDirectionEdge() {
        this.SwitchMovingDirection();
        this.correctionOfFrequencyOfSD++;
    }

    private void SwitchMovingDirectionRandomly() {
        if (Random.Range(0, FrequencyOfSwitchDirection) <= this.correctionOfFrequencyOfSD) {
            // Debug.Log("SwitchMovingDirection Randomly " + this.correctionOfFrequencyOfSD);

            this.SwitchMovingDirection();
            this.correctionOfFrequencyOfSD = 0;
        }
    }
}