using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class BGMPlayer : MonoBehaviour {
    [BoxGroup("GameObject"), ShowInInspector, ReadOnly]
    protected GameObject objectBGMManager;
    [BoxGroup("Component"), ShowInInspector, ReadOnly]
    protected BGMManager scriptBGMManager;

    private void Awake() {
        this.objectBGMManager = GameObject.FindWithTag("BGMManager");
        this.scriptBGMManager = this.objectBGMManager.GetComponent<BGMManager>();
    }

    private void Start() {
        this.PlayBGMAtNewScene();
    }

    public void PlayBGMAtNewScene() {
        switch (SceneManager.GetActiveScene().name) {
            case "Title":
                this.scriptBGMManager.PlayBGMTitle();
                break;
            case "Game":
                if (Random.Range(0, 1 + 1) == 0) {
                    this.scriptBGMManager.PlayBGMWave1();
                } else {
                    this.scriptBGMManager.PlayBGMWave2();
                }
                break;
        }
    }

    public void PlayBGMLater() {
        if (Random.Range(0, 1 + 1) == 0) {
            this.scriptBGMManager.PlayBGMWave3A();
        } else {
            this.scriptBGMManager.PlayBGMWave3B();
        }
    }

    public void PlayBGMResult() {
        this.scriptBGMManager.PlayBGMResult();
    }
}