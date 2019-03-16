﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BulletGenerator : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectSEManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    private SEManager scriptSEManager;

    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectParentOfBullets;

    [SerializeField, BoxGroup("Prefab")]
    private GameObject prefabBullet;

    private void Awake() {
        this.objectSEManager = GameObject.FindWithTag("SEManager");
        this.scriptSEManager = this.objectSEManager.GetComponent<SEManager>();

        this.objectParentOfBullets = GameObject.FindWithTag("ParentOfBullets");
    }

    public void GenerateBullet() {
        if (!GameDirector.IsGameRunning) {
            return;
        }

        this.scriptSEManager.PlaySEShoot();

        GameObject bullet = Instantiate(this.prefabBullet, this.transform.position, Quaternion.identity) as GameObject;
        bullet.transform.SetParent(this.objectParentOfBullets.transform);
    }
}
