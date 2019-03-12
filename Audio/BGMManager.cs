using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class BGMManager :AudioManager {
    [SerializeField, BoxGroup("Audio")]
    private AudioClip bgmTitle;  // Casual Fanny Track
    [BoxGroup("Audio BPM"), ShowInInspector, ReadOnly]
    private const int BpmBGMTitle = 135;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip bgmWave1;  // Casual Arcade Track #3
    [BoxGroup("Audio BPM"), ShowInInspector, ReadOnly]
    private const int BpmBGMWave1 = 104;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip bgmWave2;  // Casual Arcade Track #2
    [BoxGroup("Audio BPM"), ShowInInspector, ReadOnly]
    private const int BpmBGMWave2 = 102;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip bgmWave3A;  // Casual Arcade Track #1
    [BoxGroup("Audio BPM"), ShowInInspector, ReadOnly]
    private const int BpmBGMWave3A = 130;

    [SerializeField, BoxGroup("Audio")]
    private AudioClip bgmWave3B;  // Casual Arcade Track #1 Version 2
    [BoxGroup("Audio BPM"), ShowInInspector, ReadOnly]
    private const int BpmBGMWave3B = 130;

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


    private void Start() {
        this.Volume = 0.8f;
        this.UpdateVolume();
        this.audioSource.loop = true;
    }

    private void Update() {
        BeatTimer += Time.deltaTime;
        BarTimer += Time.deltaTime;
    }

    private void ChangeMusic(AudioClip newMusic, int newBPM) {
        if (this.audioSource.clip != newMusic) { // 同じBGMの場合に最初から再生しなおさないように
            this.StopAudio();

            this.audioSource.clip = newMusic;
            BPM = newBPM;

            this.PlayAudio();
        }
    }

    public void PlayBGMTitle() {
        this.ChangeMusic(this.bgmTitle, BpmBGMTitle);
    }

    public void PlayBGMWave1() {
        this.ChangeMusic(this.bgmWave1, BpmBGMWave1);
    }

    public void PlayBGMWave2() {
        this.ChangeMusic(this.bgmWave2, BpmBGMWave2);
    }

    public void PlayBGMWave3A() {
        this.ChangeMusic(this.bgmWave3A, BpmBGMWave3A);
    }

    public void PlayBGMWave3B() {
        this.ChangeMusic(this.bgmWave3B, BpmBGMWave3B);
    }

    public void SwitchBGM() {
        if (this.audioSource.clip == this.bgmTitle) {  // AudioClipでswitch文使えないみたい
            this.PlayBGMWave1();

        } else if (this.audioSource.clip == this.bgmWave1) {
            this.PlayBGMWave2();

        } else if (this.audioSource.clip == this.bgmWave2) {
            this.PlayBGMWave3A();

        } else if (this.audioSource.clip == this.bgmWave3A) {
            this.PlayBGMWave3B();

        } else if (this.audioSource.clip == this.bgmWave3B) {
            this.PlayBGMTitle();
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
