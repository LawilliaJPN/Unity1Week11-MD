using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

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

    [BoxGroup("Beat"), ShowInInspector, ReadOnly]
    private static int bpm = 0;

    public static int BPM {
        get {
            return bpm;
        }
        set {
            // Debug.Log("bpm set");
            bpm = value;
            beatSpan = 60.0f / bpm;
            beatTimer = 0;

            barSpan = beatSpan * 4;
        }
    }

    [BoxGroup("Beat"), ShowInInspector, ReadOnly]
    private static float beatTimer = 0;

    public static float BeatTimer {
        get {
            return beatTimer;
        }
        set {
            beatTimer = value;

            if (beatTimer >= beatSpan) {
                beatTimer = 0;
            }
        }
    }

    [BoxGroup("Beat"), ShowInInspector, ReadOnly]
    private static float beatSpan = 0;

    [BoxGroup("Beat"), ShowInInspector, ReadOnly]
    private static float barTimer = 0;

    public static float BarTimer {
        get {
            return barTimer;
        }
        set {
            barTimer = value;

            if (barTimer >= barSpan) {
                barTimer = 0;
            }
        }
    }

    [BoxGroup("Beat"), ShowInInspector, ReadOnly]
    private static float barSpan = 0;

    private void Awake() {
        this.audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        BeatTimer += Time.deltaTime;
        BarTimer += Time.deltaTime;
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

    protected void ChangeMusic(AudioClip newMusic, int newBPM) {
        if (this.audioSource.clip != newMusic) { // 同じBGMの場合に最初から再生しなおさないように
            this.StopAudio();

            this.audioSource.clip = newMusic;
            BPM = newBPM;

            this.PlayAudio();
        }
    }

    public float GetRatioInBeat() {
        // Debug.Log("BPM " + (bpm));
        // Debug.Log("BeatTimer " + (beatTimer));
        // Debug.Log("BeatSpan " + (beatSpan));
        // Debug.Log("GetRatioInBeat " + (beatTimer / beatSpan));
        return beatTimer / beatSpan;
    }

    public float GetRatioInBar() {
        // Debug.Log("BarTimer " + (barTimer));
        // Debug.Log("BarSpan " + (barSpan));
        // Debug.Log("GetRatioInBar " + (barTimer / barSpan));
        return barTimer / barSpan;
    }
}
