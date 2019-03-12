using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SEManager :AudioManager {
    [SerializeField, BoxGroup("Audio")]
    private AudioClip seShot;

    private void Start() {
        this.Volume = 0.7f;
        this.UpdateVolume();
    }

    private void Update() {
        // デバッグ用
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            // this.PlaySEShot();
        }
    }

    private void PlaySEShot() {
        this.PlaySE(seShot);
    }
}
