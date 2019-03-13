using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(PulseObject))]

public class PlayerManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private MoveObject scriptMoveObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PulseObject scriptPulseObject;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private const float MaxOfOuterRadiusRatio = 0.6f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private const float MinOfOuterRadiusRatio = 0.1f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const bool CanMoveX = true;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const bool CanMoveY = true;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float MaxOfMovingRangeX = 8.0f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float MinOfMovingRangeX = -7.5f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float MaxOfMovingRangeY = 3.5f;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    public const float MinOfMovingRangeY = -3.5f;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    public const float SpeedX = 0.15f;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    public const float SpeedY = 0.2f;

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private Vector3 speed;

    public Vector3 Speed {
        get {
            return speed;
        }
        set {
            speed = value;

            if (!CanMoveX) {
                speed.x = 0;

            } else if ((this.transform.position.x > MaxOfMovingRangeX) && (speed.x > 0)) {
                speed.x = 0;

            } else if ((this.transform.position.x < MinOfMovingRangeX) && (speed.x < 0)) {
                speed.x = 0;
            }

            if (!CanMoveY) {
                speed.y = 0;

            } else if ((this.transform.position.y > MaxOfMovingRangeY) && (speed.y > 0)) {
                speed.y = 0;

            } else if ((this.transform.position.y < MinOfMovingRangeY) && (speed.y < 0)) {
                speed.y = 0;

            }

            if ((speed.x != 0) && (speed.y != 0)) {
                float correction = (float)(Math.Sqrt(Math.Pow(speed.x, 2) + Math.Pow(speed.y, 2)));

                speed.x *= Math.Abs(speed.x) / correction;
                speed.y *= Math.Abs(speed.y) / correction;
            }

            this.scriptMoveObject.Speed = this.speed;
        }
    }

    private void Awake() {
        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();

        this.scriptMoveObject.Speed = this.Speed;

        this.scriptPulseObject.MaxOfOuterRadiusRatio = MaxOfOuterRadiusRatio;
        this.scriptPulseObject.MinOfOuterRadiusRatio = MinOfOuterRadiusRatio;
    }
}
