using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyAll : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    protected GameObject objectGroups;

    private void Awake() {
        this.objectGroups = GameObject.FindWithTag("ParentOfGroups");
    }

    public void DestroyAllGroup(ConstantManager.PointRatioType pointRatioType) {
        foreach (Transform group in this.objectGroups.transform) {
            if (group.gameObject.tag == "GroupParent") {
                ParentManager scriptParentManager = group.gameObject.GetComponent<ParentManager>();
                ScoreManager.AddScoreToDestroyGroup(scriptParentManager.NumOfTargetChildren , pointRatioType);

                Destroy(group.gameObject);

            } else if (group.gameObject.tag == "ParentOfBullets") {
                foreach (Transform bullet in group.transform) {
                    Destroy(bullet.gameObject);
                }

            } else if (group.gameObject.tag == "ParentOfTargets") {
                foreach (Transform target in group.transform) {
                    Destroy(target.gameObject);
                }

            }
        }
    }
}
