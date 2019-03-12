using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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


    private void Start() {
        this.Volume = 0.8f;
        this.UpdateVolume();
        this.audioSource.loop = true;
    }

    public void PlayBGMAtNewScene() {
        // シーン開始時に呼ばれる

        Debug.Log("BGMManager - PlayMusicAtNewScene / " + SceneManager.GetActiveScene().name);

        switch (SceneManager.GetActiveScene().name) {
            case "Title":
                this.ChangeMusic(this.bgmTitle, BpmBGMTitle);
                break;
            case "Game":
                this.ChangeMusic(this.bgmWave1, BpmBGMWave1);
                break;
        }
    }

    public void SwitchBGM() {
        if (this.audioSource.clip == this.bgmTitle) {  // AudioClipでswitch文使えないみたい
            this.ChangeMusic(this.bgmWave1, BpmBGMWave1);

        } else if (this.audioSource.clip == this.bgmWave1) {
            this.ChangeMusic(this.bgmWave2, BpmBGMWave2);

        } else if (this.audioSource.clip == this.bgmWave2) {
            this.ChangeMusic(this.bgmWave3A, BpmBGMWave3A);

        } else if (this.audioSource.clip == this.bgmWave3A) {
            this.ChangeMusic(this.bgmWave3B, BpmBGMWave3B);

        } else if (this.audioSource.clip == this.bgmWave3B) {
            this.ChangeMusic(this.bgmTitle, BpmBGMTitle);

        }
    }
}
