using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ParentManager : GroupManager {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectGameDirector;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private OutputTips scriptOutputTips;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private List<GameObject> listObjectChildren = new List<GameObject>();

    public List<GameObject> ListObjectChildren {
        get {
            return listObjectChildren;
        }
    }

    [BoxGroup("Parameter"), ShowInInspector, ReadOnly]
    private int numOfTargetChildren, numOfBulletChildren;

    public int NumOfTargetChildren {
        get {
            return numOfTargetChildren;
        }
        set {
            numOfTargetChildren = value;

            if (numOfTargetChildren < 0) {
                numOfTargetChildren = 0;
            }
        }
    }

    public int NumOfBulletChildren {
        get {
            return numOfBulletChildren;
        }
        set {
            numOfBulletChildren = value;

            if (numOfBulletChildren < 0) {
                numOfBulletChildren = 0;
            }
        }
    }

    private void Awake() {
        this.objectGameDirector = GameObject.FindWithTag("Director");
        this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

        this.objectSEManager = GameObject.FindWithTag("SEManager");
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

        this.scriptMoveObject = this.GetComponent<MoveObject>();
        this.scriptRotateObject = this.GetComponent<RotateObject>();

        this.NumOfTargetChildren = 0;
        this.NumOfBulletChildren = 0;
    }

    public void SyncChild(TargetManager scriptTargetManager) {
        Transform transformTarget = scriptTargetManager.gameObject.transform;

        this.transform.position = transformTarget.position;
        this.transform.Rotate(transformTarget.eulerAngles);

        RotateObject scriptRotateObjectTarget = scriptTargetManager.gameObject.GetComponent<RotateObject>();
        this.scriptRotateObject.TempRotation = scriptRotateObjectTarget.TempRotation;

        this.IsRotation = scriptTargetManager.IsRotation;
        this.IsClockwise = scriptTargetManager.IsClockwise;
        this.SpeedX = scriptTargetManager.SpeedX;
    }

    public void AddListObjectChildren(GameObject objectChild) {
        listObjectChildren.Add(objectChild);
    }

    public void UpdateParametersWhenChildrenIsIncreasing() {
        int numOfChildren = this.NumOfBulletChildren + this.NumOfTargetChildren;

        if (numOfChildren >= ConstantManager.ExplosionStandardNumOfChildren) {
            if (this.NumOfTargetChildren >= 3) {
                this.scriptSEManager.PlaySEDestroy3();

            } else if (this.NumOfTargetChildren >= 2) {
                this.scriptSEManager.PlaySEDestroy2();

            } else {
                this.scriptSEManager.PlaySEDestroy1();
            }

            this.Explosion(ConstantManager.PointRatioType.BulletCollideWithTarget);

            if (!TipsBoolManager.isAlreadyTipsChildrenExplosion) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsChildrenExplosion);
                TipsBoolManager.isAlreadyTipsChildrenExplosion = true;
            }

        } else if (numOfChildren >= ConstantManager.StopStandardNumOfChildren) {
            this.SpeedX = 0;

            if (!TipsBoolManager.isAlreadyTipsChildrenStop) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsChildrenStop);
                TipsBoolManager.isAlreadyTipsChildrenStop = true;
            }

        } else if (numOfChildren >= ConstantManager.SlowdownStandardNumOfChildren) {
            switch (GameDirector.CurrentWave) {
                case 1:
                    this.SpeedX = ConstantManager.TargetSpeedWave1 / 2;
                    break;

                case 2:
                    this.SpeedX = ConstantManager.TargetSpeedWave2 / 2;
                    break;

                case 3:
                    this.SpeedX = ConstantManager.TargetSpeedWave3 / 2;
                    break;
            }
        }
    }

    public void Explosion(ConstantManager.PointRatioType pointRatioType) {
        int numOfChildren = this.NumOfBulletChildren + this.NumOfTargetChildren;

        if (ConstantManager.IsDebugMode) {
            Debug.Log("Explosion " + numOfChildren);
        }
    
        ScoreManager.AddScoreToDestroyGroup(this.NumOfTargetChildren, pointRatioType);

        Destroy(this.gameObject);
    }
}