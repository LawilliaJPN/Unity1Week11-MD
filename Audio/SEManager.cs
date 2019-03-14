using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SEManager : AudioManager {
    [SerializeField, BoxGroup("Audio")]
    private AudioClip seTest;

    private void Start() {
        this.Volume = 0.7f;
        this.UpdateVolume();
    }

    public void PlaySETest() {
        this.PlaySE(seTest);
    }
}
