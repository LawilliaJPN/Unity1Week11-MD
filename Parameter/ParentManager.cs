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

            this.UpdateParametersWhenChildrenIsIncreasing();
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

            this.UpdateParametersWhenChildrenIsIncreasing();
        }
    }

    private void Awake() {
        this.objectGameDirector = GameObject.FindWithTag("Director");
        this.scriptOutputTips = this.objectGameDirector.GetComponent<OutputTips>();

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

    private void UpdateParametersWhenChildrenIsIncreasing() {
        int numOfChildren = this.NumOfBulletChildren + this.NumOfTargetChildren;

        if (numOfChildren >= ConstantManager.ExplosionStandardNumOfChildren) {
            this.Explosion();

            if (!TipsBoolManager.isAlreadyTipsChildrenExplosion) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsChildrenExplosion);
                TipsBoolManager.isAlreadyTipsChildrenExplosion = true;
            }

            /* なくてもいいかな
            } else if (numOfChildren >= ConstantManager.FallStandardNumOfChildren) {


            */

        } else if (numOfChildren >= ConstantManager.StopStandardNumOfChildren) {
            this.SpeedX = 0;

            if (!TipsBoolManager.isAlreadyTipsChildrenStop) {
                this.scriptOutputTips.SetNextTips(TipsTextManager.TipsChildrenStop);
                TipsBoolManager.isAlreadyTipsChildrenStop = true;
            }

        } else if (numOfChildren >= ConstantManager.SlowdownStandardNumOfChildren) {
            this.SpeedX = ConstantManager.TargetSpeed / 2;

        }
    }

    public void Explosion() {
        int numOfChildren = this.NumOfBulletChildren + this.NumOfTargetChildren;

        Debug.Log("Explosion " + numOfChildren);

        Destroy(this.gameObject);
    }
}