using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour {
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected AudioSource audioSource;

    [BoxGroup("Audio"), ShowInInspector, ReadOnly]
    private float volume = - 1.0f;

    public float Volume {
        get {
            return volume;
        }
        set {
            volume = value;

            if (volume > 1.0f) {
                volume = 1.0f;
            } else if (volume < 0) {
                volume = 0;
            }
        }
    }

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio() {
        this.UpdateVolume();
        this.audioSource.Play();
    }

    public void StopAudio() {
        this.audioSource.Stop();
    }

    public void PlaySE(AudioClip se) {
        this.UpdateVolume();
        this.audioSource.PlayOneShot(se);
    }

    public void UpdateVolume() {
        this.audioSource.volume = this.Volume;
    }
}
