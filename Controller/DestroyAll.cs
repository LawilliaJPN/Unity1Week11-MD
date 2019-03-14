using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class DestroyAll : MonoBehaviour {
    [SerializeField, BoxGroup("GameObject")]
    protected GameObject objectGroups;

    public void DestroyAllGroup() {
        foreach (Transform group in objectGroups.transform) {
            if (group.gameObject.tag == "GroupParent") {
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
