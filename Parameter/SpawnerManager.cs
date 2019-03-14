using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MoveObject))]
[RequireComponent(typeof(PulseObject))]

public class SpawnerManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private MoveObject scriptMoveObject;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private PulseObject scriptPulseObject;

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private float maxOfOuterRadiusRatio, minOfOuterRadiusRatio;

    protected float MaxOfOuterRadiusRatio {
        get {
            return maxOfOuterRadiusRatio;
        }
        set {
            maxOfOuterRadiusRatio = value;

            if (maxOfOuterRadiusRatio < this.MinOfOuterRadiusRatio) {
                maxOfOuterRadiusRatio = this.MinOfOuterRadiusRatio;
            }

            this.scriptPulseObject.MaxOfOuterRadiusRatio = maxOfOuterRadiusRatio;
        }
    }

    protected float MinOfOuterRadiusRatio {
        get {
            return minOfOuterRadiusRatio;
        }
        set {
            minOfOuterRadiusRatio = value;

            if (minOfOuterRadiusRatio > this.MaxOfOuterRadiusRatio) {
                minOfOuterRadiusRatio = this.MaxOfOuterRadiusRatio;
            }

            this.scriptPulseObject.MinOfOuterRadiusRatio = minOfOuterRadiusRatio;
        }
    }

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private bool canMoveX = true;

    protected bool CanMoveX {
        get {
            return canMoveX;
        }
        set {
            canMoveX = value;
        }
    }

    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private bool canMoveY = true;

    protected bool CanMoveY {
        get {
            return canMoveY;
        }
        set {
            canMoveY = value;
        }
    }


    [BoxGroup("Range"), ShowInInspector, ReadOnly]
    private float maxOfMovingRangeX, minOfMovingRangeX, maxOfMovingRangeY, minOfMovingRangeY;

    protected float MaxOfMovingRangeX {
        get {
            return maxOfMovingRangeX;
        }
        set {
            maxOfMovingRangeX = value;

            if (maxOfMovingRangeX < this.MinOfMovingRangeX) {
                maxOfMovingRangeX = this.MinOfMovingRangeX;
            }
        }
    }

    protected float MinOfMovingRangeX {
        get {
            return minOfMovingRangeX;
        }
        set {
            minOfMovingRangeX = value;

            if (minOfMovingRangeX > this.MaxOfMovingRangeX) {
                minOfMovingRangeX = this.MaxOfMovingRangeX;
            }
        }
    }

    protected float MaxOfMovingRangeY {
        get {
            return maxOfMovingRangeY;
        }
        set {
            maxOfMovingRangeY = value;

            if (maxOfMovingRangeY < this.MinOfMovingRangeY) {
                maxOfMovingRangeY = this.MinOfMovingRangeY;
            }
        }
    }

    protected float MinOfMovingRangeY {
        get {
            return minOfMovingRangeY;
        }
        set {
            minOfMovingRangeY = value;

            if (minOfMovingRangeY > this.MaxOfMovingRangeY) {
                minOfMovingRangeY = this.MaxOfMovingRangeY;
            }
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private float speedX, speedY;

    public float SpeedX {
        get {
            return speedX;
        }
        set {
            speedX = value;

            if (speedX < 0) {
                speedX = 0;
            }
        }
    }

    public float SpeedY {
        get {
            return speedY;
        }
        set {
            speedY = value;

            if (speedY < 0) {
                speedY = 0;
            }
        }
    }

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

            this.scriptMoveObject.Speed = this.speed;
        }
    }

    private void Awake() {
        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptPulseObject = this.GetComponent<PulseObject>();
    }
}
