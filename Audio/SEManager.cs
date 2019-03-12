using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SEManager :AudioManager {
    [SerializeField, BoxGroup("Audio")]
    private AudioClip seTest;

    private void Start() {
        this.Volume = 0.7f;
        this.UpdateVolume();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.RightControl)) {
            // デバッグ用
            this.PlaySETest();
        }
    }

    private void PlaySETest() {
        // デバッグ用
        this.PlaySE(seTest);
    }
}
