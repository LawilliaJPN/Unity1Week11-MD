﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BulletGenerator : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    private GameObject objectParentOfBullets;

    [SerializeField, BoxGroup("Prefab")]
    private GameObject prefabBullet;

    private void Awake() {
        this.objectParentOfBullets = GameObject.FindWithTag("ParentOfBullets");
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GenerateBullet();
        }
    }

    private void GenerateBullet() {
        GameObject bullet = Instantiate(this.prefabBullet, this.transform.position, Quaternion.identity) as GameObject;
        bullet.transform.SetParent(this.objectParentOfBullets.transform);
    }
}