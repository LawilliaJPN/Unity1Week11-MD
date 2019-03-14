using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class TargetGenerator : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectParentOfTargets;

    [SerializeField, BoxGroup("Prefab")]
    private GameObject prefabTarget;

    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private EnemyManager scriptEnemyManager;

    private void Awake() {
        this.objectParentOfTargets = GameObject.FindWithTag("ParentOfTargets");

        this.scriptEnemyManager = this.GetComponent<EnemyManager>();
    }

    private void Update() {
        this.scriptEnemyManager.CoolTime -= Time.deltaTime;

        if (this.scriptEnemyManager.CoolTime <= 0) {
            GenerateTarget();
        }
    }

    private void GenerateTarget() {
        GameObject target = Instantiate(this.prefabTarget, this.transform.position, Quaternion.identity) as GameObject;
        target.transform.SetParent(this.objectParentOfTargets.transform);

        this.scriptEnemyManager.CoolTime = this.scriptEnemyManager.CoolTimeSpan;
    }
}
